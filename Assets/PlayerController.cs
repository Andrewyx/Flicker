using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CandleAnimations candleAnimations;
    public static PlayerController instance;
    public GameObject candle;
    public float health, maxHealth = 3f;
    public bool smoothTransition = true;
    private bool onFirstFloor = true;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;
    public LayerMask layerMask;
    public LayerMask enemyMask;
    //public MapArray2D mapArray2D;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;
    public float rayLength = 0.6f;
    Ray attackRay;
    RaycastHit attackHit;

    public GameObject startLocation;
    private bool obstructForward, obstructBackward, obstructLeft, obstructRight;
    private bool obstructAbove, obstructUnder;

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
        if (transform.position.y == 3.5f && AtRest && !obstructUnder) {
            targetGridPos += transform.up * -3f;
            }

        else if (transform.position.y == 0.5f && AtRest && !obstructAbove){
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
        if(Physics.Raycast(attackRay, out attackHit, 1f, enemyMask) && candleAnimations.attackability){
            Debug.Log("Hit Enemy!");
            attackHit.collider.gameObject.GetComponent<Enemy>()?.TakeDamage(1f); 
        }
        else{
            Debug.Log("refeshing...");
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
        else {
            targetGridPos = prevTargetGridPos;
        }
    }
    private void collisionDetect(){
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
        if (Physics.Raycast(rayForward, out hitData, rayLength, layerMask))
        {
            obstructForward = true;
        }    
        else{
            obstructForward = false;
        }
        if (Physics.Raycast(rayBackward, out hitData, rayLength, layerMask))
        {
            obstructBackward = true;
        }    
        else{
            obstructBackward = false;
        }
        if (Physics.Raycast(rayLeft, out hitData, rayLength, layerMask))
        {
            obstructLeft = true;
        }    
        else{
            obstructLeft = false;
        }                
        if (Physics.Raycast(rayRight, out hitData, rayLength, layerMask))
        {
            obstructRight = true;
        }    
        else{
            obstructRight = false;
        }
        if (transform.position.y == 0.5f){
            if (Physics.Raycast(rayUp, out hitData, 4.0f, layerMask))
            {
                obstructAbove = true;
                //Debug.Log("Something is above!");
            }    
            else{
                obstructAbove = false;
                //Debug.Log("Above is Clear");
            }        
        }
        else if (transform.position.y == 3.5f){
            if (Physics.Raycast(rayDown, out hitData, 4.0f, layerMask))
            {
                obstructUnder = true;
                //Debug.Log("Something is Below!");
            }    
            else{
                obstructUnder = false;
                //Debug.Log("Above is Clear");
            }                    
            
        }
    }
    public void TakeDamage(float damageAmount){
        health -= damageAmount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
        
    void Start()
    {
        targetGridPos = startLocation.transform.position;
        health = maxHealth;
        instance = this;

    }

    private void Awake()
    {
        candleAnimations = candle.GetComponent<CandleAnimations>();
    }

    private void FixedUpdate() {
        attackRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 1f));
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 1f));
        collisionDetect();
        MovePlayer();
    }
}    
