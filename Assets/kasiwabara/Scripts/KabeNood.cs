using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabeNood : MonoBehaviour {

    public float IdouSpeed = 0.1f;
    bool nood1 = false;
    bool nood2 = false;
    bool nood3 = false;
    bool nood4 = false;
    bool nood5 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (nood1 == true && nood2 == true && nood3 == true && nood4 == true && nood5 == true)
        {
            transform.Translate(this.IdouSpeed, 0, 0);
        }

        if (transform.position.x > 95.0f)
        {
            IdouSpeed = 0.0f;
        }
    }

    public void Addnood1()
    {
        nood1 = true;//nood1に当たった場合の処理
    }

    public void Addnood2()
    {
        nood2 = true;//nood2に当たった場合の処理
    }

    public void Addnood3()
    {
        nood3 = true;//nood3に当たった場合の処理
    }

    public void Addnood4()
    {
        nood4 = true;//nood4に当たった場合の処理
    }

    public void Addnood5()
    {
        nood5 = true;//nood5に当たった場合の処理
    }

}
