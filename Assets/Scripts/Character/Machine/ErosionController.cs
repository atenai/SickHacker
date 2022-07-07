using UnityEngine;


public class ErosionController : MonoBehaviour
{

    private GameObject _child;

    [SerializeField] public float Security_level = 100.0f;
    [SerializeField] public float Erosion_level = 0;
    [SerializeField] public bool on_Hack = false;
   

    /// <summary>
    /// 移動速度
    /// </summary>

    /// <summary>
    /// ジャンプフラグ
    /// </summary>
    private bool canJump;

    Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        canJump = false;
        Security_level = 100.0f;
        rigidbody = GetComponent<Rigidbody>();
        _child = transform.Find("Cube").gameObject;
        //Debug.Log("Child is:" + _child.name);

    }

    public void Erosion()
    {
      //  Debug.Log("感染！！");
        if (Security_level > Erosion_level)
        {
            Erosion_level += 0.5f;
          //  Debug.Log("感染中ですよ！！");
        }
        else if (Security_level <= Erosion_level  && on_Hack == false)
        {
            on_Hack = true;
           _child.GetComponent<Renderer>().material.color =new Color(0, 255, 0);
            transform.Find("MachineState").gameObject.tag = "Hack";
            // Debug.Log("感染完了ですよ！！");
        }
    }

    // Update is called once per frame



    void Update()
    {
      
    }


    /// <summary>
    /// RigidBody同士の衝突処理（衝突中）
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Field")
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
          //  Debug.Log("地面ですよ！！");
        }
       

    }

    /// <summary>
    /// 衝突処理（衝突中）
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log("なにか触れています！！");
        if (other.tag == "InfectionArea")
        {

          //  Debug.Log("エリアに触れています！！");
            Erosion();
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

        
    }
}