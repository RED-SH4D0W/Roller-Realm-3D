using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material[] materials;
    private int currentMaterialIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SwitchMaterial();
        }
    }

    void SwitchMaterial()
    {
        // Cycle through materials
        currentMaterialIndex = (currentMaterialIndex + 1) % materials.Length;

        // Change the material on the renderer
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = materials[currentMaterialIndex];
        }
    }
}
