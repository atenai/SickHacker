using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabeNood2 : MonoBehaviour {

    public float IdouSpeed = 0.1f;
    bool noodIdou1 = false;
    bool noodIdou2 = false;
    bool noodIdou3 = false;
    bool noodIdou4 = false;
    bool noodIdou5 = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (noodIdou1 == true && noodIdou2 == true && noodIdou3 == true && noodIdou4 == true && noodIdou5 == true)
        {
            transform.Translate(this.IdouSpeed, 0, 0);
        }

        if (transform.position.x > 40.0f)
        {
            IdouSpeed = 0.0f;
        }
    }

    public void AddnoodIdou1()
    {
       // Destroy(gameObject);
        noodIdou1 = true;
    }
    public void AddnoodIdou2()
    {
        // Destroy(gameObject);
        noodIdou2 = true;
    }
    public void AddnoodIdou3()
    {
        // Destroy(gameObject);
        noodIdou3 = true;
    }
    public void AddnoodIdou4()
    {
        // Destroy(gameObject);
        noodIdou4 = true;
    }
    public void AddnoodIdou5()
    {
        // Destroy(gameObject);
        noodIdou5 = true;
    }
}
