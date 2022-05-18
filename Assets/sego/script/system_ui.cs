using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class system_ui : MonoBehaviour
{
    public GameObject PanelConfig;

    public void AbrirConfig()
    {
        Time.timeScale = (0);

        PanelConfig.SetActive(true);
    }

    public void VolverAlMapa()
    {
        SceneManager.LoadScene(2);
    }

    public void AbrirLevel02()
    {
        SceneManager.LoadScene(11);
        Time.timeScale = (1);
        //Application.LoadLevel("level02");
    }

    public void VolverAlJuego()
    {
        Time.timeScale = (1);
        PanelConfig.SetActive(false);
    }
}
