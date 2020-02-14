using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    private float fillAmount;

    [SerializeField]
    private float lerpSpeed; // Allows the life bar to be reduced gently. To give a progressive effect

    [SerializeField] //Allow to see a private variable in unity
    private Image content; // We using namespace Image 

    [SerializeField]
    private Text valueText;

    [SerializeField]
    private Color fullColor; // This is a full color of a bar script 

    [SerializeField]
    private Color lowColor; // This is a low color of a bar script

    [SerializeField]
    private bool lerpColor; // Allow to choice wich one bar script use lerp color
    public float MaxValue { get; set; }
    public float Value
    {
        set
        {
            // To write the right value in the health bar
            string[] tmp = valueText.text.Split(':');
            valueText.text = tmp[0] + ": " + value; // tmp[0] = health 

            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (lerpColor)
        {
            content.color = fullColor; // Initialize bool lerpColor
        }
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
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed); //We update a fillAmout if the fillAmout is different at content.fillAmount (the current fillAmount)
        }
        if (lerpColor)
        {
            content.color = Color.Lerp(lowColor, fullColor, fillAmount); // Allow to change color for a bar script if is low

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
