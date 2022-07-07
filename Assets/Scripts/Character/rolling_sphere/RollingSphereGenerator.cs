using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RollingSphereGenerator : MonoBehaviour
{
    public GameObject RollingSpherePrefab;

    //GameObject o_RollingSphere;//転がる岩。
    GameObject[] o_RollingSphere = new GameObject[4];//転がる岩配列で生成。

    GameObject o_PlayerController;//プレイヤーオブジェクト連れてくる。
    bool InstanceFlag;//インスタンス生成フラグ
    int nCount;//この世界の時間

    void Start()
    {
        o_PlayerController = GameObject.Find("Player");//プレイヤオブジェクト連れてくる。
        InstanceFlag = true;
    }

    void Update()
    {
        nCount++;//世界の時間の更新
        if (nCount > 600 && InstanceFlag == false)//世界の時間が３００↑かつ、インスタンス生成フラグOFFの場合デストロイ。
        {
            for(int n = 0; n < 4; n++)
            {
                Destroy(o_RollingSphere[n]);//転がる岩の削除
            }
            InstanceFlag = true;//Instance生成フラグON
            nCount = 0;
        }

        if (nCount > 100 && o_RollingSphere != null)//転がるタマ存在する場合移動。
        {
            //o_RollingSphere[0].transform.position += new Vector3(0.05f, 0.0f, 0.0f);
        }

        if (InstanceFlag == true)
        {
            nCount = 0;
            InstanceFlag = false;
            o_RollingSphere[0] = Instantiate(RollingSpherePrefab) as GameObject;
            o_RollingSphere[0].transform.position = new Vector3(-10.0f, 20.6f, 15.7f);

            o_RollingSphere[1] = Instantiate(RollingSpherePrefab) as GameObject;
            o_RollingSphere[1].transform.position = new Vector3(25.0f, 20.6f, 55.7f);

            o_RollingSphere[2] = Instantiate(RollingSpherePrefab) as GameObject;
            o_RollingSphere[2].transform.position = new Vector3(25.0f, 20.6f, 95.7f);

            o_RollingSphere[3] = Instantiate(RollingSpherePrefab) as GameObject;
            o_RollingSphere[3].transform.position = new Vector3(-3.0f, 20.6f, 117.0f);
        }
    }
}
