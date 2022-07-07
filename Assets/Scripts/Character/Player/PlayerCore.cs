using UnityEngine;
using System.Collections;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] PlayerParameter Parameter;
    [SerializeField] PlayerMover Mover;
    [SerializeField] PlayerAction Action;

    bool Hacking;

    MachineCore NearMachine;
    MachineCore RideMachine;

    int Count;
    Vector3 MoveVec;
    const int MoveFrame = 60;
    // Use this for initialization
    void Start()
    {
        RideMachine = Parameter.RideMachine;
        NearMachine = Parameter.GetNearDistance();

    }

    // Update is called once per frame
    void Update()
    {

        if (Hacking)
        {
            Count++;

            transform.position += MoveVec;

            transform.LookAt(transform.position + MoveVec);

            if (Count >= MoveFrame)
            {
                Hacking  = false;

                RideMachine = NearMachine;

                Parameter.RideMachine = RideMachine;

            }
            

        }

        else
        { 


            Mover.Move(Parameter.RideMachine);

            NearMachine = Parameter.GetNearDistance();

            Action.machineCore = RideMachine;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Action0"))
            {
                Action.IsAction();
            }

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("Action1"))
            {

                if (NearMachine == null)
                {
                    return;
                }

                IGimmickable Gimick = NearMachine.GetComponent<IGimmickable>();

                if (Gimick != null)
                {
                    MachineCore GimmickMachine = Gimick.Gimmick();

                    if (GimmickMachine != null)
                    {
                        Hacking = true;

                        RideMachine = GimmickMachine;

                        MoveVec = RideMachine.transform.position - transform.position;


                        MoveVec /= MoveFrame;

                        Count = 0;
                    }

                }
            }

        }
    }
}
