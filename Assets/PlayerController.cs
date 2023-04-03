using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool smoothTransition = true;
    public float transitionSpeed = 10f;
    public float transitionRotationSpeed = 500f;

    public MapArray2D mapArray2D;

    Vector3 targetGridPos;
    Vector3 prevTargetGridPos;
    Vector3 targetRotation;

    public GameObject startLocation;

    public void RotateLeft(){if (AtRest) targetRotation -= Vector3.up * 90f;}
    public void RotateRight(){if (AtRest) targetRotation += Vector3.up * 90f;}
    public void MoveForward(){if (AtRest) targetGridPos += transform.forward;}
    public void MoveBackward(){if (AtRest) targetGridPos -= transform.forward;}
    public void MoveLeft(){if (AtRest) targetGridPos -= transform.right;}
    public void MoveRight(){if (AtRest) targetGridPos += transform.right;}


    public void swapDimension(){
        if (transform.position.y == 3f && AtRest) {
            targetGridPos += transform.up * -3f;
            }

        else if (transform.position.y == 0f && AtRest){
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



    void MovePlayer(){
        if(collisionDetect()) {
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
    private bool collisionDetect(){
        if (mapArray2D.lightMap[Mathf.Abs((int)targetGridPos.z), Mathf.Abs((int)targetGridPos.x)] != 1){     
            return true;
        }
        else {
            return false;
        }
    }
    void Start()
    {
        targetGridPos = Vector3Int.RoundToInt(startLocation.transform.position);
    }


    private void FixedUpdate() {
        MovePlayer();
    }
}    
