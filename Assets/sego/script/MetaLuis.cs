using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetaLuis : MonoBehaviour
{

    float distancia = 1 ;

    public Transform posicion1;
    public Transform posicion2;

    public Slider slider;

    void Start()
    {
        
    }


    void Update()
    {
        distancia = Vector3.Distance(posicion1.position, posicion2.position);
        distancia /= 1.2f;

        slider.value = distancia;

    }
}
