using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class raxtuka : MonoBehaviour {
    public float dropSpeed = -1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, this.dropSpeed, 0);
        if (transform.position.y < -3.0f)
        {
            Destroy(gameObject);
        }
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.gameObject.tag == "Player")//当たってきたゲームオブジェクトのタグがPlayerなら下の内容を実行する
    //    {

    //        SceneManager.LoadScene("gameover");//ゲームオーバーシーンに飛ぶ

    //        Destroy(gameObject);

    //    }
    //}
}
