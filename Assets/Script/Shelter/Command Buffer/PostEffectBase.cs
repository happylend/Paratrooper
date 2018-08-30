/*
后处理脚本主要做的是两件事，第一件是获取需要的shader，生成材质，第二件是通过OnRenderImage使用材质处理屏幕效果。
第一步具有一些普遍性，不管是什么后处理效果，都要有这一步相同的操作，所以我们将该步骤抽离出来，创建一个后处理效
果的基类PostEffectBase
*/

using UnityEngine;
using System.Collections;

//非运行时也触发效果  
[ExecuteInEditMode]
//屏幕后处理特效一般都需要绑定在摄像机上  
[RequireComponent(typeof(Camera))]
//提供一个后处理的基类，主要功能在于直接通过Inspector面板拖入shader，生成shader对应的材质  
public class PostEffectBase : MonoBehaviour
{

    //Inspector面板上直接拖入  
    public Shader shader = null;
    private Material _material = null;
    public Material _Material
    {
        get
        {
            if (_material == null)
                _material = GenerateMaterial(shader);
            return _material;
        }
    }

    //根据shader创建用于屏幕特效的材质  
    protected Material GenerateMaterial(Shader shader)
    {
        if (shader == null)
            return null;
        //需要判断shader是否支持  
        if (shader.isSupported == false)
            return null;
        Material material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        if (material)
            return material;
        return null;
    }

}
