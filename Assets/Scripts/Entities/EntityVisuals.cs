using UnityEngine;

public class EntityVisuals : MonoBehaviour
{
    private Color defaultColor; 
    private Renderer entityRenderer; 

    void Awake()
    {
        entityRenderer = GetComponent<Renderer>();
        if (entityRenderer != null)
        {
            defaultColor = entityRenderer.material.color;
        }
    }
    
    public void UpdateVisuals(bool isSelected)
    {
        if (entityRenderer != null)
        {
            entityRenderer.material.color = isSelected ? Color.green : defaultColor;
        }
    }
}