using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField] //Allow to see a private variable in unity
    private float fillAmount;

    [SerializeField]
    private Image content; // We using namespace Image 

    public float MaxValue { get; set; }
    public float Value
    {
        set
        {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        if (fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount; //We update a fillAmout if the fillAmout is different at content.fillAmount (the current fillAmount)
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin; // To return a value between 0 and 1
            // ( 80   -   0  ) * (   1   -   0   ) / ( 100% -  0 % ) +   0
            //        80       *         1         /        100      +   0
            //  = 0.8 We have 80% of life
    }
}
