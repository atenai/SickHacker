using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Titlenimodoru : MonoBehaviour {

    public AudioClip kirikaeSE;
    AudioSource kirikaeaud;

    // Use this for initialization
    void Start () {
        this.kirikaeaud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown("0"))//もし1キーを押したら下の内容を実行
        //{
        //    SceneManager.LoadScene("Title");//ステージシーンに飛ぶ
        //}
        if (Input.GetKeyDown("return"))//もしエンターキーを押したら下の内容を実行
        {
            this.kirikaeaud.PlayOneShot(this.kirikaeSE);

            SceneManager.LoadScene("Title");//ステージシーンに飛ぶ
            //Fade.instance.FadeOut("Title");//Titleシーンに飛ぶ
        }
    }
}
