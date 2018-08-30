using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float bulletNum = 20;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // gun = GameObject.Find("Player").transform.FindChild("PlayerGun").gameObject.transform.FindChild("Gun").gameObject.transform.GetComponent<PlayerWeapon>().weaponBulletNumber;
    }
    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.name.Equals("Player"))
        {
            GameObject.Find("Player").transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject.transform.GetComponent<PlayerWeapon>().weaponBulletNumber += bulletNum;
            Debug.Log("碰撞物体名：" + co.gameObject.name);
            //Destroy(co.gameObject);
            Destroy(this.gameObject);
        }

    }
}
