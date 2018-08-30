using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {

    // Use this for initialization
    void Update()
    {
        RayToFindMethod("game");//  
    }
    void RayToFindMethod(string tags)//定义一个私有的,无返回值,有参数的方法  参数为你想找到的游戏对象的标签(Tag)  
    {
        
        if (Input.touchCount == 1)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);//实例化从摄像机到鼠标的摄像  
                RaycastHit hit;//这个为射线命中的点  
                if (Physics.Raycast(ray, out hit))
                {//物理静态类中的光线投射方法 ->  意义:射线投射出  "得到射线命中的点(hit)"  
                    if (hit.transform.CompareTag(tags))
                    {//如果射线命中的点的标签(Tag)值为 tags -> 即:外部传入的参数(你想要找到的游戏对象的标签)  并把hit射线命中的点的类型转换为transform类型  
                        Debug.Log(hit.transform.name);
                        Application.LoadLevel("mainScene");//为真执行输出射线命中点的名字  
                    }
                }// 手指按下时，要触发的代码
            }
        }
    }
            

}
