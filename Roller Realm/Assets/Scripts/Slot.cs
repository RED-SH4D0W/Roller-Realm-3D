// Slot.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
    private InventoryController inventory;
    public int i;
    public TextMeshProUGUI amountText;
    public int amount;
    public Spawn spawnScript; // Reference to the Spawn script attached to the slot

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<InventoryController>();
        spawnScript = transform.GetComponentInChildren<Spawn>(); // Assuming Spawn script is a child of the slot
    }

    // Update is called once per frame
    void Update()
    {
        amountText.text = amount.ToString();

        if (amount > 1)
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        }

        if (transform.childCount == 2)
        {
            inventory.isFull[i] = false;
        }
    }

    public void DropItem()
    {
        if (spawnScript != null && spawnScript.CanDeleteItem)
        {
            if (amount > 1)
            {
                amount -= 1;
                spawnScript.SpawnDroppedItem();
            }
            else
            {
                amount -= 1;
                GameObject.Destroy(spawnScript.gameObject);
                spawnScript.SpawnDroppedItem();
            }
        }
    }
}
