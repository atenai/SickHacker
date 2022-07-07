using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour {

    public static float time;
    Text hidariueUI;//テキスト型の変数
    int t;

    // Use this for initialization
    void Start ()
    {
        time = 100;
    }
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;//ゲームループのタイマーを上で作ったtimeに＋していく

        t = Mathf.FloorToInt(time);//float型のタイマーをint型に変換させるやつ(小数点以下を切り捨てる)
        hidariueUI = GetComponent<Text>();//右のコンポートからテキストコンポートを探しhidariueUIに入れる
        hidariueUI.text = "Timer:" + t;//hidariueUIのテキストを"Timer:"と書き換え+タイムを入れる

        if (t == 0)
        {
            SceneManager.LoadScene("gameover");//ゲームオーバーシーンに飛ぶ
            //Fade.instance.FadeOut("gameover");//ゲームオーバーシーンに飛ぶ
            Destroy(gameObject);
        }
    }

    public void AddTimer(float add_timer)
    {
        time += add_timer;//タイム＋アイテムに当たった場合の処理
    }

}
