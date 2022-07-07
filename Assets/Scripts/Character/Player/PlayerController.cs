using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {


    /// <summary>
    /// 乗り移ってるmachineのtransform
    /// </summary>
    [SerializeField] GameObject target_machine;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] float moveSpeed = 1.0f;

    /// <summary>
    /// 空中での移動速度
    /// </summary>
    /// hh
    [SerializeField] float flySpeed = 0.5f;

    /// <summary>
    /// ジャンプ力
    /// </summary>
    [SerializeField] float jumpPower = 1.0f;

    [SerializeField] int select = 0;
    int old_select = 0;
    [SerializeField]  int select_num = 0;

    GameObject[] MoveObject = new GameObject[10];

    GameObject[] CommandObject = new GameObject[10];
    /// <summary>
    /// ジャンプフラグ
    /// </summary>
    private bool canJump;

    Rigidbody rigidbody;

    MachineData machine;

    bool AxisLook = false;

    Transform InfectionArea;


    // Use this for initialization
    void Start () {

        //ジャンプフラグを切る
        canJump = false;
        //自分のRigidbodyをあらかじめ確保
        rigidbody = GetComponent<Rigidbody>();
        
        //感染範囲のゲームオブジェクトを格納
        InfectionArea = transform.Find("InfectionArea");

        //移動先のマシンのgimmickを格納
        for (int i = 0; i < 10; i++)
        { 
            MoveObject[i] = null;
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetButtonDown("Action3"))
        {
            for (int i = 0; i < 10; i++)
            {
                if (MoveObject[i] != null)
                {
                    select_num++;
                }
            }
        }
        else if ((Input.GetKey(KeyCode.LeftShift)|| Input.GetButton("Action3")) && select_num != 0)
        {
            InfectionTargetSelect();
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift)|| Input.GetButtonUp("Action3"))
        {
            if (select_num != 0) {
                MoveObject[select].transform.Find("Cube").GetComponent<Renderer>().material.color = new Color(0, 255, 0);
            }
            select_num = 0;
            select = 0;

            for (int i = 0; i < 10; i++)
            {
                MoveObject[i] = null;
            }
            MoveObject[0] = target_machine;

        }
        else if (Input.GetKeyDown(KeyCode.E)|| Input.GetButtonDown("Action2"))
        {
            target_machine.GetComponent<Rigidbody>().Sleep();
            transform.position = target_machine.GetComponent<Transform>().position;
        }
        else if (Input.GetKey(KeyCode.E)|| Input.GetButton("Action2"))
        {
            Transform InfectionArea;
            InfectionArea = transform.Find("InfectionArea");

            Vector3 Scale = InfectionArea.localScale;

            if (Scale.x < 15)
            {
                InfectionArea.localScale = new Vector3(Scale.x + 0.1f, 1.0f, Scale.z + 0.1f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.E)|| Input.GetButtonDown("Action2"))
        {
            target_machine.GetComponent<Rigidbody>().WakeUp();
        }

        /// <summary>
        /// プレイヤーが動いているときの処理
        /// </summary>
        {
            machine = target_machine.GetComponent<MachineData>();
            //入力による移動
            Vector3 moveValue = Vector3.zero;


            { 
                Vector3 Scale = InfectionArea.localScale;
                if (Scale.x > 0.0f&&!(Input.GetKey(KeyCode.E)|| Input.GetButton("Action2")))
                {
                    InfectionArea.localScale = new Vector3(Scale.x - 0.1f, Scale.y, Scale.z - 0.1f);
                }
                Scale = InfectionArea.localScale;

            }


            //平行移動
            if (canJump)
            {
                //地上
                moveValue.x = Input.GetAxis("Horizontal") * machine.moveSpeed;
                moveValue.z = Input.GetAxis("Vertical") * machine.moveSpeed;
            }
            else
            {
                //空中
                moveValue.x = Input.GetAxis("Horizontal") * machine.flySpeed;
                moveValue.z = Input.GetAxis("Vertical") * machine.flySpeed;
            }

            //ジャンプ
            if (canJump)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Action0"))
                {
                    moveValue.y = machine.jumpPower;
                }
            }
            //移動量の更新
            //rigidbody.AddForce(moveValue);

            target_machine.GetComponent<Rigidbody>().AddForce(moveValue);
            transform.position = target_machine.GetComponent<Transform>().position;

            //方向の更新
            {
                moveValue.y = 0.0f;
                transform.LookAt(transform.position + moveValue);

                target_machine.GetComponent<Transform>().LookAt(transform.position + moveValue);
            }
            //ゲームオーバー処理
            if (transform.position.y < -2.0f)
            {
                GameSceneManager.instance.GameOver();
            }
        }
    }

    /// <summary>
    /// RigidBody同士の衝突処理（衝突中）
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if( collision.gameObject.tag == "Field")
        {
            canJump = true;
        }
    }

    /// <summary>
    /// RigidBody同士の衝突処理（離れたとき）
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
        {
            canJump = false;
        }
    }

    /// <summary>
    /// 衝突処理（衝突中）
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Field")
        {
            canJump = true;
        }
        //if (other.tag == "Machine")
        //{
        //    if (other.transform.Find("MachineState").gameObject.tag == "Hack")
        //    {
        //        Debug.Log("移動距離ですよ！！");
        //        for (int i = 0; i < 10; i++)
        //        {
        //            if (MoveObject[i] != null)
        //            {
        //                continue;
        //            }

        //            MoveObject[i] = other.gameObject;
        //           // Debug.Log("移動範囲ですよ！！");
        //            break;
        //        }
        //    }
                
        //}
    }

    /// <summary>
    /// 衝突処理（衝突中）
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {

        if (other.tag != "Machine")
        {
            return;
        }
        if (other.transform.Find("MachineState").gameObject.tag == "Hack")
        {
            Transform w;

             w= other.transform.Find("MachineState/Gimmick_State");
            if (w ==null)
            {
                return;
            }
            if (w.gameObject.tag != ("control_gimmick"))
            {
                if (w.gameObject.tag != ("Active_gimmick")) { return ; }

                if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Action1"))
                {
                        Destroy(other.gameObject);

                }
            }

            int cnt= 0;

            for (int i = 0; i < 10; i++)
            {
                if (MoveObject[i] == null)
                {
                    continue;
                }
                if (MoveObject[i] == other.gameObject)
                {
                    cnt++;
                }

            }
            if (cnt == 0) {

                for (int i = 0; i < 10; i++)
                {
                    if (MoveObject[i] != null)
                    {
                        continue;
                    }
                    if(MoveObject[i] == other.gameObject)
                    {
                        continue;
                    }
                    MoveObject[i] = other.gameObject;
                    Debug.Log("移動範囲ですよ！！");
                    break;
                }
            }

        }
    }


    /// <summary>
    /// 衝突処理（離れたとき）
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Field")
        {
            canJump = false;
        }
        if (other.tag == "Machine")
        {
            if (other.transform.Find("MachineState").gameObject.tag == "Hack")
            {
                for (int i = 0; i < 10; i++)
                {
                    if (MoveObject[i] != other.gameObject)
                    {
                        continue;
                    }
                    MoveObject[i] = null;
                    Debug.Log("移動距離がいですよ！！");
                }
            }

        }

    }

    private void InfectionTargetSelect()
    {
        old_select = select;
        if (!AxisLook)
        {
            if (Input.GetKeyDown(KeyCode.A) || (Input.GetAxis("Horizontal") > 0.5f))
            {
                select -= 1;
                if (select < 0)
                {
                    select = select_num - 1;

                    MoveObject[select].transform.Find("Cube").GetComponent<Renderer>().material.color = new Color(255, 255, 0);

                    MoveObject[old_select].transform.Find("Cube").GetComponent<Renderer>().material.color = new Color(0, 255, 0);


                    AxisLook = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.D) || (Input.GetAxis("Horizontal") < -0.5f))
            {
                select += 1;
                if (select >= select_num)
                {
                    select = 0;

                    MoveObject[select].transform.Find("Cube").GetComponent<Renderer>().material.color = new Color(255, 255, 0);

                    MoveObject[old_select].transform.Find("Cube").GetComponent<Renderer>().material.color = new Color(0, 255, 0);

                    AxisLook = true;
                }
            }
        }
        else
        {
            if (Input.GetAxis("Horizontal") == 0.0f)
            {
                AxisLook = false;
            }
        }


        target_machine = MoveObject[select];
        transform.position = target_machine.GetComponent<Transform>().position;


    }

    private void Command()
    {

    }
}
