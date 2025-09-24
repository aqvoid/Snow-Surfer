using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;

    private Rigidbody2D rb;

    private InputAction moveAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();

        ChangeTorque(moveVector);
    }

    private void ChangeTorque(Vector2 moveVector)
    {
        if (moveVector.x > 0f) rb.AddTorque(-torqueAmount);
        else if (moveVector.x < 0f) rb.AddTorque(torqueAmount);
    }

}
