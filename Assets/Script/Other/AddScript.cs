using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScript : MonoBehaviour {

    void Awake()
    {
        GameObject.Find("Enviroment").transform.Find("Tan_Terrain").gameObject.AddComponent<DestroyBullet>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("Tan_Terrain").AddComponent<DestroyBullet>();
    }
}
