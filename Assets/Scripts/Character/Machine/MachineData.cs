using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineData : MonoBehaviour
{
    [SerializeField] public  float moveSpeed = 1.0f;

    /// <summary>
    /// 空中での移動速度
    /// </summary>
    [SerializeField] public  float flySpeed = 0.5f;

    /// <summary>
    /// ジャンプ力
    /// </summary>
    [SerializeField] public float jumpPower = 1.0f;

    // Use this for initialization    

    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
