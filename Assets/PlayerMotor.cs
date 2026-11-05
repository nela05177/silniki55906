using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    public float Acceleration = 10.0f;
    public float JumpForce = 10.0f;
    public float MaxSpeed = 10.0f;
    private Vector2 direction;
    private Rigidbody2D rigidbody2D;
    public int maxJump = 1;
    private int currentJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }


       private void FixedUpdate()
    {
        MovePlayer();

        LimitMaxSpeed();
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x, 0) * Acceleration);
    }

    private void LimitMaxSpeed()
    {
        if (rigidbody2D.linearVelocityX >= MaxSpeed)
        {
            rigidbody2D.linearVelocityX = MaxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -MaxSpeed)
        {
            rigidbody2D.linearVelocityX = -MaxSpeed;
        }
    }

    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    void OnJump()
    {
        if (currentJump < maxJump)
        {


            rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            ++currentJump;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentJump = 0;
    }
}


