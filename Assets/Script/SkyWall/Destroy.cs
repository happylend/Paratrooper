using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    [SerializeField]
    public GameObject cube;
    public GameObject SkyWall;
    public GameObject Wall;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(cube==null)
        {
            Destroy(SkyWall);
            Destroy(Wall);
            //Destroy(GameObject.Find("Enviroment").transform.Find("Tan_SkyWall").gameObject.transform.Find("tan_right").gameObject);
            Destroy(this);
        }
	}


}
