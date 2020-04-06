using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class OpenWeatherMap : MonoBehaviour
{
    public Text Txt;      //Define the return object (linked by text     drop)
    public RawImage Rim;  //Define the return object (linked by rawImage drop)

    void Start()
    {
        StartCoroutine(GetTexture()); //Start the IEnumerator GetTexture Coroutine
        StartCoroutine(GetText());    //Start the IEnumerator GetText    Coroutine
    }

    IEnumerator GetTexture()
    {
      UnityWebRequest uwr = UnityWebRequestTexture.GetTexture
      (
          "https://img1.bonnesimages.com/bi/coeurs/coeurs_043.jpg"
      ); //Define uwr as a webRequest -> will catch the url image
      yield return uwr.SendWebRequest(); //Yield return the request

      if(uwr.isNetworkError || uwr.isHttpError) //Catch errors
      {
          UnityEngine.Debug.Log(uwr.error);     //Display error log
      }
      else
      {     
          //Define myTexture (as 2D texture) and catch the content of the request
          Texture2D myTexture = DownloadHandlerTexture.GetContent(uwr);
          //Link with the rawImage component
          Rim.texture = myTexture;
      }
    }

    IEnumerator GetText()
    {
        UnityWebRequest uwr = UnityWebRequest.Get
        (
            "https://openweathermap.org/api"
        ); //Define uwr as a webRequest -> will catch the url text
        yield return uwr.SendWebRequest();//Yield return the request
        
        if(uwr.isNetworkError || uwr.isHttpError) //Catch errors
        {
            UnityEngine.Debug.Log(uwr.error);     //Display error log
        }
        else
        {
            //Link with the compenent Txt the result of the request
            Txt.text = uwr.downloadHandler.text;
        }
    }
}
