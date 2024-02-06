using UnityEngine;
using TMPro;

public class PlayerCoordinatesDisplayTMP : MonoBehaviour
{
    public TMP_Text coordinatesText;
    public Transform playerTransform;  // Player transform
    public Transform cameraTransform;  // Camera transform

    void Update()
    {
        if (coordinatesText != null && playerTransform != null && cameraTransform != null)
        {
            float x = playerTransform.position.x;
            float z = playerTransform.position.z;
            float rotationY = cameraTransform.eulerAngles.y; // Y rotation from the camera

            coordinatesText.text = "X: " + x.ToString("F2")  + "\nZ: " + z.ToString("F2") + "\nRotationY: " + rotationY.ToString("F2");
        }
    }
}
