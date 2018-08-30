using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGun : MonoBehaviour {
    private GameObject gb;
    public GameObject Weapon0;
    public GameObject Weapon1;
    private GameObject CurrentWeapon;
    private GameObject NextWeapon;
    public GameObject gun;
    public GameObject gun2;
    private float WeaponSort = 0;
    private string FrontText1 = "切换武器为:";
    private string FrontText2 = "目前武器名称/顺序:";

    private void OnEnable()
    {
        EasyButton.On_ButtonUp += ChangeWeaspon;
    }

    private void OnDisable()
    {
        EasyButton.On_ButtonUp -= ChangeWeaspon;
    }

    private void ChangeShort(string buttonName)
    {
        
    }

    private void ChangeWeaspon(string button)
    {

        if (WeaponSort == 0)
        {
            CurrentWeapon = Weapon0;
            NextWeapon = Weapon1;
            Weapon0.active = true;
            Weapon1.active = false;
            Debug.Log("change0");
            WeaponSort=1;

            gun = gb.transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject;
            gun2 = GameObject.Find("StandardGun").gameObject.transform.Find("AK47").gameObject;
            ChangeGuns(gun, gun2);

            GameObject.Find("Player").gameObject.transform.Find("PlayerGun").gameObject.transform.GetComponent<MoveShoot>().enabled = false;
            GameObject.Find("Player").gameObject.transform.Find("PlayerGun").gameObject.transform.GetComponent<JuJi>().enabled = true;
            LineRenderer LR = gameObject.GetComponent<LineRenderer>();
            LR.enabled = true;
        }
        else if (WeaponSort == 1)
        {
            CurrentWeapon = Weapon1;
            NextWeapon = Weapon0;
            Weapon0.active = false;
            Weapon1.active = true;
            Debug.Log("change1");
            WeaponSort=0;

            gun = gb.transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject;
            gun2 = GameObject.Find("StandardGun").gameObject.transform.Find("M4A1").gameObject;
            ChangeGuns(gun, gun2);

            GameObject.Find("Player").gameObject.transform.Find("PlayerGun").gameObject.transform.GetComponent<MoveShoot>().enabled = true;
            GameObject.Find("Player").gameObject.transform.Find("PlayerGun").gameObject.transform.GetComponent<JuJi>().enabled = false;
            LineRenderer LR = gameObject.GetComponent<LineRenderer>();
            LR.enabled = false;
        }
        
    }

    // Use this for initialization
    void Start () {
        gb = GameObject.Find("Player");
        gun = gb.transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject;
        gun2 = GameObject.Find("M4A1").gameObject;
        ChangeGuns(gun, gun2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void ChangeGuns(GameObject gun, GameObject gun2)//更换武器
    {

        gun.transform.GetComponent<PlayerWeapon>().weaponName = gun2.transform.GetComponent<Weapon>().weaponName;
        gun.transform.GetComponent<PlayerWeapon>().weaponDamage = gun2.transform.GetComponent<Weapon>().weaponDamage;
        gun.transform.GetComponent<PlayerWeapon>().weaponShotSpeed = gun2.transform.GetComponent<Weapon>().weaponShotSpeed;
        gun.transform.GetComponent<PlayerWeapon>().weaponBulletType = gun2.transform.GetComponent<Weapon>().weaponBulletType;
        gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber = gun2.transform.GetComponent<Weapon>().weaponBulletNumber;
        gun.transform.GetComponent<PlayerWeapon>().weaponRange = gun2.transform.GetComponent<Weapon>().weaponRange;
        gun.transform.GetComponent<PlayerWeapon>().weaponBulletSpeed = gun2.transform.GetComponent<Weapon>().weaponBulletSpeed;
    }
}

