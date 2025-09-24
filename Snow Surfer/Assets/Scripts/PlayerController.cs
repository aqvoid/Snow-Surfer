using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction moveAction;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();
        Debug.Log(moveVector);

    }

}
