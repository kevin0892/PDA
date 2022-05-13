using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private GameObject noPointsOverlay;
    private PlayerController player;
    private int currentAmmount;

    public GameObject lvlStartedMsg;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        currentAmmount = player.ItemAmmount;
    }

    public void ShowLevelStartMsg()
    {
        if (lvlStartedMsg)
        {
            StartCoroutine(LvlStarted());
        }
    }

    public void ShowNoPointsOverlay()
    {
        if (noPointsOverlay)
        {
            StartCoroutine(NoPoints());
        }
    }

    IEnumerator LvlStarted()
    {
        lvlStartedMsg.SetActive(true);
        yield return new WaitForSeconds(3F);
        lvlStartedMsg.SetActive(false);
    }
    IEnumerator NoPoints()
    {
        noPointsOverlay.SetActive(true);
        yield return new WaitForSeconds(3F);
        noPointsOverlay.SetActive(false);
    }

}
