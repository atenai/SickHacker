using UnityEngine;
using System.Collections;

public　abstract class BaseAction : MonoBehaviour
{
    public int CoolTimeSecond;
    public bool ActionFlag;

    public abstract void Action();
    
}
