using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEstroyButtleTimeLong : MonoBehaviour {

    public GameObject buttle;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.name.Equals("Player"))
        {
            buttle.transform.GetComponent<DestroyBullet>().DestroyTime = 2.0f;
            Debug.Log(buttle.transform.GetComponent<DestroyBullet>().DestroyTime);
        }

    }

}
