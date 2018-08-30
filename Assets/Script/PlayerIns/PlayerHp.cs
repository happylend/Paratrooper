using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHp : MonoBehaviour {

    [SerializeField]
    private float hpmax = 100;
    private float hp;
    private float damage;
    private GameObject gun;

    void Start()
    {
        hp = hpmax;
    }

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.name.Equals("butlle(Clone)"))
        {
            Debug.Log("碰撞物体名：" + co.gameObject.name);
            gun = GameObject.Find("Player").transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject;
            damage = gun.GetComponent<PlayerWeapon>().weaponDamage;
            hp = hp - damage;
            Debug.Log("碰撞物体名：" + hp);

        }
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
