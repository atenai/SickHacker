using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HpBarCtrl : MonoBehaviour {


    Slider _slider;

    public float _hp;

    // Use this for initialization
    void Start () {
        //スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();

        _hp = 2.0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // HP減少
        //_hp -= 0.01f;
        if (_hp <= 0.0f)
        {
            // 最小を超えたら1に戻す
           // _hp = 1.0f;

            SceneManager.LoadScene("gameover");//ゲームオーバーシーンに飛ぶ
            //Fade.instance.FadeOut("gameover");//ゲームオーバーシーンに飛ぶ
            Destroy(gameObject);
        }

        if(_hp > 2.0f)
        {
            _hp = 2.0f;
        }

        // HPゲージに値を設定
        _slider.value = _hp;
    }

    public void AddHp(float add_hp)
    {
        _hp += add_hp;//回復アイテムに当たった場合の処理
    }

    public void DelHp(float del_hp)
    {
        _hp -= del_hp;//敵に当たった場合の処理
    }
}
