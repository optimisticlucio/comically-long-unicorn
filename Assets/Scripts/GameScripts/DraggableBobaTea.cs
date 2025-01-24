using UnityEngine;

public class DraggableBobaTea : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private bool isDraggable = true;

    public BobaTea m_BobaTea;

    [SerializeField] Sprite m_LiquidSprite;

    [SerializeField] Sprite m_TapiocaSprite;

    [SerializeField] Sprite m_LidSprite;

    void Update()
    {
        if (!isDraggable) return;

        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseDown();
        }

        if (isDragging && Input.GetMouseButton(0))
        {
            DragObject();
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }

    private void CheckMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    private void DragObject()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }

    public void UpdateVisuals() {
        Sprite appropriateDrinkSprite = m_BobaTea.m_Liquid.GetSprite();
        // TODO - Actually update.
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    public void SetDraggable(bool draggable)
    {
        isDraggable = draggable;
    }
}
