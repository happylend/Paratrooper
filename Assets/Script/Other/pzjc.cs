using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pzjc : MonoBehaviour {
    private Renderer rd;
    /// <summary>
    /// 每次游戏对象发生碰撞就改变颜色
    /// </summary>
    /// <param name="co"></param>
    void OnCollisionEnter(Collision co)
    {
        rd = co.gameObject.GetComponent<Renderer>();
        rd.material.color = Color.black;

    }
}
