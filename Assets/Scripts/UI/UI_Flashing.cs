using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Flashing : MonoBehaviour {

    /// <summary>
    /// 点滅する間隔
    /// </summary>
    [SerializeField] float flashingSpan = 0.5f;

    /// <summary>
    /// Textコンポーネント
    /// </summary>
    [SerializeField] Text text = null;

    /// <summary>
    /// Imageコンポーネント
    /// </summary>
    [SerializeField] Image image = null;

    /// <summary>
    /// タイマー
    /// </summary>
    private float timer = 0.0f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //タイマーを進める
        timer += Time.deltaTime;

        //タイマーが一定量進んだら点滅処理
        if( timer > flashingSpan)
        {
            timer = 0.0f;

            FlashingText();
            FlashingImage();
        }
	}

    /// <summary>
    /// テキストを点滅させる
    /// </summary>
    private void FlashingText( )
    {
        if( !text)
        {
            return;
        }

        //点滅処理
        if( text.enabled)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }
    }

    /// <summary>
    /// 画像を点滅させる
    /// </summary>
    private void FlashingImage()
    {
        if (!image)
        {
            return;
        }

        //点滅処理
        if (image.enabled)
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }
    }

}
