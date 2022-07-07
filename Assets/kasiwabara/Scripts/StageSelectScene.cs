using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectScene : MonoBehaviour//スクリプト名と合わせる
{

    public Image stage1;
    public Image stage2;
    public Image stage3;
    int kazu = 1;

    public AudioClip SelectSE;
    AudioSource Selectaud;

    // Use this for initialization
    void Start ()
    {
        this.Selectaud = GetComponent<AudioSource>();
        stage1 = GameObject.Find("Image(maru)").GetComponent<Image>();//上で作ったImage型のstage1にImage(maru)を見つけてImageクラスの機能を入れる
        stage2 = GameObject.Find("Image(sikaku)").GetComponent<Image>();//上で作ったImage型のstage2にImage(sikaku)を見つけてImageクラスの機能を入れる
        stage3 = GameObject.Find("Image(game)").GetComponent<Image>();//上で作ったImage型のstage3にImage(game)を見つけてImageクラスの機能を入れる
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.A))//もし左矢印キーを押したら下の内容を実行
        {
            kazu = kazu - 1;
        }

        if (Input.GetKeyDown(KeyCode.D))//もし右矢印キーを押したら下の内容を実行
        {
            kazu = kazu + 1;
        }

        if (kazu == 1)//ステージ1を選択中
        {
            stage1.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);//ステージ1の色を変える
            stage2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ステージ2の色を変える
            stage3.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ステージ3の色を変える

            if (Input.GetKeyDown("return"))//もしエンターキーを押したら下の内容を実行
            {
                this.Selectaud.PlayOneShot(this.SelectSE);

                ChangeStage1Select();//ステージ1シーンに飛ぶ
            }
        }
        else if (kazu == 2)//ステージ2を選択中
        {
            stage1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ステージ1の色を変える
            stage2.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);//ステージ2の色を変える
            stage3.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ステージ3の色を変える

            if (Input.GetKeyDown("return"))//もしエンターキーを押したら下の内容を実行
            {
                this.Selectaud.PlayOneShot(this.SelectSE);
                ChangeStage2Select();//ステージ2シーンに飛ぶ
                //SceneManager.LoadScene("stage2");//ステージ2シーンに飛ぶ
            }
        }
        else if (kazu == 3)//ステージ3を選択中
        {
            stage1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ステージ1の色を変える
            stage2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//ステージ2の色を変える
            stage3.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);//ステージ3の色を変える

            if (Input.GetKeyDown("return"))//もしエンターキーを押したら下の内容を実行
            {
                this.Selectaud.PlayOneShot(this.SelectSE);
                ChangeStage3Select();//ステージ3シーンに飛ぶ
                //SceneManager.LoadScene("stage3");//ステージ3シーンに飛ぶ
            }
        }
        else if (kazu == 4)
        {
            kazu = 1;
        }
        else if (kazu == 0)
        {
            kazu = 3;
        }
    }

    public void ChangeStage1Select()//関数定義(この関数を使う)
    {
        Fade.instance.FadeOut("stage1");//ステージ1シーンに飛ぶ
    }

    public void ChangeStage2Select()//関数定義(この関数を使う)
    {
        Fade.instance.FadeOut("stage2");//ステージ2シーンに飛ぶ
    }

    public void ChangeStage3Select()//関数定義(この関数を使う)
    {
        Fade.instance.FadeOut("game");//gameシーンに飛ぶ
    }
}
