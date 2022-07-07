using UnityEngine;


public class ShotMachine :
    MachineCore,
    IKillable,      //殺用インターフェース
    IInfectable,    //感染インターフェース
    IActable,       //アクションインターフェース
    IMove,           //移動用インターフェース
    IGimmickable     //ギミック用インターフェース
{
    public GameObject BulletPrefab;

    public bool FallFlag;
    

    public float MoveSpeed;

    void Start()
    {
        on_Hack = false;

        Security_level = 50.0f;
        Erosion_level = 0.0f;

        FallFlag = false;


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

        if (FallFlag == true)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -300, 0));
        }

    }

    public void Action()
    {
        GameObject Bullet= Instantiate(BulletPrefab)as GameObject;

        MachineDeleteBullet DeleteBullet = Bullet.GetComponent<MachineDeleteBullet>();

        Debug.Log("弾撃ってます");
        if (DeleteBullet != null)
        {
            Quaternion Rot = transform.rotation;


            Debug.Log("弾生成してます");

            Vector3 Vector= transform.forward;

            Vector.Normalize();

            Vector3 Pos =transform.position + Vector*3;

            DeleteBullet.SetVector(Vector*0.4f);
            DeleteBullet.transform.position = Pos;
        }

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

        return GetComponent<MachineCore>();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Field")
        {
            FallFlag = false;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Field")
        {
            FallFlag = true;
        }
    }
}
