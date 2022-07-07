using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//C++で言うヘッダーをインクルードするみたいなもの。

public class RollingSphere_Collision : MonoBehaviour
{
    GameObject o_PlayerController;
    HpBarCtrl HPminus;

    // Use this for initialization
    void Start()
    {
        o_PlayerController = GameObject.Find("Player");
        HPminus = GameObject.Find("Canvas/Slider").GetComponent<HpBarCtrl>();//ゲームオブジェクトのzikanの中にあるコンポーネントのTimerを上で作ったtimerに入れる
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")//プレイヤーと当たったとき
        //if (other == o_PlayerController)//プレイヤーと当たったとき
        {
            HPminus.DelHp(1.0f);//Timer.csのAddTimerに10.0fを入れる
                                // SceneManager.LoadScene("gameover");//ゲームオーバーシーンに飛ぶ
                                //GameSceneManager.instance.GameOver();//多分ゲームオーバー処理。
        }
    }


}
