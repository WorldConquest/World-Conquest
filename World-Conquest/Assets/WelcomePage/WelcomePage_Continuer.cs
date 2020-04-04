using System.Net.Mime;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class WelcomePage_Continuer : MonoBehaviour
{
    public Button WelcomePage_Button1;

	void Start () 
    {
		Button button1 = WelcomePage_Button1.GetComponent<Button>();
		button1.onClick.AddListener(Continuer);
	}

	void Continuer()
    {
		SceneManager.LoadScene("CityBuilder");
        UnityEngine.Debug.Log("continuer");
	} 
}