using UnityEngine;

public class Player
{
    // Encapsulated fields (private)
    private float _moveSpeed;
    private float _jumpForce;
    private int _health;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Collider2D col;

    public Player(float Speed, float JumpForce, int Health, Rigidbody2D rigidbody, Collider2D collider)
    {
        this._moveSpeed = Speed;
        this._jumpForce = JumpForce;
        this._health = Health;
        this.rb = rigidbody;
        this.col = collider;
        
        // Increase gravity
        rb.gravityScale = 2f;
    }

    public int GetHealth()
    {
        return this._health;
    }

    // Method for handling horizontal movement input only
    public void HandleInput()
    {
        // Horizontal input (A/D or Left/Right arrows)
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = 0f; 

        // Check for jump input and execute Jump() if space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Jump();
        }
    }


    public void Move()
    {
        // horizontal movement input
        rb.linearVelocity = new Vector2(moveInput.x * _moveSpeed, rb.linearVelocity.y);
    }

    public void Jump() 
    {
        // check if player on ground
        if (Mathf.Abs(rb.linearVelocity.y) < 0.001f) 
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, _jumpForce);
        }
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;
        Debug.Log($"Player health: {this._health}, Damage taken: {damage}");
        if (_health <= 0) 
        {
            Debug.Log($"Ur dead");
            // add death screen thing
        }
    }
}


//Encapsulation: objects are private can only be accessed through public methods
//Classes and Objects: player class is created with a constructor and instantiated in `PlayerMovement`
//Constructor: player class has a constructor that takes speed and Rigidbody2D as parameters
//Composition: Contructor uses instance of rigidbody2d and collider2d classes