using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    public Canvas canvas;
    public string playerTag = "Player";
    public float activationRange = 5f;

    void Update()
    {
        // Check if the "F" key is pressed
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Check if the player is within the activation range
            if (IsPlayerInRange())
            {
                // Toggle the Canvas's active state
                if (canvas != null)
                {
                    canvas.gameObject.SetActive(!canvas.gameObject.activeSelf);
                }
            }
        }
    }

    bool IsPlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);

        if (player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            return distance <= activationRange;
        }

        return false;
    }
}
