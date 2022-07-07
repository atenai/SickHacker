using UnityEngine;


public class RabbitMachine :
    MachineCore,
    IKillable,      //殺用インターフェース
    IInfectable,    //感染インターフェース
    IActable,       //アクションインターフェース
    IMove,           //移動用インターフェース
    IGimmickable     //ギミック用インターフェース
{
     public float JumpPower;
    public float MoveSpeed;

    public bool JumpFlag;

    void Start()
    {
        JumpFlag = true;
        on_Hack = false;

        Security_level = 50.0f;
        Erosion_level = 0.0f;

        MachineState = MachineStatus.STAY;
        Sickstate = SickStatis.HEALTHY;
        HackState = HackStatus.UNHACK;
    }

    // Update is called once per frame
    void Update()
    {
        if (!on_Hack)
        { 

        }

        if (JumpFlag == false) {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -300, 0));
        }
    }

    public void Action()
    {
        if (JumpFlag ==false)
        {
            return;
        }

        MachineState = MachineStatus.ACTION;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpPower, 0));

        JumpFlag = false;
    }
    public void Kill()
    {

        Debug.Log("死んだ！！");
    }

    public bool Infect(float Tension)
    {
        if (on_Hack)
        {
            return true;
        }

        Erosion_level += Tension;

        if (Security_level <= Erosion_level)
        {
            on_Hack = true;

            return true;
        }
        return false;
    }

    public void Move(float x,float z)
    {
        //transform.Translate( new Vector3(0.5f * x, 0.0f, 0.5f * z))  ;

        GetComponent<Rigidbody>().AddForce(new Vector3(x*200.0f, 0, z*200.0f));
        transform.LookAt(transform.position + new Vector3(x,0.0f,z));
    }

    public MachineCore Gimmick()
    {
        HackState = HackStatus.HACKING;

        return GetComponent<MachineCore>();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Field")
        {
            JumpFlag = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Field")
        {
            JumpFlag = false;
        }
    }
}
