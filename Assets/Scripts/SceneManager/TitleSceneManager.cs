using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    /// <summary>
    /// シングルトン
    /// </summary>
    private static TitleSceneManager Instance;

    public AudioClip TitleSE;
    AudioSource Titleaud;

    public static TitleSceneManager instance
    {
        get { return Instance; }
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    //変数宣言


    //初期化
    void Start()
    {
        this.Titleaud = GetComponent<AudioSource>();
    }

    //更新
    void Update()
    {
        
    }

    /// <summary>
    /// Gameシーンに遷移
    /// </summary>
    public void ChangeSceneGame()
    {
        this.Titleaud.PlayOneShot(this.TitleSE);
        Fade.instance.FadeOut("StageSelect");
    }
}
