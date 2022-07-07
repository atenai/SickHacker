using UnityEngine;
using System.Collections;

public class MachineDeleteBullet : MonoBehaviour,
    IKillable
{
    Vector3 FrontVec = new Vector3(0.1f, 0.0f, 0.0f);
    float BulletSpeed;

    // Use this for initialization
    void Start()
    {
       // FrontVec = new Vector3(0.1f,0.0f,0.0f);
    }

    public void SetVector(Vector3 front)
    {
        FrontVec　= front;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + FrontVec;
        transform.LookAt(FrontVec);

    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        MachineCore core;
        //もらってきたものがMachineCoreを持っているかを判定するためにGetComponent
        core = other.gameObject.GetComponent<MachineCore>();

        if (core != null)
        //NullではないということはMachineCoreを持っているので判定継続
        {
            //消去できるオブジェクトかどうかの判別
            IKillable Killer = core.GetComponent<IKillable>();

            if (Killer != null)
            {
                Killer.Kill();

                Kill();
            }
        }
    }


    /// <summary>
    /// 衝突処理（衝突中）
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        //MachineCore core;
        ////もらってきたものがMachineCoreを持っているかを判定するためにGetComponent
        //core = other.GetComponent<MachineCore>();

        //if (core != null)
        //    //NullではないということはMachineCoreを持っているので判定継続
        //{
        //    //消去できるオブジェクトかどうかの判別
        //    IKillable Killer= core.GetComponent<IKillable>();

        //    if (Killer != null)
        //    {
        //        Killer.Kill();

        //        Kill();
        //    }
        //}


    }
}
