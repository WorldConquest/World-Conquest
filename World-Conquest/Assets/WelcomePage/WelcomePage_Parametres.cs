using System.Net.Mime;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class WelcomePage_Parametres : MonoBehaviour
{
    public Button WelcomePage_Button1;

	void Start () 
    {
		Button button1 = WelcomePage_Button1.GetComponent<Button>();
		button1.onClick.AddListener(Parametres);
	}

	void Parametres()
	{
		UnityEngine.Debug.Log("parametres");
	}  
}