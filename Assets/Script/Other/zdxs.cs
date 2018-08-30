using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zdxs : MonoBehaviour {

    void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.name.Equals("butlle(Clone)"))
        {
            Debug.Log("碰撞物体名："+ co.gameObject.name);
            Destroy(co.gameObject);
        }

    }
}
