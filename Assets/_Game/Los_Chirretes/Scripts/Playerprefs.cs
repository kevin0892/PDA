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
    public Selection selection;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarNivel(string nivel)
    {
        
        SceneManager.LoadScene(1);

        /*PlayerPrefs.DeleteKey("Unity");
        PlayerPrefs.DeleteKey("Mouse");
        PlayerPrefs.DeleteKey("Computer");
        textoPuntajeGlobal.text = PlayerPrefs.GetInt("Unity", 0).ToString();
        textoPuntajeGlobalMouse.text = PlayerPrefs.GetInt("Mouse", 0).ToString();
        textoPuntajeGlobalComputer.text = PlayerPrefs.GetInt("Computer", 0).ToString();*/

    }

    public void IniciarNivel(string nivel)
    {
        
        SceneManager.LoadScene(0);
    }

    public void CharSelect(int player)
    {
        player = selection.currentSelection;
        PlayerPrefs.SetInt("Player", player);
        PlayerPrefs.Save();
    }


}
