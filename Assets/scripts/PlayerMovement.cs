using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HealthBar healthBar;
    public Player player; 
    void Start()
    {
        // get the rigidbody2D & collider2D component attached to the game object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Collider2D col = GetComponent<Collider2D>(); 
        
        //new player
        player = new Player(7f, 10f, 100, rb, col);
        // player = GetComponent<Player>();

        healthBar.SetMaxHealth(100);
    }

    void Update()
    {
        // process input for each frame for player  movement
        player.HandleInput();
        healthBar.SetHealth(player.GetHealth());
        healthBar.UpdateFillColor();
    }

    void FixedUpdate()
    {
        // apply the movement 
        player.Move();
    }
}
