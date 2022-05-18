using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class system_puntos : MonoBehaviour
{

    public Text TextoPuntos;
    public int Puntos = 0;

    public GameObject PanelGanador;


	void OnTriggerExit(Collider obj)
	{
		if (obj.tag == "Ball")
		{
			Puntos++;
			MuestraPuntos();
		}
	}

	void MuestraPuntos() // Funcion de puntos 
	{
		TextoPuntos.text = "Puntos: 5/" + Puntos; 
	}

	private void Update()
	{
		if (Puntos == 5)
		{
			PanelGanador.SetActive(true);
			Time.timeScale = (0);
		}
	}
}
