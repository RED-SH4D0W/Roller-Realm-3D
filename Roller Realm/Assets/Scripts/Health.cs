using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 1; // Set the amount of health this pickup provides in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the object that entered the trigger is the player
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.IncreaseHealth(healthAmount); // Increase the player's health
                Destroy(gameObject); // Remove the health pickup object
            }
        }
    }
}
