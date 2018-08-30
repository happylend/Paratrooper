using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private SpriteSlider hp;
    private uint value=1;

	// Use this for initialization
	void Start () {
        hp = GetComponentInChildren<SpriteSlider>();
        Init();
	}

    public void Init()
    {
        hp.Value = value;
    }

    public void TakeDamage(float damage)
    {
        hp.Value -= damage;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
