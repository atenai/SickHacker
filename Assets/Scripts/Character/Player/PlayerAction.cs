using UnityEngine;
using System.Collections;

public class PlayerAction : BasePlayerComponent
{
    public MachineCore machineCore;

    bool ActTrigger;
    float CoolTime;

    private void Start()
    {
        ActTrigger = false;
    }

    public void IsAction()
    {
        IActable action;

        action =  machineCore.GetComponent<IActable>();

        if (action != null)
        {
            action.Action();
        }
    }
}
