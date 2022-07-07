using UnityEngine;


public class FireWallMachine :
    MachineCore,
    IKillable,      //殺用インターフェース
    IInfectable,    //感染インターフェース
    IGimmickable     //ギミック用インターフェース
{
    float JumpPower;
    public float MoveSpeed;

    void Start()
    {
        on_Hack = false;

        Security_level = 350.0f;
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
        //GetComponent<Rigidbody>().AddForce(new Vector3(0, -300, 0));
        if (HackStatus.HACKING == HackState)
        {
            Destroy(gameObject);
        }

    }

    public void Action()
    {

    }
    public void Kill()
    {

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

    public void Move(float x, float z)
    {
        //transform.Translate( new Vector3(0.5f * x, 0.0f, 0.5f * z))  ;

        GetComponent<Rigidbody>().AddForce(new Vector3(x * 200.0f, 0, z * 200.0f));
        transform.LookAt(transform.position + new Vector3(x, 0.0f, z));
    }

    public MachineCore Gimmick()
    {
        HackState = HackStatus.HACKING;

        return null;
    }
}
