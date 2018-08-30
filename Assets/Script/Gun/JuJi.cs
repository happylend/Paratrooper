using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuJi : MonoBehaviour {

    LineRenderer reader;
    Ray ray;
    RaycastHit hit;
    private float timer = 0;
    public GameObject Bullet;
    public Transform Gun;
    private GameObject gb;
    private ParticleSystem particleSystem;


    [SerializeField]
    private float speed = 100;    //子弹速度
    private int gunnum = 0;
    private GameObject gun;
    private float fspeed = 30;

    public void OnEnable()
    {
        EasyJoystick.On_JoystickMove += OnJoystickAim;
        EasyJoystick.On_JoystickTouchUp += OnJoystickBang;
        EasyJoystick.On_JoystickMoveEnd += OnJoystickBangEnd;
    }


    public void OnDisable()
    {
        EasyJoystick.On_JoystickTouchUp -= OnJoystickBang;
        EasyJoystick.On_JoystickMove -= OnJoystickAim;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickBangEnd;
    }

    private void OnDestroy()
    {
        EasyJoystick.On_JoystickTouchUp -= OnJoystickBang;
        EasyJoystick.On_JoystickMove -= OnJoystickAim;
        EasyJoystick.On_JoystickMoveEnd -= OnJoystickBangEnd;
    }

    private void OnJoystickBangEnd(MovingJoystick move)
    {
        if (move.joystickName == "RightJoystick")
        {
            return;
        }
    }

    private void OnJoystickBang(MovingJoystick move)
    {
        if (move.joystickName != "RightJoystick")
        {
            return;
        }
        gun=GameObject.Find("Player").transform.Find("PlayerGun").transform.Find("Gun").gameObject;
        if (gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber > 0)
        {
            GameObject clone;
            clone = Instantiate(Bullet, Gun.position, Gun.rotation);
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * speed);
            gun.transform.GetComponent<PlayerWeapon>().weaponBulletNumber--;
        }
        GameObject.Find("Player").GetComponent<MoveController>().enabled = true;
    }

    private void OnJoystickAim(MovingJoystick move)
    {
        if (move.joystickName != "RightJoystick")
        {
            return;
        }

        float joyPositionX = move.joystickAxis.x;
        float joyPositionY = move.joystickAxis.y;

        if (joyPositionY != 0 || joyPositionX != 0)
        {
            GameObject.Find("Player").transform.LookAt(new Vector3(transform.position.x + joyPositionX, transform.position.y, transform.position.z + joyPositionY));
            reader.SetVertexCount(2);
            reader.SetWidth(0.6f, 0.6f);
            reader.SetColors(Color.red, Color.red);
            reader.SetPosition(0, transform.position);
            GameObject.Find("Player").GetComponent<MoveController>().enabled = false;
        }
    }

    void Awake()
    {
        reader = GetComponent<LineRenderer>();
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        reader = GameObject.Find("Player").GetComponent<LineRenderer>();
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            reader.SetPosition(1, hit.point);
        }
        else
        {
            reader.SetPosition(1, ray.direction * 1000 - transform.position);
        }
    }
}
