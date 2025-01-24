using UnityEngine;

public class CupHolder : MonoBehaviour
{
    [SerializeField] public DraggableBobaTea m_HeldCup;
    [SerializeField] private float detectionRadius = 1.0f;  // Radius to check for cups
    [SerializeField] private LayerMask cupLayerMask;  // Assign in the inspector to detect cup objects
    [SerializeField] private Vector3 snapOffset = Vector3.zero;  // Adjust if needed to fine-tune position

    public BobaTea m_BobaTea;

    void Update()
    {
        CheckForCup();
    }

    void CheckForCup()
    {
        Collider2D cupCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, cupLayerMask);

        if (cupCollider != null)
        {
            DraggableBobaTea detectedCup = cupCollider.GetComponent<DraggableBobaTea>();

            if (detectedCup != null && m_HeldCup == null)
            {
                m_HeldCup = detectedCup;
                // SnapCupToHolder();
                Debug.Log("Cup snapped to holder!");
            }
        }
        else
        {
            if (m_HeldCup != null)
            {
                Debug.Log("Cup removed from holder.");
                m_HeldCup = null;
            }
        }
    }

    void SnapCupToHolder()
    {
        if (m_HeldCup != null)
        {
            m_HeldCup.transform.position = transform.position + snapOffset;
            m_HeldCup.SetDraggable(false);  // Disable dragging while in the holder
        }
    }

    // Draw the detection area in the Scene view for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
