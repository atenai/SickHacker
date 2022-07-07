using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IwaGenerator : MonoBehaviour {

    public GameObject IwaPrefab;
    float span = 0.1f;
    float delta = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item = Instantiate(IwaPrefab) as GameObject;
            float x = Random.Range(-90,65);//0～-30
            float z = Random.Range(20, 210);//110～170
            item.transform.position = new Vector3(x, 20, z);
        }
    }
}
