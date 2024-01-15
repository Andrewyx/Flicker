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

    private AudioSource _audioSource;
    public AudioClip[] hit;
    public AudioClip death;

    private NavMeshAgent navMeshAgent;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();        
    }
    void Start()
    {
        health = maxHealth;    
        currentCooldown = attackCooldown;
        _audioSource = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damageAmount){
        health -= damageAmount;

        _audioSource.PlayOneShot(hit[Random.Range(0,hit.Length)]);

        if(health <= 0)
        {
            AudioSource.PlayClipAtPoint(death, transform.position, 1f);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate() {
        if(movePositionTransform != null){
            Ray rayForward = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 0.6f));
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 0.6f));   
            RaycastHit hitData;
            
            if (Physics.Raycast(rayForward, out hitData, attackRange, playerMask))
            {
                playerInfront = true;
                currentCooldown -= Time.deltaTime;
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
