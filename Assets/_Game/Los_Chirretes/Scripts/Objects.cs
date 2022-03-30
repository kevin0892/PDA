using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    static public event ImpactEvent OnImpact;

    public ImpactType impactType = ImpactType.impact;
    public ImpactClass impactClass = ImpactClass.none;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OnImpact?.Invoke(impactType, impactClass);
        }
    }

    private void OnDestroy()
    {
        OnImpact = null;       
    }
}

public delegate void ImpactEvent(ImpactType impactType, ImpactClass impactClass);

public enum ImpactType
{
    impact,
    collectable,
    munition
}

public enum ImpactClass
{
    none,
    illustrator,
    photoshop
}


/*private GameObject player;
public Scenario_Generator scen_Gen;
public bool isPaused;

void Start()
{
    player = GameObject.Find("Player");
    scen_Gen = GameObject.Find("Generator_Walls").GetComponent<Scenario_Generator>();
}

private void OnTriggerEnter(Collider other)
{

    if (this.tag == "Impact" && other.tag == "Player")
    {

        //player.GetComponent<PlayerControllerAnim>().anim.SetTrigger("CollectItemTrigger"); //Esto es para agregar lo de la animación de recoger. Aún trabajando en ello.

        PauseGame();
        print("Perdiste");


    }
    else
    {
        PauseGame();
        print("Collectable");
    }



}


public void PauseGame()
{
    Time.timeScale = 0;
    isPaused = true;
}
public void ResumeGame()
{
    Time.timeScale = 1;
    isPaused = false;
}

public void IsPaused()
{

}*/




