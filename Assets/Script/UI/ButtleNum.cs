using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleNum : MonoBehaviour {

    private float BNum = 0;
    private float SunBNum = 0;
    private string GunName;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        BNum = GameObject.Find("/Player/PlayerGun/Gun").transform.GetComponent<PlayerWeapon>().weaponBulletNumber;
    }

    private void OnGUI()
    {
        //获取当前枪支名
        GunName = GameObject.Find("/Player/PlayerGun/Gun").transform.GetComponent<PlayerWeapon>().weaponName;
        //获取枪支最大子弹数
        if(GunName=="M4A1")
        {
            SunBNum = 30;
        }
        else if(GunName=="AK47")
        {
            SunBNum = 50;
        }
        //绘制
        GUI.Label(new Rect(10, 10, 100, 200), "当前子弹:" + BNum + "/" + SunBNum);
    }
}
