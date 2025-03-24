using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player player; 
    void Start()
    {
        // get the rigidbody2D & collider2D component attached to the game object
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Collider2D col = GetComponent<Collider2D>(); 
        
        //new player
        player = new Player(5f, 10f, rb, col);
        // player = GetComponent<Player>();
    }

    void Update()
    {
        // process input for each frame for player  movement
        player.HandleInput();
    }

    void FixedUpdate()
    {
        // apply the movement 
        player.Move();
    }
}
