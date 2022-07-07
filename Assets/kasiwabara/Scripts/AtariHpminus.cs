using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtariHpminus : MachineCore, IKillable
{

    HpBarCtrl HPminus;

    // Use this for initialization
    void Start () {
        HPminus = GameObject.Find("Canvas/Slider").GetComponent<HpBarCtrl>();//ゲームオブジェクトのzikanの中にあるコンポーネントのTimerを上で作ったtimerに入れる
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Kill()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")//当たってきたゲームオブジェクトのタグがPlayerなら下の内容を実行する
        {

            HPminus.DelHp(1.0f);//Timer.csのAddTimerに10.0fを入れる

           // Destroy(gameObject);

        }
    }
}
