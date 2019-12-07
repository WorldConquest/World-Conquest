using System.Net.Mime;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class CityBuilder_Combattre : MonoBehaviour
{
    public Button CityBuilder_ButtonBattle;

	void Start () 
    {
		Button button1 = CityBuilder_ButtonBattle.GetComponent<Button>();
		button1.onClick.AddListener(Combattre);
	}

	void Combattre()
    {
		SceneManager.LoadScene("TankArena");
        UnityEngine.Debug.Log("TankArena");
	} 
}