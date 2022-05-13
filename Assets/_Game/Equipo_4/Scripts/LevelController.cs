using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private PlayerController player;
    private UIController uiManage;
    private int currentAmmount;
    public string nextLevelName;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        uiManage = FindObjectOfType<UIController>();
    }
    void Update()
    {
        currentAmmount = player.ItemAmmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (currentAmmount == 3)
            {
                SceneManager.LoadScene(nextLevelName);
            }
            else
            {
                uiManage.ShowNoPointsOverlay();
            }
        }
    }
}
