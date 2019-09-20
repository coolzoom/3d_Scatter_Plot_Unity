using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
This script is attached to every plot point or game object representation dynamically. 
     
*/


public class Cube_Click : MonoBehaviour
{
    private GameObject nametext;
    private GameObject statetext;
    public string color;
    private GameObject txtpnl;
    public bool blinks;
    private bool blinker;
    private float cooldown = .50f;
    private static float runner = 0;
    // Start is called before the first frame update
    void Start()
    {
        blinks = false;
        txtpnl = GameObject.Find("Settings");
        //txtpnl.SetActive(true);
        //nametext = GameObject.Find("Name_txt").GetComponent<Text>();
        //statetext = GameObject.Find("Stat_txt").GetComponent<Text>();
        //nametext = GameObject.Find("Name_txt");
        //statetext = GameObject.Find("Stat_txt");
        //txtpnl.SetActive(false);
    }

    // Update is called once per frame

        /*
         This function will be called when the user clicks on a game object to view it.
         */
    private void OnMouseDown()
    {
        txtpnl.GetComponent<Settings>().current_node.GetComponent<Cube_Click>().blinks = false;
        txtpnl.GetComponent<Settings>().current_node.GetComponent<MeshRenderer>().enabled = true;
        txtpnl.GetComponent<Settings>().current_node = this.gameObject;
        showviewer();
        blinks = true;
    }
    /*
    This function is for outputting  
    */
    public void showviewer()
    {
        //txtpnl.SetActive(true);
        txtpnl.GetComponent<Settings>().fireware.SetActive(true);
        Debug.Log("[Row: " + this.name.ToString() + "]");
        string encase;
        encase = "[Row: " + this.name.ToString() + "]";
        //nametext.GetComponent<Text>().text =encase;
        txtpnl.GetComponent<Settings>().name_text.GetComponent<Text>().text = encase;

        encase = "X: " + this.transform.position.x + "\nY: " + this.transform.position.y + "\nZ: " + this.transform.position.z+"\nColor: "+color;
        txtpnl.GetComponent<Settings>().stat_text.GetComponent<Text>().text = encase;
        txtpnl.GetComponent<Settings>().current_node = this.gameObject;

        //statetext.GetComponent<Text>().text = encase;
    }


    /*
    Used update for the blinking routine.  
    */
    private void Update()
    {
        if (blinks)
        {
            Debug.Log("I should be blinking");
            Debug.Log("runner: " + runner + "Delta.Time" + Time.time);

            if (runner < Time.time)
            {
                Debug.Log("I oughto be blinking");

                blinker = !blinker;
                runner = Time.time + cooldown;
            }
            this.GetComponent<MeshRenderer>().enabled = blinker;
        }
    }
}
