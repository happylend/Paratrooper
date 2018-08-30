using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class playerset : NetworkBehaviour {
    [SerializeField]
    private Component[] componentToDisable;
    private Camera mainCamera;
	// Use this for initialization
	void Start () {
	 if(isLocalPlayer==false)
     {
         DisableComponent();
     }
        else
     {
         mainCamera = Camera.main;
         if (mainCamera != null)
         {
             Camera.main.gameObject.SetActive(false);
         }
     }
	}
    void DisableComponent()
    {
        foreach(Behaviour component in componentToDisable)
        {
            component.enabled = false;
        }
    }
    void OnDisable()
    {

        if (isLocalPlayer && mainCamera!=null)
        {
            mainCamera.gameObject.SetActive(true);
        }
    }
}
