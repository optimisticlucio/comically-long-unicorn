using UnityEngine;

public class DraggableBobaTea : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private bool isDraggable = true;

    public BobaTea m_BobaTea = new BobaTea();

    [SerializeField] SpriteRenderer m_LiquidSprite;

    [SerializeField] SpriteRenderer m_TapiocaSprite;

    [SerializeField] SpriteRenderer m_LidSprite;

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
        if (m_LiquidSprite != null) {
            m_LiquidSprite.sprite = m_BobaTea.m_Liquid.GetSprite();
        }
        else {
            Debug.LogError("Missing Liquid Sprite in cup!");
        }

        if (m_TapiocaSprite != null) {
            m_TapiocaSprite.sprite = m_BobaTea.m_Tapioca.GetSpriteFloating();
        }
        else {
            Debug.LogError("Missing Tapioca Sprite in cup!");
        }

        if (m_LidSprite != null) {
            m_LidSprite.enabled = m_BobaTea.m_Lidded;
        }
        else {
            Debug.LogError("Missing Lid Sprite in cup!");
        }
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
