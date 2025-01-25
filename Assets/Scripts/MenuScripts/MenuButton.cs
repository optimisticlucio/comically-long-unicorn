using UnityEngine;
using UnityEngine.Events;

public class MenuButton : MonoBehaviour
{
    [SerializeField] private Sprite m_hoverSprite;  // Sprite when hovering
    [SerializeField] private Sprite m_Sprite;       // Normal sprite
    [SerializeField] private UnityEvent onClickEvent;  // Function to call when clicked

    private SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        // Get SpriteRenderer component attached to the object
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        if (m_SpriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on " + gameObject.name);
            return;
        }

        m_SpriteRenderer.sprite = m_Sprite;  // Set default sprite
    }

    void OnMouseEnter()
    {
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.sprite = m_hoverSprite;  // Change sprite on hover
        }
    }

    void OnMouseExit()
    {
        if (m_SpriteRenderer != null)
        {
            m_SpriteRenderer.sprite = m_Sprite;  // Reset to default sprite when mouse exits
        }
    }

    void OnMouseDown()
    {
        // When the sprite is clicked, invoke the assigned function
        if (onClickEvent != null)
        {
            onClickEvent.Invoke();
        }
        else
        {
            Debug.Log("No function assigned to button click event on " + gameObject.name);
        }
    }
}
