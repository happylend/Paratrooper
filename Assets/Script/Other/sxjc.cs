using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sxjc : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    // 创建射线到屏幕上的参考点，像素坐标  
 //   Vector3 position = new Vector3(Screen.width / 2.0f, Screen.height / 2.0f, 0.0f);

    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            //按下鼠标左键发射一条射线
            ray = new Ray(transform.position, transform.forward);
            //游戏对象的坐标为起点，right为方向
            if (Physics.Raycast(ray,out hit,Mathf.Infinity))
            {
                Debug.Log("碰撞对象："+hit.collider.name);
                Debug.DrawLine(ray.origin,hit.point,Color.blue);
                if (!hit.collider.name.Equals("Terrain"))
                {
                    Destroy(hit.collider.gameObject);
                }

            }
        }
    }
}
