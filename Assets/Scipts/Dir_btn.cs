using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dir_btn : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject right;
    private GameObject left;
    private GameObject settin;
    private GameObject target;
    private GameObject fireware;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //right = GameObject.Find("Right_btn").GetComponent<Button>();
        //left = GameObject.Find("Left_btn").GetComponent<Button>();
        right = GameObject.Find("Right_btn");
        left = GameObject.Find("Left_btn");
        right.GetComponent<Button>().onClick.AddListener(goright);
        left.GetComponent<Button>().onClick.AddListener(goleft);
        settin = GameObject.Find("Settings");
        fireware = GameObject.Find("Fireware_Pnl");
        fireware.gameObject.SetActive(false);
        player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void goleft()
    {
        Debug.Log("Going left");
        Directionto(-1);
    }
    void goright()
    {
        Debug.Log("Going right");

        Directionto(1);
    }
    /*
     This is to control the buttons on the "Fireware" going up or down in the plotted circles
     */
    public void Directionto(int direction)
    {
        string row;
        int  oindex;
        row = settin.GetComponent<Settings>().current_node.name;
        settin.GetComponent<Settings>().current_node.GetComponent<Cube_Click>().blinks=false;
        settin.GetComponent<Settings>().current_node.GetComponent<MeshRenderer>().enabled = true;
       Debug.Log("row is: " + row);
        if (int.TryParse(row, out oindex))
        {
            oindex=oindex + direction;
            row = oindex.ToString();
            target = GameObject.Find(row);
            target.GetComponent<Cube_Click>().blinks=true;
            player.transform.LookAt(target.transform);
            Debug.Log("I should be in: " + target.name);
            target.GetComponent<Cube_Click>().showviewer();
        }
    }
}
