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

    public GameObject joystick;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (player)
        {
            currentAmmount = player.ItemAmmount;
        }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN

        joystick.SetActive(false);

#elif UNITY_ANDROID || UNITY_IPHONE

        joystick.SetActive(true);

#endif
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
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(8F);
        Time.timeScale = 1f;
        lvlStartedMsg.SetActive(false);
    }
    IEnumerator NoPoints()
    {
        noPointsOverlay.SetActive(true);
        yield return new WaitForSeconds(3F);
        noPointsOverlay.SetActive(false);
    }

}
