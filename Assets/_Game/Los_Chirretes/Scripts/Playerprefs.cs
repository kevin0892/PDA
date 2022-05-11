using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Playerprefs : MonoBehaviour
{
    public TMP_Text textoPuntajeLocal;
    public TMP_Text textoPuntajeGlobal;
    public int numPuntaje;
    public Game_Over gameOver;
    // Start is called before the first frame update
    void Start()
    {
        textoPuntajeLocal.text = "0";
        textoPuntajeGlobal.text = PlayerPrefs.GetInt("Illustrator", 0).ToString();
        numPuntaje = PlayerPrefs.GetInt("Illustrator", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReiniciarNivel(string nivel)
    {
        
        SceneManager.LoadScene(1);
        //PlayerPrefs.DeleteKey("Illustrator");
        
    }


}
