using UnityEngine;

public class Player
{
    private float moveSpeed; // Encapsulation
    private Vector2 moveInput;
    private Rigidbody2D rb;

    // Constructor
    public Player(float speed, Rigidbody2D rigidbody)
    {
        moveSpeed = speed;
        rb = rigidbody;
    }

    // Method for handling movement logic
    public void HandleInput()
    {
        // GetAxisRaw("Horizontal") detects A which is -1 and D = 1  making the player move left or right
        // GetAxisRaw("Vertical") detects W = 1 and S = -1, making the player move up or down
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize(); //this i found online, which makes so diagonal isnt faster than straight as it prevents
                               //horizontal and vertical add together
    }

    // Method for moving
    public void Move()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}

public class PlayerMovement : MonoBehaviour
{
    private Player player; // This is composition as it uses player class

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        player = new Player(5f, rb); // creates instance of Player with encapsulated speed and rigid body
    }

    void Update()
    {
        player.HandleInput(); // Call method to process input
    }

    void FixedUpdate()
    {
        player.Move(); // Call method to move the player
    }
}

//Concepts Used:
//Encapsulation: moveSpeed is private and can only be accessed  within Player class.
//Classes and Objects: player class is created with a constructor and instantiated in `PlayerMovement`
//Constructor: player class has a constructor that takes speed and Rigidbody2D as parameters
//Composition: playermovemen class uses an instance of `Player` instead of doing movement directl