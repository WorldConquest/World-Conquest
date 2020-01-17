using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selection : MonoBehaviour
{
    public float speedRotation = 0.6f;
    GameObject Spotlight;

    void Start()
    {
        Spotlight = GameObject.Find ("Spotlight").gameObject;
    }

    void OnMouseEnter()
    {
        Spotlight.transform.position = new Vector3(transform.position.x, Spotlight.transform.position.y, Spotlight.transform.position.z);
    }

    private void OnMouseOver()
    {
        transform.Rotate(0f, speedRotation, 0f);
    }

    private void OnMouseDown()
    {
        PlayerPrefs.SetString("Player", gameObject.name);
        SceneManager.LoadScene("TankArena");
    }
    
}
