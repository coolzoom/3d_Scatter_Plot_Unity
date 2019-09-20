using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube_Click : MonoBehaviour
{
    private GameObject nametext;
    private GameObject statetext;
    private GameObject txtpnl;
    public bool blinks;
    private bool blinker;
    private float cooldown = 1.0f;
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
    private void OnMouseDown()
    {
        txtpnl.GetComponent<Settings>().current_node.GetComponent<Cube_Click>().blinks = false;
        txtpnl.GetComponent<Settings>().current_node.GetComponent<MeshRenderer>().enabled = true;
        txtpnl.GetComponent<Settings>().current_node = this.gameObject;
        showviewer();
        blinks = true;
    }
    public void showviewer()
    {
        //txtpnl.SetActive(true);
        txtpnl.GetComponent<Settings>().fireware.SetActive(true);
        Debug.Log("[Row: " + this.name.ToString() + "]");
        string encase;
        encase = "[Row: " + this.name.ToString() + "]";
        //nametext.GetComponent<Text>().text =encase;
        txtpnl.GetComponent<Settings>().name_text.GetComponent<Text>().text = encase;

        encase = "X: " + this.transform.position.x + "\nY: " + this.transform.position.y + "\nZ: " + this.transform.position.z;
        txtpnl.GetComponent<Settings>().stat_text.GetComponent<Text>().text = encase;
        txtpnl.GetComponent<Settings>().current_node = this.gameObject;

        //statetext.GetComponent<Text>().text = encase;
    }

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
