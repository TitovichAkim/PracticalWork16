using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    public Player player;
    public void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.tag == "Ground")
            {
                player.onGround = true;
            }
        }
    }
}
