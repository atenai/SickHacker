using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    /// <summary>
    /// シングルトン
    /// </summary>
    private static GameSceneManager Instance;
    public static GameSceneManager instance
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
    /// ゲームクリア
    /// </summary>
    public void GameClear( )
    {
        ChangeSceneResult();
    }

    /// <summary>
    /// ゲームオーバー
    /// </summary>
    public void GameOver( )
    {
        ChangeSceneResult();
    }

    /// <summary>
    /// Resultシーンに遷移
    /// </summary>
    public void ChangeSceneResult( )
    {
        Fade.instance.FadeOut("Result");
    }
    

}
