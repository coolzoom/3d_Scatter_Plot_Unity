using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cube_Click : MonoBehaviour
{
    private Text nametext;
    private Text statetext;
    private GameObject txtpnl;

    // Start is called before the first frame update
    void Start()
    {
        //txtpnl = GameObject.Find("text_Panel");
       // txtpnl.SetActive(false);
       // nametext = GameObject.Find("Name_txt").GetComponent<Text>();
       // statetext = GameObject.Find("Stats_txt").GetComponent<Text>();
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        //txtpnl.SetActive(true);
       // nametext.text = "[Row"+this.name+"]";
       // statetext.text = "X: "+this.transform.position.x+"\nY: "+this.transform.position.y+"\nZ: "+this.transform.position.z;
    }
}
