using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class panelcontrol : MonoBehaviour
{
    //private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
      //  camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,Mathf.Infinity) || EventSystem.current.IsPointerOverGameObject())
            {
               // Debug.Log("you hit" +hit.transform.name);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    
    
}
