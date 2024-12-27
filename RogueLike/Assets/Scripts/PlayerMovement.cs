using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, InputSystem.IPlayerActions
{
    public float speed = 5;
    private InputSystem inputs;
    private Vector2 direction;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject weaponPosition;
    private void Awake()
    {
        inputs = new InputSystem();
        inputs.Player.SetCallbacks(this);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        weaponPosition.transform.localPosition = new Vector3(0, -0.62f, 0);
        weaponPosition.transform.rotation = Quaternion.Euler(0, 0, -90);
    }

    public void Update()
    {
        if (direction != Vector2.zero)
        {
            animator.SetFloat("X", direction.x);
            animator.SetFloat("Y", direction.y);
            animator.SetBool("Moving", true);
            UpdateWeaponDirection();
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    public void FixedUpdate()
    {
        Move();
    }

    public void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Movement.performed += OnMovement;
    }

    public void OnDisable()
    {
        inputs.Disable();
        inputs.Player.Movement.performed -= OnMovement;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }

    public void Move()
    {
        rb.velocity = direction * speed;
    }
    public void UpdateWeaponDirection()
    {
        Dictionary<Vector2, (Vector3 position, Vector3 rotation)> weaponDirections = new Dictionary<Vector2, (Vector3, Vector3)>()
    {
        { Vector2.left,      (new Vector3(-0.62f, 0, 0),      new Vector3(0, -180, 0)) },
        { Vector2.right,     (new Vector3(0.62f, 0, 0),       new Vector3(0, 0, 0)) },
        { Vector2.down,      (new Vector3(0, -0.62f, 0),      new Vector3(0, 0, -90)) },
        { Vector2.up,        (new Vector3(0, 0.62f, 0),       new Vector3(0, 0, 90)) },
        { new Vector2(-1, -1), (new Vector3(-0.62f, -0.62f, 0), new Vector3(180, 0, 135)) },
        { new Vector2(-1, 1),  (new Vector3(-0.62f, 0.62f, 0),  new Vector3(180, 0, 235)) },
        { new Vector2(1, -1),  (new Vector3(0.62f, -0.62f, 0),  new Vector3(0, 0, -45)) },
        { new Vector2(1, 1),   (new Vector3(0.62f, 0.62f, 0),   new Vector3(0, 0, 45)) }
    };

        Vector2 normalizedDirection = new Vector2(Mathf.Round(direction.x), Mathf.Round(direction.y));
        if (weaponDirections.TryGetValue(normalizedDirection, out var values))
        {
            weaponPosition.transform.localPosition = values.position;
            weaponPosition.transform.localRotation = Quaternion.Euler(values.rotation);
        }
    }

}
