using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    public float CurrentVal 
    { 
        get => currentVal; 

        set 
        { 
            bar.Value = CurrentVal; currentVal = value; 
        } 
    }

    public float MaxVal 
    { 
        get => maxVal; 

        set 
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        } 
    }
}
