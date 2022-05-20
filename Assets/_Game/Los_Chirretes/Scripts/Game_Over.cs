using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;

public class Game_Over : MonoBehaviour
{
    public TMP_Text textoPuntajeLocal;
    public TMP_Text textoPuntajeLocalMouse;
    public TMP_Text textoPuntajeLocalComputer;
    public int unityCount;
    public int mouseCount;
    public int computerCount;
    public Char_Movement character;
    public Canvas canvas;
    public RectTransform panelIllus;
    public GameObject panelGameOver;
    public GameObject panelPaused;
    public Playerprefs _playerPrefs;
    public GameObject chica;
    public GameObject chico;
    private int charSelection;
    public bool pause;

    public Audio_Manager _audio;

    // Start is called before the first frame update
    private void Awake()
    {
        pause = false;
        panelPaused.SetActive(false);
        panelGameOver.SetActive(false);
        Objects.OnImpact += Objects_OnImpact;
        unityCount = _playerPrefs.numPuntaje;
        mouseCount = _playerPrefs.numPuntajeMouse;
        computerCount = _playerPrefs.numPuntajeComputer;
        textoPuntajeLocal.text = unityCount.ToString();
        charSelection = PlayerPrefs.GetInt("Player", 0);
        if (charSelection == 2)
        {
            chica.SetActive(false);
            chico.SetActive(true);
        }
        else
        {
            chico.SetActive(false);
            chica.SetActive(true);
        }
    }

    private void Objects_OnImpact(ImpactType impactType, ImpactClass impactClass)
    {
        if (impactType == ImpactType.impact && impactClass == ImpactClass.none)
        {
            //if (character.lives >= 1)
            //{
                character.GetDamage(1);
            _audio._audioSource.PlayOneShot(_audio.impact);
                if (character.lives <= 0)
                {
                    Time.timeScale = 0;
                    panelGameOver.SetActive(true);
                }
            //}
            
        }
        else if (impactType == ImpactType.munition && impactClass == ImpactClass.none)
        {
            character.incrementMunition(10);
            print("latuya");
        }
        else if (impactType == ImpactType.collectable && impactClass == ImpactClass.unity)
        {
            print("Unity");
            unityCount++;           
            textoPuntajeLocal.text = unityCount.ToString();
            _playerPrefs.numPuntaje = unityCount;
            _audio._audioSource.PlayOneShot(_audio.collectables);

            if (_playerPrefs.numPuntaje >= PlayerPrefs.GetInt("Unity",0))
            {
                PlayerPrefs.SetInt("Unity", _playerPrefs.numPuntaje);
                PlayerPrefs.Save();
                _playerPrefs.textoPuntajeGlobal.text = PlayerPrefs.GetInt("Unity", 0).ToString();
                
            }
           

        }
        else if (impactType == ImpactType.collectable && impactClass == ImpactClass.mouse)
        {
            print("Mouse");
            mouseCount++;
            textoPuntajeLocalMouse.text = mouseCount.ToString();
            _playerPrefs.numPuntajeMouse = mouseCount;
            _audio._audioSource.PlayOneShot(_audio.collectables);

            if (_playerPrefs.numPuntajeMouse >= PlayerPrefs.GetInt("Mouse", 0))
            {
                PlayerPrefs.SetInt("Mouse", _playerPrefs.numPuntajeMouse);
                PlayerPrefs.Save();
                _playerPrefs.textoPuntajeGlobalMouse.text = PlayerPrefs.GetInt("Mouse", 0).ToString();

            }


        }
        else if (impactType == ImpactType.collectable && impactClass == ImpactClass.computer)
        {
            print("Computer");
            computerCount++;
            textoPuntajeLocalComputer.text = computerCount.ToString();
            _playerPrefs.numPuntajeComputer = computerCount;
            _audio._audioSource.PlayOneShot(_audio.collectables);

            if (_playerPrefs.numPuntajeComputer >= PlayerPrefs.GetInt("Computer", 0))
            {
                PlayerPrefs.SetInt("Computer", _playerPrefs.numPuntajeComputer);
                PlayerPrefs.Save();
                _playerPrefs.textoPuntajeGlobalComputer.text = PlayerPrefs.GetInt("Computer", 0).ToString();

            }


        }
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        panelIllus.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        if (pause == true)
        {
            Time.timeScale = 1;
            panelPaused.SetActive(false);
            pause = false;
        }
        else if (pause == false)
        {
            Time.timeScale = 0;
            panelPaused.SetActive(true);
            pause = true;
        }
    }
}
