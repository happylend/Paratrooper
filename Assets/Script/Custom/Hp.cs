using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour {

    [SerializeField]
    private float hpmax = 100;
    private float hp;
    private float damage;
    private GameObject gun;
    public GameObject buttle;
//    public GameObject popupDamageGo;

    void Start()
    {
        hp = hpmax;
    }

    void OnCollisionEnter(Collision co)
    {
        if (GameObject.FindWithTag("playerbuttle"))
        //if (co.gameObject.name.Equals("butlle(Clone)"))
        {
            Debug.Log("碰撞物体名：" + co.gameObject.name);
            gun = GameObject.Find("Player").transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject;
            damage = gun.GetComponent<PlayerWeapon>().weaponDamage;
            hp = hp - damage;
            Debug.Log("剩余生命值：" + hp);
//            GameObject damageGo = Instantiate(popupDamageGo, transform.position + new Vector3(0, 10, 0), Quaternion.identity) as GameObject;
//            damageGo.GetComponent<ShowDamage>().Value = (int)damage;

        }
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}

