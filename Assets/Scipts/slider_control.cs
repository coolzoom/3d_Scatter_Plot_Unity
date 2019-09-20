using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
Designed to only change the plotting when click plot. This is designed because normal CSV files are a gig a size and around a milion data points. If i replot them everytime the slider moves, the GPU will take its toll.
Also, training costs GPU. This was designed with that in mind. 
*/
public class slider_control : MonoBehaviour
{
    private Slider x_slide;
    private Slider y_slide;
    private GameObject slide_pnl;
    private InputField min_x;
    private InputField max_x;
    private InputField min_y;
    private InputField max_y;
    private InputField min_z;
    private InputField max_z;
    private Slider z_slide;
    private GameObject brains;
    private GameObject refresh;
    private GameObject Apply;
    private GameObject Customize;
    private bool show = false;
    // Start is called before the first frame update
    void Start()
    {
        min_x = GameObject.Find("Min_X_IF").GetComponent<InputField>();
        max_x = GameObject.Find("Max_X_IF").GetComponent<InputField>();
        min_y = GameObject.Find("Min_Y_IF").GetComponent<InputField>();
        max_y = GameObject.Find("Max_Y_IF").GetComponent<InputField>();
        min_z = GameObject.Find("Min_Z_IF").GetComponent<InputField>();
        max_z = GameObject.Find("Max_Z_IF").GetComponent<InputField>();
        brains = GameObject.Find("Settings");
        slide_pnl = GameObject.Find("Slider_Pnl");
        x_slide = GameObject.Find("X_slide").GetComponent<Slider>();
        y_slide = GameObject.Find("Y_slide").GetComponent<Slider>();
        z_slide = GameObject.Find("Z_slide").GetComponent<Slider>();
        refresh = GameObject.Find("Refresh_btn");
        Apply = GameObject.Find("Apply_btn");
        Customize = GameObject.Find("Cust_btn");
        refresh.GetComponent<Button>().onClick.AddListener(applychange);
        Apply.GetComponent<Button>().onClick.AddListener(applyme);
        Customize.GetComponent<Button>().onClick.AddListener(showcustpanel);
        slide_pnl.gameObject.SetActive(show);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void applyme()
    {
        applychange();
        showcustpanel();
    }
    private void showcustpanel()
    {
        show = !show;
        slide_pnl.gameObject.SetActive(show);

    }
    
    /*
    This function is to accept the changes in the sliders 
    */
    private void applychange()
    {
        float temp;
        if (float.TryParse(min_x.GetComponent<InputField>().text, out temp))
        {
            x_slide.GetComponent<Slider>().minValue = temp;
            if(x_slide.GetComponent<Slider>().value<temp)
            {
                x_slide.GetComponent<Slider>().value = temp;
            }
        }
        if (float.TryParse(max_x.GetComponent<InputField>().text, out temp))
        {
            x_slide.GetComponent<Slider>().maxValue = temp;
            if(x_slide.GetComponent<Slider>().value>temp)
            {
                x_slide.GetComponent<Slider>().value = temp;
            }
        }
        if (float.TryParse(min_y.GetComponent<InputField>().text, out temp))
        {
            y_slide.GetComponent<Slider>().minValue = temp;
            if (y_slide.GetComponent<Slider>().value < temp)
            {
                y_slide.GetComponent<Slider>().value = temp;
            }
        }
        if (float.TryParse(max_y.GetComponent<InputField>().text, out temp))
        {
            y_slide.GetComponent<Slider>().maxValue = temp;
            if (y_slide.GetComponent<Slider>().value > temp)
            {
                y_slide.GetComponent<Slider>().value = temp;
            }
        }
        if (float.TryParse(min_z.GetComponent<InputField>().text, out temp))
        {
            z_slide.GetComponent<Slider>().minValue = temp;
            if (z_slide.GetComponent<Slider>().value < temp)
            {
                z_slide.GetComponent<Slider>().value = temp;
            }
        }
        if (float.TryParse(max_z.GetComponent<InputField>().text, out temp))
        {
            z_slide.GetComponent<Slider>().maxValue = temp;
            if (z_slide.GetComponent<Slider>().value > temp)
            {
                z_slide.GetComponent<Slider>().value = temp;
            }
        }
        brains.GetComponent<Settings>().X_slide = x_slide.value;
        brains.GetComponent<Settings>().Y_slide = x_slide.value;
        brains.GetComponent<Settings>().Z_slide = z_slide.value;
        //if(y_slide.GetComponent<Slider>().value>)
    }

}
