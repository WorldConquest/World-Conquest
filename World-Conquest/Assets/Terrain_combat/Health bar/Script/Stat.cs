using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]    //Allow to see a private variable in unity
    private BarScript bar;

    [SerializeField]    //Allow to see a private variable in unity
    private float maxVal;

    [SerializeField]    //Allow to see a private variable in unity
    private float currentVal;

    public float CurrentVal 
    {
        get
        {
            return currentVal;
        }
        set 
        {
            this.currentVal = Mathf.Clamp(value,0,MaxVal); // Allows not to go below 0 and not to exceed MaxVal
            bar.Value = currentVal;
        } 
    }

    public float MaxVal 
    {
        get
        {
           return maxVal;
        }
        set 
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        } 
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;           // We initialize the max value 
        this.CurrentVal = currentVal;   // We initialize the current value
    }
}
