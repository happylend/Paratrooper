using UnityEngine;
using System.Collections;
using UnityEngine.UI;//注意这个不能少 

public class ChangeScene : MonoBehaviour {

    // Use this for initialization  
    void Start()
    {

        GameObject btnObj = GameObject.Find("Start");//"Button"为你的Button的名称  
        Button btn = btnObj.GetComponent<Button>();
        btn.onClick.AddListener(delegate ()
        {
            this.GoNextScene(btnObj);
        });
    }

    // Update is called once per frame  
    void Update()
    {
    }

    public void GoNextScene(GameObject NScene)
    {
        Application.LoadLevel("TheFirstLevel");//切换到场景Scene_2  
    }
} 

