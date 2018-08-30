using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShoot : MonoBehaviour {

    private float timer = 0;
    public GameObject Bullet;
    public Transform Gun;
 
    [SerializeField]
    public float shootRate = 2;
    private float speed = 100;    //子弹速度
    private int gunnum = 0;
    private GameObject gun;
    private float fspeed = 30;
    public float waittime = 2;

    private void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickShoot;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickShootEnd;
        EasyJoystick.On_JoystickTap += OnJoystickQuickShoot;
    }

    private void OnDisable()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickShoot;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickShootEnd;
        EasyJoystick.On_JoystickTap -= OnJoystickQuickShoot;
    }

    private void OnDestroy()
    {
        EasyJoystick.On_JoystickMove -= OnJoystickShoot;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickShootEnd;
        EasyJoystick.On_JoystickTap -= OnJoystickQuickShoot;
    }

    private void OnJoystickQuickShoot(MovingJoystick move)
    {
        if (gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber > 0)
        {
            GameObject clone;
            clone = Instantiate(Bullet, Gun.position, Gun.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);
            gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber--;
        }
    }


    private void OnJoystickShoot(MovingJoystick move)
    {
        if (move.joystickName != "RightJoystick")
        {
            return;
        }

        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;

        if (joyPositionY != 0 || joyPositionX != 0)
        {
            
            gun = GameObject.Find("Player").transform.Find("PlayerGun").gameObject.transform.Find("Gun").gameObject;
            speed = gun.transform.GetComponent<PlayerWeapon>().weaponBulletSpeed;
            GameObject.Find("Player").transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            timer += Time.deltaTime;
            if (timer > 1 / shootRate)
            {
                timer -= 1 / shootRate;
                if (gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber > 0)
                {
                    GameObject clone;
                    clone = Instantiate(Bullet, Gun.position, Gun.rotation);
                    clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);
                    clone.transform.Rotate(0, 0, 90);
                    gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber--;
                    if(gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber==0)
                    {
                        StartCoroutine(Changebullet(waittime));
                        GetComponent<Animation>().CrossFade("Reload_standing");
                    }
                }
            }
        }       
    }

    private void OnJoystickShootEnd(MovingJoystick move)
    {
        if (move.joystickName == "RightJoystick")
        {
            return;
        }
    }

    IEnumerator Changebullet(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber = 30;
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
