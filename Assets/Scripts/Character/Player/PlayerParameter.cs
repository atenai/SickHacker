using UnityEngine;
using System.Collections;

public class PlayerParameter :BasePlayerComponent
{
    public enum Tension
        //ウイルスのテンションを表す
    {
        TIRE = -2,
        SURPRISE = -1,
        NORMAL = 0,
        HAPPY,
        HIGH_TENSION
    }

    public Tension tension;
    //ウイルスの今のテンション

    public float InfectAreaLimitRadius { get; set; }
    //感染領域の現在の限界値

    public float InfectAreaRadius { get; set; }
    //感染領域の現在の半径の値

    public float InfectPower { get; set; }
    //感染させるためのパワー

     MachineCore[] InfectCore = new MachineCore[10];
    //感染エリア内にいるMachineの内感染完了しているものを確保する配列

    public MachineCore RideMachine;

    Transform InfectionArea;

    private void Start()
    {
        tension = Tension.NORMAL;

        //配列の中をすべて初期化
        for (int i = 0; i<10; i++)
        {
            InfectCore[i] = null;
        }
        InfectionArea = transform.Find("InfectionArea");

        ///初期値設定
        ///感染力　                 100
        ///最大感染エリア半径        5.0
        ///初期感染エリア半径        0.0
        InfectPower = 100.0f;
        InfectAreaLimitRadius = 10.0f;
        InfectAreaRadius = 0.1f;

    }

    /// <summary>
    /// 更新処理
    /// </summary>
    ///
    private void Update()
    {
        //感染エリアのscaleの拡縮
        if (Input.GetKey(KeyCode.E) || Input.GetButton("Action2"))
        {
            InfectAreaRadius += 0.1f;

            if (InfectAreaRadius > InfectAreaLimitRadius)
            {
                InfectAreaRadius = InfectAreaLimitRadius;
            }

            InfectionArea.localScale = new Vector3(InfectAreaRadius, 1.0f, InfectAreaRadius);
        }
        else　if (InfectAreaRadius> 0.0f )
        {
            InfectAreaRadius -= 0.1f;

            if (InfectAreaRadius < 0.0f)
            {
                InfectAreaRadius = 0.0f;
            }

            InfectionArea.localScale = new Vector3(InfectAreaRadius, 1.0f, InfectAreaRadius);
        }

        for (int i = 0; i < 10; i++)
        {
            if (InfectCore[i] == RideMachine)
            //乗り込んでいるマシンと同じ者が配列で確保されている場合配列から外す
            {
                InfectCore[i] = null;
                break;
            }
        }

    }

    /// <summary>
    /// 距離計測
    /// </summary>
    /// <param name="other"></param>
    public MachineCore GetNearDistance()
    {
        float NearDistance = InfectAreaRadius* InfectAreaRadius;
        //一番近い距離……初期値は現在のエリア半径
        float DistanceWork;
        //一時的な変数

        int Near = -1;
        //一番近いオブジェクトの半径

        for (int i = 0; i < 10; i++)
        {
            if (InfectCore[i] != null)
                //配列がNULLではない場合処理
            { 
                DistanceWork = Vector3.SqrMagnitude(InfectCore[i].transform.position - transform.position);
                //現在位置とMachineの間の距離を取得して一時返数に入れる

                if (DistanceWork < NearDistance)
                    /*NearDistance（最小距離）よりも小さい場合には添え字を確保し、
                    NearDistanceに代入*/
                {
                    Near = i;
                    NearDistance = DistanceWork;
                }
             }
        }

        if (Near >= 0)
        /*0以上の場合一番エリア内で近いMachineCoreを返す*/
        {
            return InfectCore[Near];
        }
        //-1の場合Nullを返す
        return null;
    }

    /// <summary>
    /// 衝突処理（衝突中）
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        MachineCore core;
        //もらってきたものがMachineCoreを持っているかを判定するためにGetComponent
        core = other.GetComponent<MachineCore>();

        //もらってきたMachineCoreがNULLだった場合処理終了
        if (core ==null || core == RideMachine)
        {
            return;
        }
        if (!core.on_Hack)
        {
            //Powerを消費して感染


            //coreへ感染して、いま操作可能なオブジェクトかどうか返り値でもらってくる

            IInfectable infectar = core.GetComponent<IInfectable>();
            if (infectar == null)
            {
                return;
            }
            bool Hack = infectar.Infect(1.0f);
        }

        //操作可能なマシンだった場合配列へ確保
        if (core.on_Hack)
        {
            for (int i = 0; i < 10; i++)
            {
                if (InfectCore[i] == core)
                //もうすでに同じ中身が確保されている場合処理終了
                {
                    return;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (InfectCore[i] != null)
                //もうすでに中身がある場合入れられないので次の配列へ
                {
                    continue;
                }

                //空の配列が見つかった場合そこへ確保
                InfectCore[i] = core;
                Debug.Log("移動範囲ですよ！！");
                break;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        MachineCore core;
        //もらってきたものがMachineCoreを持っているかを判定するためにGetComponent
        core = other.GetComponent<MachineCore>();

        //もらってきたMachineCoreがNULLだった場合処理終了
        if (core == null)
        {
            return;
        }

        //ハッキングされている場合確認して配列から外す
        if (core.on_Hack)
        {
            for (int i = 0; i < 10; i++)
            {
                if (InfectCore[i] != core)
                {
                    continue;
                }
                InfectCore[i] = null;
                Debug.Log("移動距離がいですよ！！");
            }
        }
    }

}
