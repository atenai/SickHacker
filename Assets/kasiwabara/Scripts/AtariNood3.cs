using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtariNood3 : MonoBehaviour {

    public KabeNood Kabenodo3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")//当たってきたゲームオブジェクトのタグがPlayerなら下の内容を実行する
        {
            Kabenodo3.Addnood3();

            Destroy(gameObject);

        }
    }
}
