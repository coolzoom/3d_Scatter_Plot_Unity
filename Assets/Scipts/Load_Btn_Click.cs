using System.Collections;
using System.Collections.Generic;
    
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Load_Btn_Click : MonoBehaviour
{
    private Button loadbtn;
    private GameObject brain;
    public PlotPoint[] plot_points;
    // Start is called before the first frame update
    void Start()
    {
        loadbtn = GameObject.Find("Load_btn").GetComponent<Button>();
        loadbtn.onClick.AddListener(readandloadCSV);
        brain = GameObject.Find("Brain");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void readandloadCSV()
    {
        if (Settings.player_active)
        {
            lookforCSV();
            StartCoroutine("readCSV");
        }
    }
     
    void lookforCSV()
    {
        System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
        ofd.Title = "Look for CSV file";
        ofd.Filter = "CSV file (*.csv) | *.csv";
        if (ofd.ShowDialog()==System.Windows.Forms.DialogResult.OK)
        {
            brain.GetComponent<Settings>().setaddress(ofd.FileName);            
        }
    }
    IEnumerator readCSV()
    {
        Settings.player_active = false;
        
        StreamReader reader = new StreamReader(brain.GetComponent<Settings>().getaddress());
        //Debug.Log(reader.ReadLine());
        //string oneline=reader.ReadLine();
        //reader.Close();

        //string[] linesize =oneline.Split(',');
        //int linelength=linesize.Length;
        //string[] onelinesize = oneline.Split(',');

        string whole = reader.ReadToEnd();
        reader.Close();
        string[] lines = whole.Split('\r');
        //double totallines = (lines.Length / linelength)+1;
        Debug.Log(lines.Length);
        //List<PlotPoint> plot_points = new List<PlotPoint>(lines.Length);

        //plot_points.Capacity = lines.Length;
         plot_points = new PlotPoint[lines.Length];
        //PlotPoint[] plotter = new PlotPoint[5];
        //double b = 33;
        //plotter[0] = new PlotPoint();
        //plotter[0].X_value = 33;
        //Debug.Log(plotter[0].X_value);
        
        for(int x=0;x<lines.Length;x++)
        {
            string[] elements = lines[x].Split(',');

            plot_points[x] = new PlotPoint();
            double da;
            int ia;
            if (double.TryParse(elements[0], out da))
            {
                plot_points[x].X_value = da;
            }
            if (double.TryParse(elements[1], out da))
            {
                plot_points[x].Y_value = da;
            }
            if (double.TryParse(elements[2], out da))
            {
                plot_points[x].Z_value = da;
            }
            if (double.TryParse(elements[3], out da))
            {
                plot_points[x].X_value = da;
            }
            if(int.TryParse(elements[4],out ia))
            {
                plot_points[x].size = ia;
            }
            /*
            plot_points[x].Y_value = double.Parse(elements[1]);
            plot_points[x].Z_value = double.Parse(elements[2]);
            plot_points[x].color = int.Parse(elements[4]);
            plot_points[x].size = double.Parse(elements[3]);
            */
            yield return new WaitForSeconds(.1f);

            Debug.Log(plot_points[x].X_value + " " + plot_points[x].Y_value + " " + plot_points[x].Z_value + " " + plot_points[x].size + " "+plot_points[x].color + "");
        
            Debug.Log(elements[0]+" "+elements[1]+" "+ elements[2]+" "+elements[3]+" "+elements[4]);
        }
        /*
        string titles = reader.ReadLine();
        string[] titlepieces=titles.Split(',');
        Debug.Log(titlepieces[0] + " " + titlepieces[1] + " " + titlepieces[2] +" "+titlepieces[3]+" " +titlepieces[4] );
        Settings.X_name = titlepieces[0];
        Settings.Y_name = titlepieces[1];
        Settings.Z_name = titlepieces[2];
        while (reader.Peek()>=0)
        {
            
        }
        */
        Settings.player_active = true;
    }
    
}
