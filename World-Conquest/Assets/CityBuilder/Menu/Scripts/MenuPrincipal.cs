using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    void Update()
    {    
       AudioListener.pause = false; // plays the sound
    }

    public void Avant()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quitter()
    {
        //UnityEditor.EditorApplication.isPlaying = false; // Bug when build project
        Debug.Log("Vous avez quittez!");
        Application.Quit();
    }

    public void Retour()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void SetVolume(float volume)
    {
        Debug.Log(volume);
    }

    public void Option()
    {
        SceneManager.LoadScene("MenuOption");
    }

    public void CityBuilder()
    {
        SceneManager.LoadScene("CityBuilder");
    }

    public void MenuParametre()
    {
        SceneManager.LoadScene("Menu Paramètres");
    }

    public void TankArena()
    {
        SceneManager.LoadScene("TankArena");
    }

    public void SelectionOfUnits()
    {
        SceneManager.LoadScene("SelectionOfUnits");
    }

    public void SelectionNiveau()
    {
        SceneManager.LoadScene("SelectionNiveau");
    }

    void DestroyGameObject()
	{
		Destroy(gameObject);
	}
}