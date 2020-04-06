using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Text message;
    public GameObject tutorial;
    public string[] popUps = 
    {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7"
    };
    private int i=0;

    void Start()
    {
        //Link the variable and the component
        message = GetComponent<Text>();   

    }
    void Update()
    {
        if(Input.GetKeyDown("space") && (i == popUps.Length))
        {
            tutorial.SetActive(false);
        }
        else if( Input.GetKeyDown("space"))
        {
            message.text = popUps[i];
            i++;
        }

        //Don't uncomment update, when enter in the else function create a new thread fill all RAM
        //Find another solution...
        /*else
        {
            Thread.Sleep(2000);
            message.text = popUps[i];
            i++;
        }*/
    }

}
