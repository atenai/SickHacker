using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atari2Nood5 : MonoBehaviour {
    public KabeNood2 KabeNood2;
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
            KabeNood2.AddnoodIdou5();

            Destroy(gameObject);

        }
    }
}
