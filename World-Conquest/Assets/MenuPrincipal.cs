using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public void Avant()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("SelectionOfUnits");
    }

    public void Quitter()
    {
        UnityEditor.EditorApplication.isPlaying = false;
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
}