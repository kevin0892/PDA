using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Game_Over : MonoBehaviour
{
    public Char_Movement character;
    public Canvas canvas;
    public RectTransform panelIllus;
    public int illusCount;
    public Playerprefs _playerPrefs;
// public TMPro.Tex
    // Start is called before the first frame update
    private void Awake()
    {
        Objects.OnImpact += Objects_OnImpact;
        illusCount = _playerPrefs.numPuntaje;
    }

    private void Objects_OnImpact(ImpactType impactType, ImpactClass impactClass)
    {
        if (impactType == ImpactType.collectable && impactClass == ImpactClass.none)
        {
            print("chingatumadre");
        }
        else if (impactType == ImpactType.munition && impactClass == ImpactClass.none)
        {
            character.incrementMunition(10);
            print("latuya");
        }
        else if (impactType == ImpactType.collectable && impactClass == ImpactClass.illustrator)
        {
            print("Illus");
            illusCount++;
            _playerPrefs.numPuntaje = illusCount;
            PlayerPrefs.SetInt("Illustrator", _playerPrefs.numPuntaje);
            PlayerPrefs.Save();
            //panelIllus.gameObject.SetActive(true);
            //PauseGame();

        }
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        panelIllus.gameObject.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
}
