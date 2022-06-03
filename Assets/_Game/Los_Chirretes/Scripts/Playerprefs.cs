using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Playerprefs : MonoBehaviour
{
    public TMP_Text textoPuntajeGlobal;
    public TMP_Text textoPuntajeGlobalMouse;
    public TMP_Text textoPuntajeGlobalComputer;
    public int numPuntaje;
    public int numPuntajeMouse;
    public int numPuntajeComputer;
    public Game_Over gameOver;
    public GameObject confirmButton;
    public GameObject playerPrefsBtn;
    public Selection selection;
    public Toggle toggle_tutorial;
    public GameObject tuto_panel;
    // Start is called before the first frame update
    void Start()
    {
        //textoPuntajeLocal.text = "0";
        textoPuntajeGlobal.text = PlayerPrefs.GetInt("Unity", 0).ToString();
        numPuntaje = PlayerPrefs.GetInt("Unity", 0);
        textoPuntajeGlobalMouse.text = PlayerPrefs.GetInt("Mouse", 0).ToString();
        numPuntajeMouse = PlayerPrefs.GetInt("Mouse", 0);
        textoPuntajeGlobalComputer.text = PlayerPrefs.GetInt("Computer", 0).ToString();
        numPuntajeComputer = PlayerPrefs.GetInt("Computer", 0);
        if (confirmButton != null)
        {
            confirmButton.SetActive(false);
        }
        if (tuto_panel != null)
        {
            tuto_panel.SetActive(intToBool(PlayerPrefs.GetInt("Tuto_Panel", 0)));
            
        }
        if (toggle_tutorial != null)
        {
            toggle_tutorial.isOn = (intToBool(PlayerPrefs.GetInt("Tuto_Panel", 0)));
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestReiniciarNivel(string nivel)
    {
        
        SceneManager.LoadScene(1);

        /*PlayerPrefs.DeleteKey("Unity");
        PlayerPrefs.DeleteKey("Mouse");
        PlayerPrefs.DeleteKey("Computer");
        textoPuntajeGlobal.text = PlayerPrefs.GetInt("Unity", 0).ToString();
        textoPuntajeGlobalMouse.text = PlayerPrefs.GetInt("Mouse", 0).ToString();
        textoPuntajeGlobalComputer.text = PlayerPrefs.GetInt("Computer", 0).ToString();*/

    }

    public void IniciarNivel(int nivel)
    {
        
        SceneManager.LoadScene(nivel);
    }

    public void IniciarMenu(int nivel)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nivel);
    }

    public void ReiniciarNivel(int nivel)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nivel);
    }

    public void CharSelect(int player)
    {
        player = selection.currentSelection;
        PlayerPrefs.SetInt("Player", player);
        PlayerPrefs.Save();
    }
    
    public void DeletePrefs()
    {
        PlayerPrefs.DeleteKey("Unity");
        PlayerPrefs.DeleteKey("Mouse");
        PlayerPrefs.DeleteKey("Computer");
        numPuntaje = 0;
        numPuntajeComputer = 0;
        numPuntajeMouse = 0;
        textoPuntajeGlobal.text = PlayerPrefs.GetInt("Unity", 0).ToString();
        
        textoPuntajeGlobalMouse.text = PlayerPrefs.GetInt("Mouse", 0).ToString();
        
        textoPuntajeGlobalComputer.text = PlayerPrefs.GetInt("Computer", 0).ToString();

        confirmButton.SetActive(false);
        playerPrefsBtn.SetActive(true);
        
    }

    public void ConfirmDelete()
    {
        if (confirmButton.activeSelf == false)
        {
            confirmButton.SetActive(true);
            playerPrefsBtn.SetActive(false);
        }
    }

    public void BackDelete()
    {
        if (confirmButton.activeSelf == true)
        {
            confirmButton.SetActive(false);
            playerPrefsBtn.SetActive(true);
        }
    }

    public void QuitApp()
    {
        Application.Quit();
        print("hola");
    }

    public void ToggleTuto()
    {
        if (toggle_tutorial.isOn == false)
        {
            PlayerPrefs.SetInt("Tuto_Panel", boolToInt(false));
            
        }
        else if (toggle_tutorial.isOn == true)
        {
            PlayerPrefs.SetInt("Tuto_Panel", boolToInt(true));
            
        }

    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

}
