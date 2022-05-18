using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Selection : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    Vector3 posIni;
    public float horizontalPos; 
    public int currentSelection;
    int totalCharacters=2;

    //UI-Navigation Items
    public GameObject panel_Coleccionables;
    
    
    void Start()
    {
        currentSelection = 1;
        panel_Coleccionables.SetActive(false);
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
        }
    }

    public void Anterior()
    {
        if (currentSelection > 1)
        {
            currentAngle = transform.eulerAngles;
            targetRot = targetRot - new Vector3(0, 90, 0);
            currentSelection--;
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

   
}
