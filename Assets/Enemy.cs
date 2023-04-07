using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public float health, maxHealth = 3f;
    public float attackRange = 0.6f;
    private bool playerInfront;
    public LayerMask playerMask;
    public LayerMask enemyMask;
    public float attackCooldown = 1.0f;
    private float currentCooldown;
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();        
    }
    void Start()
    {
        health = maxHealth;    
        currentCooldown = attackCooldown;
    }

    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate() {
        if(movePositionTransform != null){
            Ray rayForward = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 0.6f));
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 0.6f));   
            RaycastHit hitData;
            currentCooldown -= Time.deltaTime;
            if (Physics.Raycast(rayForward, out hitData, attackRange, playerMask))
            {
                playerInfront = true;
                navMeshAgent.destination = transform.position; 

                if(playerInfront && currentCooldown <= 0f){
                    hitData.collider.gameObject.GetComponent<PlayerController>()?.TakeDamage(1f);          
                    currentCooldown = attackCooldown;
                }
            }
            else if (Physics.Raycast(rayForward, out hitData, attackRange, enemyMask))
            {
                navMeshAgent.destination = transform.position;
                playerInfront = false;
            }
            else{
                playerInfront = false;
                navMeshAgent.destination = movePositionTransform.position;            
            }             
        }
    }
}
