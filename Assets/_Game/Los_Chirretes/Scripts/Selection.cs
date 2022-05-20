using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;
using System;

public class Selection : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    Vector3 posIni;
    public float horizontalPos; 
    public int currentSelection;
    int totalCharacters=2;

    //UI-Navigation Items
    public GameObject panel_Objetivo;
    public GameObject panel_Coleccionables;
    public GameObject panel_Descripciones;
    public GameObject panel_Unity, panel_Mouse, panel_Computer;
    public Playerprefs _playerPrefs;
    public TMP_Text notificationText;
    public Audio_Manager _audio;
    
    void Start()
    {
        currentSelection = 1;
        panel_Objetivo.SetActive(false);
        panel_Coleccionables.SetActive(false);
        panel_Descripciones.SetActive(false);
        panel_Unity.SetActive(false);
        panel_Mouse.SetActive(false);
        panel_Computer.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            posIni = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if ((posIni - Input.mousePosition).magnitude > 150)
            {
                horizontalPos = (posIni - Input.mousePosition).x;
                if (horizontalPos<0)
                {
                    Anterior();
                }
                else
                {
                    Siguiente();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Siguiente();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Anterior();
        }
        currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y, 2.0f * Time.deltaTime));
        transform.eulerAngles = currentAngle;
    }

    public void Siguiente()
    {
        if (currentSelection < totalCharacters)
        {
            currentAngle = transform.eulerAngles;
            targetRot = targetRot + new Vector3(0, 90, 0);
            currentSelection++;
            _audio._audioSource.PlayOneShot(_audio.jumping);
        }
    }

    public void Anterior()
    {
        if (currentSelection > 1)
        {
            currentAngle = transform.eulerAngles;
            targetRot = targetRot - new Vector3(0, 90, 0);
            currentSelection--;
            _audio._audioSource.PlayOneShot(_audio.sliding);
        }
    }

    public void SwitchPanels()
    {
        if (panel_Coleccionables.activeSelf == false)
        {
            panel_Coleccionables.SetActive(true);
        }
        else
        {
            panel_Coleccionables.SetActive(false);
        }
        
    }

    public void SwitchObjetivo()
    {
        if (panel_Objetivo.activeSelf == false)
        {
            panel_Objetivo.SetActive(true);
        }
        else
        {
            panel_Objetivo.SetActive(false);
        }

    }

    public void OpenColeccionable(int number)
    {
        if (_playerPrefs.numPuntaje > 0)
        {
            if (number == 0) //Unity
            {
                panel_Descripciones.SetActive(true);
                panel_Unity.SetActive(true);
                panel_Mouse.SetActive(false);
                panel_Computer.SetActive(false);
            }
        }
        if (_playerPrefs.numPuntajeMouse > 0)
        { 
            if (number == 1) //Mouse
            {
                panel_Descripciones.SetActive(true);
                panel_Mouse.SetActive(true);
                panel_Unity.SetActive(false);
                panel_Computer.SetActive(false);
            }
        }
        if (_playerPrefs.numPuntajeComputer > 0)
        {
            if (number == 2) //Computer
            {
                panel_Descripciones.SetActive(true);
                panel_Computer.SetActive(true);
                panel_Mouse.SetActive(false);
                panel_Unity.SetActive(false);
            }
        }
        if (_playerPrefs.numPuntaje <= 0 && number == 0)
        {
            StartCoroutine(sendNotification("No has recogido ningún coleccionable de Unity", 3));
        }
        if (_playerPrefs.numPuntajeComputer <= 0 && number == 2)
        {
            StartCoroutine(sendNotification("No has recogido ningún coleccionable de Computadora", 3));
        }
        if (_playerPrefs.numPuntajeMouse <= 0 && number == 1)
        {
            StartCoroutine(sendNotification("No has recogido ningún coleccionable de Periféricos", 3));
        }


    }

    public void BackToAlbum()
    {
        if (panel_Coleccionables.activeSelf == true && panel_Descripciones.activeInHierarchy == true)
        {
            //panel_Coleccionables.SetActive(true);
            panel_Descripciones.SetActive(false);
        }
    }

    IEnumerator sendNotification(string text, int time)
    {
        notificationText.text = text;
        yield return new WaitForSeconds(time);
        notificationText.text = "";
    }
   
}
