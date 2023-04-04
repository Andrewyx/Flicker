using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
public class PlayerInput : MonoBehaviour
{
    public KeyCode forward = KeyCode.W;
    public KeyCode back = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode turnLeft = KeyCode.Q;
    public KeyCode turnRight = KeyCode.E;
    public KeyCode duality = KeyCode.Space;
    public KeyCode attack = KeyCode.Mouse1;
    public KeyCode interact = KeyCode.Mouse0;
    
PlayerController controller;

    private void Awake() {
        controller = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp((forward))) controller.MoveForward();
        if (Input.GetKeyUp((back))) controller.MoveBackward();
        if (Input.GetKeyUp((left))) controller.MoveLeft();
        if (Input.GetKeyUp((right))) controller.MoveRight();
        if (Input.GetKeyUp((turnLeft))) controller.RotateLeft();
        if (Input.GetKeyUp((turnRight))) controller.RotateRight();
        if (Input.GetKeyDown((duality))) controller.swapDimension();
        if (Input.GetKeyDown((attack))) controller.initiateAttack();

    }
}
