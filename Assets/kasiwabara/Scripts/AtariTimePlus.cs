using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtariTimePlus : MonoBehaviour {

    GameTime timer;

    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Canvas/zikan").GetComponent<GameTime>();//ゲームオブジェクトのzikanの中にあるコンポーネントのTimerを上で作ったtimerに入れる
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")//当たってきたゲームオブジェクトのタグがPlayerなら下の内容を実行する
        {

            timer.AddTimer(10.0f);//Timer.csのAddTimerに10.0fを入れる

            Destroy(gameObject);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
