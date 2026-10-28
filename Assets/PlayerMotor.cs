using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    public float Acceleration = 10.0f;
    public float JumpForce = 10.0f;
    private Vector2 direction;
    private Rigidbody2D rigidbody2D;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


        private void FixedUpdate()
    { 
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(direction);
    }
    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
    void OnJump()
    {
        Rigidbody2D rigidbody2D2 = GetComponent<Rigidbody2D>();
        rigidbody2D2.AddForce(Vector2.up * JumpForce);
    }
}


