using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnCollisionEnter(Collision other)//あたり判定
    //{
    //    SceneManager.LoadScene("gameclear");//ゲームクリアシーンに飛ぶ
    //    //Fade.instance.FadeOut("gameclear");//ゲームクリアシーンに飛ぶ
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")//当たってきたゲームオブジェクトのタグがPlayerなら下の内容を実行する
        {
            SceneManager.LoadScene("gameclear");//ゲームクリアシーンに飛ぶ

            Destroy(gameObject);

        }
    }
}
