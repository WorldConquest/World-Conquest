using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    //Define variables
    public float timerSec = 120;
    private Text timerText;

    void Start()
    {
        //Link the variable and the component
        timerText = GetComponent<Text>();    

    }

    void Update()
    {

        if(timerSec > 0)
        {
            //print(timer);
            //Update the value of the component every seconds 
            timerSec -= Time.deltaTime*5;
            timerText.text = timerSec.ToString("f0"); 
  
        }
        else if (timerSec < 0 && timerSec > -1)
        {
            timerText.text = timerSec.ToString("Ended !!");
            //Make the update function free
            timerSec = -999;
        }
    }
}
