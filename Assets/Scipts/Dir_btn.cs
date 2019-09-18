using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dir_btn : MonoBehaviour
{
    // Start is called before the first frame update
    private Button right;
    private Button left;
    private GameObject settin;
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        right = GameObject.Find("Right_btn").GetComponent<Button>();
        left = GameObject.Find("Left_btn").GetComponent<Button>();
        right.onClick.AddListener(goright);
        left.onClick.AddListener(goleft);
        settin = GameObject.Find("Settings");
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

    public void Directionto(int direction)
    {
        string row;
        int  oindex;
        row = settin.GetComponent<Settings>().current_node.name;
        Debug.Log("row is: " + row);
        if (int.TryParse(row, out oindex))
        {
            oindex=oindex + direction;
            row = oindex.ToString();
            target = GameObject.Find(row);
            Debug.Log("I should be in: " + target.name);
            target.GetComponent<Cube_Click>().showviewer();
        }
    }
}
