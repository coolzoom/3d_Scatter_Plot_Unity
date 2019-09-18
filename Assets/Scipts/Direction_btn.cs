using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_Direction_btn : MonoBehaviour
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
        Directionto(-1);
    }
    void goright()
    {
        Directionto(1);
    }

    public void Directionto(int direction)
    {
        string row;
        int index,oindex;
        row=settin.GetComponent<Settings>().name_text.GetComponent<Text>().text;
        if(int.TryParse(row,out oindex))
        {
            row = oindex.ToString();
            target = GameObject.Find(row+direction);
            target.GetComponent<Cube_Click>().showviewer();
        }
    }
}
