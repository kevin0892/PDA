using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMoney : MonoBehaviour
{

    public GameObject[] moneyUI;
    private int money;
    
    public GameObject dieScreen;
    void Start()
    {
        dieScreen.SetActive(false);
        money = moneyUI.Length;
        
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (money >= 1)
        {
            money -= damage;
            Destroy(moneyUI[money].gameObject);
        }
        else
        {
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        dieScreen.SetActive(true);
        yield return new WaitForSeconds(2.5F);
        SceneManager.LoadScene("Level_01");
    }
}
