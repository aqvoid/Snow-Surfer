using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("=== Rotation ===")]
    [SerializeField] private float torqueAmount = 1f;

    [Header("=== Movement ===")]
    [SerializeField] private float baseSpeed = 17f;
    [SerializeField] private float boostSpeed = 24f;

    [Header("=== References ===")]
    [SerializeField] private SurfaceEffector2D effector;

    private Rigidbody2D rb;
    private InputAction moveAction;
    private bool canMove = true;

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
        Vector2 moveVector = moveAction.ReadValue<Vector2>();

        if (canMove)
        {
            ChangeTorque(moveVector);
            BoostPlayer(moveVector);
        }
    }

    private void ChangeTorque(Vector2 moveVector)
    {
        if (moveVector.x > 0f) rb.AddTorque(-torqueAmount);
        else if (moveVector.x < 0f) rb.AddTorque(torqueAmount);
    }

    private void BoostPlayer(Vector2 moveVector)
    {
        if (moveVector.y > 0f) effector.speed = boostSpeed;
        else effector.speed = baseSpeed;
    }

    public void DisableControls() => canMove = false;
}
