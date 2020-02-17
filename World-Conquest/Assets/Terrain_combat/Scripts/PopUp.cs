using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public Text message;
    public string[] popUps = 
    {
        "Ici delta 1 je vous reçois",
        "Ici delta 2 je vous reçois",
        "Ici delta 3 je vous reçois",
        "Ici delta 4 je vous reçois",
        "Ici delta 5 je vous reçois",
        "Ici delta 6 je vous reçois",
        "Je vous recois mal très mal"
    };
    private int i=0;

    void Start()
    {
        //Link the variable and the component
        message = GetComponent<Text>();   

    }
    void Update()
    {
        if( Input.GetKeyDown("space"))
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
