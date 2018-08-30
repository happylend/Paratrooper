using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour {

    public float DestroyTime=1.0f;
	// Use this for initialization
	void Start () {
        Invoke("DestroyButtle", DestroyTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }

    void DestroyButtle()
    {
        Destroy(this.gameObject);
    }
}
