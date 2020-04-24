using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public AudioSource AudioSource;
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
        AudioSource AudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown("space") && (i == popUps.Length))
        {
            tutorial.SetActive(false);
            // When the tutorial is finish, the sound is louder
            AudioSource.volume = 0.45f; // 0.0-1.0, you can change this at runtime (0 mute / 1 = volume 100 %) 
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
