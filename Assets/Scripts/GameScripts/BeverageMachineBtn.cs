using UnityEngine;
using UnityEngine.UI;

public class BeverageMachineBtn : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] BobaTea.Liquid m_DispensedLiquid = BobaTea.Liquid.None;

    [SerializeField] Sprite m_pressedSprite;
    [SerializeField] Sprite m_unpressedSprite;

    private SpriteRenderer m_SpriteRenderer;


    public BeverageMachine m_ParentBeverageMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_SpriteRenderer = button.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_unpressedSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private bool CheckMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }

    void OnMouseDown()
    {
        m_SpriteRenderer.sprite = m_pressedSprite;
        print("Mouse Clicked on Beverage Machine Btn");
        m_ParentBeverageMachine.AddLiquidToCup(m_DispensedLiquid);
    }

    void OnMouseUp()
    {
        m_SpriteRenderer.sprite = m_unpressedSprite;
    }

}
