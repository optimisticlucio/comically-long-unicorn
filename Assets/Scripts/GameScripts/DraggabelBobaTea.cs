using UnityEngine;
using UnityEngine.EventSystems;

public class DraggabelBobaTea : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 originalPosition;
    private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public BobaTea bobaTea;

    private void Start()
    {
        canvas = FindObjectOfType<Canvas>();  // Find the UI canvas
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
            print("canvas is null");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;
        canvasGroup.alpha = 0.6f; // Make it slightly transparent while dragging
        canvasGroup.blocksRaycasts = false;  // Prevent blocking raycasts to detect drop targets
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition;  // Follow the mouse position
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;

        if (!TryDeliverBoba(eventData))
        {
            rectTransform.position = originalPosition;  // Reset position if not delivered
        }
    }

    private bool TryDeliverBoba(PointerEventData eventData)
    {
        GameObject target = eventData.pointerCurrentRaycast.gameObject;
        if (target != null && target.CompareTag("Customer"))
        {
            if (target.GetComponent<Customer>().CompareToDesiredDrink(bobaTea))
            {
                Debug.Log("Boba delivered to the customer!");
                Destroy(gameObject); // Remove the Boba after delivery
                return true;
            }
        }
        return false;
    }
}
