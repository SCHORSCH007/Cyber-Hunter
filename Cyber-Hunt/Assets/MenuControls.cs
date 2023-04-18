using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{
    [SerializeField] GameObject ControlScreen;
public void ExitGame()
    {
        Application.Quit();
    }


public void Controls()
    {
        ControlScreen.SetActive(true);
    }
 
public void ExitControls()
    {
        ControlScreen.SetActive(false);
    } 

public void BeginGame()
    {
        SceneManager.LoadScene(1);
    }
}
