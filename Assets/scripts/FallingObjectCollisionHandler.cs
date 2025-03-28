using UnityEngine;

public class FallingObjectCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collided = collision.gameObject;

        // kill self if it hits the bottom wall
        if (collided.CompareTag("Bottom"))
        {
            Destroy(gameObject);
            return;
        }

        // damage player on collision, then kill self
        if (collided.CompareTag("User"))
        {
            PlayerMovement pm = collided.GetComponent<PlayerMovement>();
            if (pm != null && pm.player != null)
            {
                int diff = PlayerPrefs.GetInt("difficulty", 1);

                if (diff == 0) {
                    // easy mode: 40 hits until dead
                    pm.player.TakeDamage(3);
                } else if (diff == 1) { 
                    // medium mode: 30 hits until dead
                    pm.player.TakeDamage(4);
                } else {        
                    // hard mode: 20 hits until dead        
                    pm.player.TakeDamage(6);
                }
            }
            Destroy(gameObject);
        }
    }
}
