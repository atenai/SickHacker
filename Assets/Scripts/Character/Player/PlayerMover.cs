using UnityEngine;
using System.Collections;

public class PlayerMover : BasePlayerComponent
{

   // MachineCore[] MachineCores = new MachineCore[10]; 
    //GameObject[] MoveObject = new GameObject[10];

    [SerializeField] MachineCore Select;

    [SerializeField] int select = 0;
   
    // Use this for initialization
    Vector3 MoveValue;

    

    private void Start()
    {
      
    }
    public void Move(MachineCore SelectMachine)
    {
        //入力による移動
        MoveValue = Vector3.zero;

        Select = SelectMachine;

        //地上
        MoveValue.x = Input.GetAxis("Horizontal");
        MoveValue.z = Input.GetAxis("Vertical");
        //空中

        //ジャンプ

        //移動量の更新
        //rigidbody.AddForce(moveValue);

         IMove MachineMove= SelectMachine.GetComponent<IMove>();

        if (MachineMove != null)
        {
            MachineMove.Move(MoveValue.x, MoveValue.z);
        }

        transform.position = SelectMachine.GetComponent<Transform>().position;

        //方向の更新
        {
          MoveValue.y = 0.0f;
          transform.LookAt(transform.position + MoveValue);


            GetComponent<Transform>().LookAt(transform.position + MoveValue);

           // MoveValue = Vector3.zero;
            //GetComponent<Rigidbody>().AddForce(MoveValue);

        }
    }


    // Update is called once per frame

}
