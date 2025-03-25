using UnityEngine;

public class FallingObjectCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collidedObject = collision.gameObject;

        // destroy if hitting bottom wall
        if (collidedObject.CompareTag("Bottom"))
        {
            Destroy(gameObject);
            return;
        }

        // if hitting the player, take damage then destroy self
        if (collidedObject.CompareTag("User"))
        {
            // access player object from playermovement.cs to take damage
            PlayerMovement pm = collidedObject.GetComponent<PlayerMovement>();
            if (pm != null && pm.player != null)
            {
                pm.player.TakeDamage(5);
            }
            Destroy(gameObject);
        }
    }
}
