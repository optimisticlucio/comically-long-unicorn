using UnityEngine;

public class CupHolder : MonoBehaviour
{
    [SerializeField] public DraggableBobaTea m_HeldCup;
    [SerializeField] private float detectionRadius = 1.0f;  // Radius to check for cups
    [SerializeField] private LayerMask cupLayerMask;  // Assign in the inspector to detect cup objects
    [SerializeField] private Vector3 snapOffset = Vector3.zero;  // Adjust if needed to fine-tune position
    [SerializeField] float m_timeToReleaseCup = 0.1f;

    public BobaTea m_BobaTea;

    void Update()
    {
        CheckForCup();

        if(m_HeldCup != null && m_HeldCup.GetDraggable() == false)
        {
            m_timeToReleaseCup -= Time.deltaTime;
            if(m_timeToReleaseCup <= 0)
            {
                m_HeldCup.SetIsDragging(false);
                m_HeldCup.SetDraggable(true);
                m_timeToReleaseCup = 0.1f;
            }
        }
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
                SnapCupToHolder();
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
            m_HeldCup.SetDraggable(false);  // Disable dragging while in the holder
            m_HeldCup.transform.position = transform.position + snapOffset;
        }
    }

    // Draw the detection area in the Scene view for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
