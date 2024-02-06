// Spawn.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject itemPrefab;
    private Transform player;
    public string itemName;
    public bool CanDeleteItem = true; // Add this line

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnDroppedItem()
    {
        if (CanDeleteItem)
        {
            Vector3 playerPosition = new Vector3(player.position.x, player.position.y, player.position.z + 4);
            Instantiate(itemPrefab, playerPosition, Quaternion.identity);
        }
    }
}
