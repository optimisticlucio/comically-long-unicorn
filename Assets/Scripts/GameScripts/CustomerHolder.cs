using UnityEngine;

public class CustomerHolder : MonoBehaviour
{
    [SerializeField] public Customer m_Customer;
    [SerializeField] public SpriteRenderer m_CustomerSpriteRenderer;
    [SerializeField] private float detectionRadius = 1.0f;
    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        checkForCup();
        if(m_Customer.isAnnoyed())
        {
            print("Customer is annoyed!");
        } 
    }

    void checkForCup()
    {
        Collider2D cupCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, layerMask);

        if (cupCollider != null)
        {
            DraggableBobaTea cup = cupCollider.GetComponent<DraggableBobaTea>();
            if (cup != null)
            {
                if (m_Customer.CompareToDesiredDrink(cup.m_BobaTea))
                {
                    print("Customer is happy!");
                    Destroy(cup.gameObject);
                    // Destroy(gameObject);
                }
                else
                {
                    print("Not my cup");
                }
            }
        }
    }

    // Draw the detection area in the Scene view for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

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
