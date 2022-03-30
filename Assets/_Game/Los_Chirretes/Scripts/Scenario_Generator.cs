using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Scenario_Generator : MonoBehaviour
{
    public Pool ItemsPool;
    public Pool SafeItemsPool;

    Queue<Transform> elements;

    public Vector3 direction1;
    public Vector3 offset1;
    public int Qtty = 25;
    public int SafeQtty = 3;
    public float Displace = 28f;
    public float speed;

    Transform tr;
    Vector3 originalPos;
    float currentDisplace;
    int moved = 0;

    private void Awake()
    {
        tr = transform;
        SafeItemsPool.Initialize();
        ItemsPool.Initialize();

        originalPos = tr.position;
        elements = new Queue<Transform>();
        Generate();  //ESTO SE DEBE QUITAR CUANDO IMPLEMENTE LO DE LOS BOTONES PARA INICIAR Y DEMÁS
    }

    public void Clean()
    {
        while (elements.Any())
        {
            elements.Dequeue().gameObject.SetActive(false);
        }
    }

    public void Generate()
    {
        
        for (int i=0; i<Qtty;i++)
        {
            var elementTransform = i<SafeQtty ? SafeItemsPool.GetRandom() : ItemsPool.GetRandom();
            elementTransform.position = offset1 - direction1 * Displace * i;
            elementTransform.gameObject.SetActive(true);
            elements.Enqueue(elementTransform);
        }
    }

    private void Update()
    {
        tr.position += direction1 * speed * Time.deltaTime;

        currentDisplace = Mathf.Abs(Vector3.Distance(tr.position, originalPos));
        var timesToInf = currentDisplace / Displace;
        
        if (timesToInf > moved + 2)
        {
            ToInfinite();
        }

        
    }
    public void ToInfinite()
    {
        var last = elements.LastOrDefault();
        var tel = elements.Dequeue();
        tel.gameObject.SetActive(false);

        var elementTransform = ItemsPool.GetRandom();
        elementTransform.position = last.position - direction1 * Displace;
        elementTransform.gameObject.SetActive(true);
        elements.Enqueue(elementTransform);

        moved++;
    }
}
