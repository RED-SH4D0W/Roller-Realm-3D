using UnityEngine;

public class PageSwitcher : MonoBehaviour
{
    public Canvas canvas; // Reference to your Canvas
    public int targetPageIndex; // Index of the page you want to activate
    public float yRangeThreshold = -5f; // Y-axis threshold for switching pages

    private void Update()
    {
        // Assuming your GameObject's Y position triggers the page switch
        if (transform.position.y < yRangeThreshold)
        {
            SwitchPage();
        }
    }

    void SwitchPage()
    {
        // Make sure the targetPageIndex is within the valid range of pages in your Canvas
        if (targetPageIndex >= 0 && targetPageIndex < canvas.transform.childCount)
        {
            // Deactivate all pages
            for (int i = 0; i < canvas.transform.childCount; i++)
            {
                canvas.transform.GetChild(i).gameObject.SetActive(false);
            }

            // Activate the specific page
            canvas.transform.GetChild(targetPageIndex).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid targetPageIndex. Please set a valid index within the range of canvas pages.");
        }
    }
}
