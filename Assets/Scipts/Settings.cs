﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
Settings and "Engine"
used to store some of the data that needs to be saved
*/


public class Settings : MonoBehaviour
{
    protected double Maxvalue_x;
    protected double Maxvalue_y;
    public static string X_name;
    public static string Y_name;
    public static string Z_name;
    public float X_slide;
    public float Y_slide;
    public float Z_slide;
    public static bool player_active;
    protected double Maxvalue_z;
    protected string CSV_address;
    public GameObject fireware;
    public GameObject stat_text;
    public GameObject name_text;
    public GameObject current_node;
    // Start is called before the first frame update

        /*
         Set and initiate everything.
         */
    void Start()
    {
        fireware = GameObject.Find("Fireware_Pnl");
        stat_text = GameObject.Find("Stat_txt");
        name_text = GameObject.Find("Name_txt");
        stat_text.GetComponent<Text>().text = "wewo";
        //fireware.SetActive(false);
        player_active = true;
        X_slide = 1;
        Y_slide = 1;
        Z_slide = 1;
        current_node = GameObject.Find("Settings");
    }
    public void setaddress(string a)
    {
        CSV_address = a;
    }
    public void setfirewarepanel(bool a)
    {
        fireware.SetActive(a);
    }
    public string getaddress()
    {
        return CSV_address;
    }
    // Update is called once per frame
    void Update()
    {
        //if (!player_active)
        //{

            //Cursor.SetCursor();
        //}
    }
    
}
