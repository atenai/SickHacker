using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UI_PopUp : MonoBehaviour {

    /// <summary>
    /// ポップアップする時間
    /// </summary>
    [SerializeField] float popUpTime = 0.5f;

    /// <summary>
    /// タイマー
    /// </summary>
    private float timer = 0.0f;

    /// <summary>
    /// 大きさ（widthとheight）
    /// </summary>
    Vector2 size;

    private RectTransform rectTransform;
    

    //初期化
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        size = rectTransform.sizeDelta;
    }

    //更新
    void Update()
    {
        //タイマーを進める
        timer += Time.deltaTime;

        //タイマーが一定量進んだらコンポーネント消去
        if (timer > popUpTime)
        {
            Destroy(this);
            return;
        }

        //ポップアップ処理
        rectTransform.sizeDelta = size * ( timer / popUpTime);

    }
}
