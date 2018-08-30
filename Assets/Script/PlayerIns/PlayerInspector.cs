using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInspector : MonoBehaviour {

    public float hpmax=100;
    public float hp;
    public string name;
    public float damage=0;
    public PlayerWeapon playerWeapon;

	// Use this for initialization
	void Start () {
        damage+=playerWeapon.weaponDamage;
        hp = hpmax;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
