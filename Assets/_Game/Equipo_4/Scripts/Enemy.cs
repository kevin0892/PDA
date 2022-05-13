using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
#if UNITY_EDITOR
using UnityEditor;

#endif

public class Enemy : MonoBehaviour
{
    [Header("Enemy AI")]
    public NavMeshAgent enemyAgent;
    public Transform playerTransform;

    [Header("Enemy Options")]
    public float attackRadius;
    public float visionRange;
    public int damage;
    public float initialCooldown;
    private float cooldown;


    private PlayerMoney playerMoney;
    private Transform playerPosition;


    void Start()
    {
        playerPosition = FindObjectOfType<PlayerController>().GetComponent<Transform>();     
        playerMoney = FindObjectOfType<PlayerMoney>();

    }

    void Update()
    {
        FollowPlayer();
        if (cooldown > 0F)
        {
            cooldown -= Time.deltaTime;
        }
    }

    public virtual void FollowPlayer()
    {
        enemyAgent.SetDestination(playerTransform.position);
        if(Vector3.Distance(this.transform.position, playerPosition.position) <= attackRadius && cooldown <= 0F)
        {
            Attack();
        }
    }

    public virtual void Attack()
    {
        playerMoney.TakeDamage(damage);
        cooldown = initialCooldown;
    }

    private void OnDrawGizmosSelected()
    {
        #if UNITY_EDITOR
        Handles.color = Color.red;
        Handles.DrawWireDisc(this.transform.position, Vector3.up, attackRadius);
        #endif
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(this.transform.position, attackRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, visionRange);

    }
}
