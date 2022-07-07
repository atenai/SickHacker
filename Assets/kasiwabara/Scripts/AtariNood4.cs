using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtariNood4 : MonoBehaviour {

    public KabeNood Kabenodo4;

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
            Kabenodo4.Addnood4();

            Destroy(gameObject);

        }
    }
}
