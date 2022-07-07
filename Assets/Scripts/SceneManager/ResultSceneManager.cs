using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    /// <summary>
    /// シングルトン
    /// </summary>
    private static ResultSceneManager Instance;
    public static ResultSceneManager instance
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

    }

    //更新
    void Update()
    {
        
    }

    /// <summary>
    /// Titleシーンに遷移
    /// </summary>
    public void ChangeSceneTitle()
    {
        Fade.instance.FadeOut("Title");
    }
}
