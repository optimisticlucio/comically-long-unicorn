using UnityEngine;

public class CustomerHolder : MonoBehaviour
{
    [SerializeField] public Customer m_Customer;
    [SerializeField] public SpriteRenderer m_CustomerSpriteRenderer;

    public void Initialize(Customer customer, Sprite sprite)
    {
        m_Customer = customer;
        
        // Ensure the SpriteRenderer is assigned (Add it dynamically if missing)
        if (m_CustomerSpriteRenderer == null)
        {
            m_CustomerSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        m_CustomerSpriteRenderer.sprite = sprite;

        m_CustomerSpriteRenderer.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }
}
