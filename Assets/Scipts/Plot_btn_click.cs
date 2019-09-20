using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Plot_btn_click : MonoBehaviour
{
    private Button plotbtn;
    private GameObject ES;
    private GameObject brains;
    private float X_avg,Y_avg,Z_avg;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        plotbtn = GameObject.Find("Plot_btn").GetComponent<Button>();
        plotbtn.onClick.AddListener(plotaway);
        ES = GameObject.Find("EventSystem");
        brains = GameObject.Find("Settings");
        player = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void plotaway()
    {
        if (Settings.player_active)
        {
            plotthegraph();
        }
       
    }


    void plotthegraph()
    {
        X_avg = 0;
        Y_avg = 0;
        Z_avg = 0;
        GameObject[] plottedsphere;
        plottedsphere = GameObject.FindGameObjectsWithTag("Spheres");
        for (int x = 0; x < plottedsphere.Length; x++)
        {
            /*
             //this is a "Lets break the GPU time
            plottedsphere[x].AddComponent<Shatter>();
            StartCoroutine(plottedsphere[x].GetComponent<Shatter>().SplitMesh(true));
            */
            Destroy(plottedsphere[x]);
        }
        
        for (int x = 0; x < ES.GetComponent<Load_Btn_Click>().plot_points.Length; x++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = new Vector3((float)ES.GetComponent<Load_Btn_Click>().plot_points[x].X_value*brains.GetComponent<Settings>().X_slide, (float)ES.GetComponent<Load_Btn_Click>().plot_points[x].Y_value* brains.GetComponent<Settings>().Y_slide, (float)ES.GetComponent<Load_Btn_Click>().plot_points[x].Z_value* brains.GetComponent<Settings>().Z_slide);
            X_avg = X_avg+((float)ES.GetComponent<Load_Btn_Click>().plot_points[x].X_value * brains.GetComponent<Settings>().X_slide);
            Y_avg = Y_avg + ((float)ES.GetComponent<Load_Btn_Click>().plot_points[x].Y_value * brains.GetComponent<Settings>().Y_slide);
            Z_avg = Z_avg + ((float)ES.GetComponent<Load_Btn_Click>().plot_points[x].Z_value * brains.GetComponent<Settings>().Z_slide);
            sphere.name = x.ToString();
            sphere.tag = "Spheres";
            sphere.transform.localScale = new Vector3((float)ES.GetComponent<Load_Btn_Click>().plot_points[x].size, (float)ES.GetComponent<Load_Btn_Click>().plot_points[x].size, (float)ES.GetComponent<Load_Btn_Click>().plot_points[x].size);
            Debug.Log("For X: "+x+"Color is: "+ES.GetComponent<Load_Btn_Click>().plot_points[x].color);
            switch (ES.GetComponent<Load_Btn_Click>().plot_points[x].color)
            {
                case 0:

                    sphere.GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f);
                    break;
                case 1:

                    sphere.GetComponent<Renderer>().material.color = new Color(0.0f, 1.0f, 0.0f);
                    break;
                case 2:
            
                    sphere.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
                    break;
            }
            sphere.AddComponent<Cube_Click>();
            //sphere.AddComponent<Outline>();
            //sphere.GetComponent<Outline>().enabled = true;
            //sphere.AddComponent<(Behaviour)GetComponent("Halo")>();
        }
        X_avg = X_avg / ES.GetComponent<Load_Btn_Click>().plot_points.Length;
        Y_avg = Y_avg / ES.GetComponent<Load_Btn_Click>().plot_points.Length;
        Z_avg = Z_avg / ES.GetComponent<Load_Btn_Click>().plot_points.Length;
        player.transform.LookAt(new Vector3(X_avg,Y_avg,Z_avg));
        //player.transform.LookAt(plottedsphere[1].transform);
    }
}
