using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectScene : MonoBehaviour//スクリプト名と合わせる
{

    [SerializeField] Image stage1;
    [SerializeField] Image stage2;
    [SerializeField] Image stage3;
    int kazu = 1;

    [SerializeField] AudioSource Selectaud;
    [SerializeField] AudioClip SelectSE;

    void Start()
    {

    }

    void Update()
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
                Fade.instance.FadeOut("Stage1");//ステージ1シーンに飛ぶ
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
                Fade.instance.FadeOut("Stage2");//ステージ2シーンに飛ぶ
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
                Fade.instance.FadeOut("Stage2");//gameシーンに飛ぶ
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
}
