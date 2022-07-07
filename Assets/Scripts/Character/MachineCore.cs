using UnityEngine;


public abstract class MachineCore : MonoBehaviour
{
    private GameObject _child;

    [SerializeField] public float Security_level = 100.0f;
    [SerializeField] public float Erosion_level = 0;
    [SerializeField] public bool  on_Hack = false;

    public enum SickStatis
    {
        HEALTHY,
        SICK,
        HARD_SICK,
        VERYHARD_SICK,
    }
    public SickStatis Sickstate;

    public enum MachineStatus
    {
        STAY,       //待機状態
        WALK,       //歩き
        SEARCH,     //探索
        RUN,        //急ぐ
        WARNING,    //警戒
        ACTION,     //アクション
        DAMAGE,     //DAMAGE受けたとき
    }
    [SerializeField]  public MachineStatus MachineState;

    public enum HackStatus
    {
        UNHACK,
        HACKING,
        HACK,
    }

    public HackStatus HackState;

    
}