using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    /// <summary>
    /// シングルトン
    /// </summary>
    private static Fade Instance;
    public static Fade instance
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


    private enum Phase
    {
        eNeutral,
        eFadeOut,
        eFadeIn
    }
    Fade.Phase phase = Phase.eNeutral;

    /// <summary>
    /// フェード時間
    /// </summary>
    [SerializeField] float fadeTime;

    /// <summary>
    /// フェードアウトからフェードインまでの待機時間
    /// </summary>
    [SerializeField] float waitTime;

    /// <summary>
    /// フェードイン・アウトするImage
    /// </summary>
    [SerializeField] Image image;

    /// <summary>
    /// 次のシーン名
    /// </summary>
    private string sceneName;

    private float timer = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (phase == Phase.eNeutral)
        {
            return;
        }

        //タイマーの更新
        timer += Time.deltaTime;
		
        //フェードアウト
        if( phase == Phase.eFadeOut)
        {
            if( timer > fadeTime + waitTime)
            {
                FadeIn();
                timer = 0.0f;
                SetAlpha(1.0f);
                return;
            }

            SetAlpha( timer / fadeTime);
        }

        //フェードイン
        else if (phase == Phase.eFadeIn)
        {
            if (timer > fadeTime)
            {
                phase = Phase.eNeutral;
                timer = 0.0f;
                SetAlpha(0.0f);
                return;
            }

            SetAlpha(1.0f - timer / fadeTime);
        }

    }

    /// <summary>
    /// フェードアウト
    /// </summary>
    /// <returns></returns>
    public bool FadeOut( string nextSceneName)
    {
        if( phase != Phase.eNeutral)
        {
            return false;
        }

        phase = Phase.eFadeOut;
        sceneName = nextSceneName;

        return true;
    }

    /// <summary>
    /// フェードイン
    /// </summary>
    /// <returns></returns>
    public bool FadeIn()
    {
        if (phase != Phase.eFadeOut)
        {
            return false;
        }

        phase = Phase.eFadeIn;
        SceneManager.LoadScene(sceneName);
        sceneName = string.Empty;

        return true;
    }

    /// <summary>
    /// α値を設定
    /// </summary>
    /// <param name="a"></param>
    private void SetAlpha( float a)
    {
        var color = image.color;
        color.a = a;
        image.color = color;
        
    }
}
