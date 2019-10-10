using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{

    public InputField infi;

    public void OnClickEnter()
    {
        try
        {
            SceneManager.LoadScene(infi.text, LoadSceneMode.Single);
            
        }
        catch (Exception e)
        {
            //infi.text = "невозможно загрузить этот номер";
        }
    }
    public void OnClickBack()
    {
        try
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);

        }
        catch (Exception e){}
    }
}
