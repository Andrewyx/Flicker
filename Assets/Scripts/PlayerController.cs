using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    CandleAnimations candleAnimations;
    public static PlayerController instance;
    public GameObject candle;
    public GameObject startLocation;
    public LayerMask layerMask;
    public LayerMask enemyMask;
    public LayerMask tempObstructMask;
    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;
    Ray attackRay;
    RaycastHit attackHit;        
    public float health, maxHealth = 3f;
    public bool smoothTransition = true;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;
    public float rayLength = 0.6f;    
    private bool obstructForward, obstructBackward, obstructLeft, obstructRight;
    public bool obstructAbove, obstructUnder;
    
    private AudioSource _audioSource;
    public AudioClip ow;

    //heart stuff
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void RotateLeft(){if (AtRest) targetRotation -= Vector3.up * 90f;}
    public void RotateRight(){if (AtRest) targetRotation += Vector3.up * 90f;}
    public void MoveForward(){if (AtRest && !obstructForward){
        targetGridPos += transform.forward;
        }
    }
    public void MoveBackward(){if (AtRest && !obstructBackward) {
        targetGridPos -= transform.forward;
        }
    }
    public void MoveLeft(){if (AtRest && !obstructLeft) {
        targetGridPos -= transform.right;
        }   
    }
    public void MoveRight(){if (AtRest && !obstructRight) {
        targetGridPos += transform.right;
        }
    }

    public void swapDimension(){
        if (transform.position.y > 2.5f && AtRest && !obstructUnder) {
            targetGridPos += transform.up * -3f;
            }

        else if (transform.position.y < 2.5f && AtRest && !obstructAbove){
            targetGridPos += transform.up * 3f;
            }        
        transform.position = targetGridPos;
        transform.rotation = Quaternion.Euler(targetRotation);            
    }     

    bool AtRest {
        get {

            if ((Vector3.Distance(transform.position, targetGridPos) < 0.05f) && 
                (Vector3.Distance(transform.eulerAngles, targetRotation) <0.05f))
                return true;
            else 
                return false;
        }
    }

    public void initiateAttack(){
        if(Physics.Raycast(attackRay, out attackHit, 1.2f, enemyMask) && candleAnimations.attackability){
            Debug.Log("Hit Enemy!");
            attackHit.collider.gameObject.GetComponent<Enemy>()?.TakeDamage(1f); 
        }
        else{
            Debug.Log("refeshing...");
        }
    } 
    public void addWax(float waxAmount){
        if(transform.position.y > 2.5f){
            GetComponent<CandleDrain>().upTimeLeft += waxAmount;
        }
        else if (transform.position.y < 2.5f){
            GetComponent<CandleDrain>().downTimeLeft += waxAmount;
        }
    }
        


    void MovePlayer(){
        if(true) {
            prevTargetGridPos = targetGridPos;
            Vector3 targetPosition = targetGridPos;
            if(targetRotation.y > 270f && targetRotation.y < 361f) targetRotation.y = 0f;
            if(targetRotation.y < 0f ) targetRotation.y = 270f;
            
            if(!smoothTransition){
                transform.position = targetPosition;
                transform.rotation = Quaternion.Euler(targetRotation);
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * transitionRotationSpeed);
            }

        }
    }
    public void collisionDetect(){
        Ray rayForward = new Ray(transform.position, transform.TransformDirection(Vector3.forward * rayLength));
        Ray rayBackward = new Ray(transform.position, transform.TransformDirection(Vector3.back * rayLength));
        Ray rayLeft = new Ray(transform.position, transform.TransformDirection(Vector3.left * rayLength));
        Ray rayRight = new Ray(transform.position, transform.TransformDirection(Vector3.right * rayLength));

        Ray rayUp = new Ray(transform.position, transform.TransformDirection(Vector3.up * 4.0f));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up * 4.0f));
        Ray rayDown = new Ray(transform.position, transform.TransformDirection(Vector3.down * 4.0f));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down * 4.0f));            

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * rayLength));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back * rayLength));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right * rayLength));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.left * rayLength));
        
        RaycastHit hitData;
        if (Physics.Raycast(rayForward, out hitData, rayLength, layerMask) || Physics.Raycast(rayForward, out hitData, 1f, enemyMask))
        {
            obstructForward = true;
        }    
        else{
            obstructForward = false;
        }
        if (Physics.Raycast(rayBackward, out hitData, rayLength, layerMask) || Physics.Raycast(rayBackward, out hitData, rayLength, enemyMask))
        {
            obstructBackward = true;
        }    
        else{
            obstructBackward = false;
        }
        if (Physics.Raycast(rayLeft, out hitData, rayLength, layerMask) || Physics.Raycast(rayLeft, out hitData, rayLength, enemyMask))
        {
            obstructLeft = true;
        }    
        else{
            obstructLeft = false;
        }                
        if (Physics.Raycast(rayRight, out hitData, rayLength, layerMask) || Physics.Raycast(rayRight, out hitData, rayLength, enemyMask))
        {
            obstructRight = true;
        }    
        else{
            obstructRight = false;
        }
        if (transform.position.y < 2.5f){
            if (Physics.Raycast(rayUp, out hitData, 4.0f, layerMask))
            {
                obstructAbove = true;
                //Debug.Log("Something is above!");
            }    
            else{
                obstructAbove = false;
                //Debug.Log("Above is clear");
            }        
        }
        else if (transform.position.y > 2.5f){
            if (Physics.Raycast(rayDown, out hitData, 4.0f, layerMask))
            {
                obstructUnder = true;
                //Debug.Log("Something is below!");
            }    
            else{
                obstructUnder = false;
                //Debug.Log("Below is clear");
            }                    
            
        }
    }
    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        _audioSource.PlayOneShot(ow, 0.5f);
        if(health <= 0)
        {
            
            FindObjectOfType<GameManager>().isDead = true;
            FindObjectOfType<GameManager>().EndGame();
            candle.GetComponent<CandleAnimations>().enabled = false;
            Object.Destroy(candle);
            GetComponent<PlayerController>().enabled = false;
        }
    }
    private void Awake()
    {
        candleAnimations = candle.GetComponent<CandleAnimations>();
    }        
    void Start()
    {
        targetGridPos = startLocation.transform.position;
        health = maxHealth;
        instance = this;
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate() {
        attackRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 1f));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 1f));
        collisionDetect();
        MovePlayer();
        if(health > maxHealth){
            health = maxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i < health){
                hearts[i].sprite = fullHeart;
            }
            else{
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth){
                hearts[i].enabled = true;
            }
            else{
                hearts[i].enabled = false;
            }
        }        
    }
}    
