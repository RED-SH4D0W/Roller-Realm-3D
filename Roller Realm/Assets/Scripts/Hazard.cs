using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damageAmount = 1; // Set the amount of damage this object inflicts in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
            // Check if the object that entered the trigger is the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damageAmount); // Apply damage to the player
            }
        }
    }

    void Pickup()
    {
        Destroy(gameObject);
    }
}
