using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class panelcontrol : MonoBehaviour
{/*
    
 */
    //private GameObject camera;
    // Start is called before the first frame update
    private GameObject settings;
    void Start()
    {

        settings = GameObject.Find("Settings");
      //  camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    /*
    this is to close the "Fireware" when clicking outside the "box" 
    */
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
                settings.GetComponent<Settings>().current_node.GetComponent<Cube_Click>().blinks = false;
                settings.GetComponent<Settings>().current_node.GetComponent<MeshRenderer>().enabled = true;
                this.gameObject.SetActive(false);

            }
        }
    }
    
    
}
