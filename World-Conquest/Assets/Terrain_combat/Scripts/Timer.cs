using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Define variables
    public float myCoolTimer = 10;
    private Text timerText;

    void Start()
    {
        //Link the varaible and the component
        timerText = GetComponent<Text>();    
    }

    void Update()
    {
        if(myCoolTimer > 0)
        {
            //Update the value of the component every seconds 
            myCoolTimer -= Time.deltaTime;
            timerText.text = myCoolTimer.ToString("f0");
            print(myCoolTimer);
        }
        else if (myCoolTimer < 0 && myCoolTimer > -1)
        {
            timerText.text = myCoolTimer.ToString("Ended !!");
            print("Ended !!");
            //Make the update function free
            myCoolTimer = -999;
        }
    }
}
