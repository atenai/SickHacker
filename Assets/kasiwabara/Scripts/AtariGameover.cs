using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AtariGameover : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
    // Update is called once per frame
	void Update ()
    {
		
	}

    //public void Kill()
    //{
    //    Destroy(gameObject);
    //}

    //private void OnTriggerExit(Collider other)//あたり判定
    //{
    //    if (other.tag =="Player") {
    //        SceneManager.LoadScene("gameover");//ゲームオーバーシーンに飛ぶ
    //                                           //Fade.instance.FadeOut("gameover");//ゲームオーバーシーンに飛ぶ
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")//当たってきたゲームオブジェクトのタグがPlayerなら下の内容を実行する
        {

            SceneManager.LoadScene("gameover");//ゲームオーバーシーンに飛ぶ

            // Destroy(gameObject);

        }
    }

}
