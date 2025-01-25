using UnityEngine;
using UnityEngine.UI;

public class BeverageMachineBtn : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] BobaTea.Liquid m_DispensedLiquid = BobaTea.Liquid.None;

    [SerializeField] Sprite m_pressedSprite;
    [SerializeField] Sprite m_unpressedSprite;
    [SerializeField] private AudioClip clickSound;  // Drag audio clip here


    private SpriteRenderer m_SpriteRenderer;

    private AudioSource audioSource;

    public BeverageMachine m_ParentBeverageMachine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_SpriteRenderer = button.GetComponent<SpriteRenderer>();
        m_SpriteRenderer.sprite = m_unpressedSprite;

        // Get the AudioSource component from the GameObject
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Please add an AudioSource to the GameObject.");
        }
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
        print("Mouse Down on Beverage Machine Btn");
        m_SpriteRenderer.sprite = m_pressedSprite;
        // Play click sound
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        print("Mouse Clicked on Beverage Machine Btn");
        m_ParentBeverageMachine.AddLiquidToCup(m_DispensedLiquid);
    }

    void OnMouseUp()
    {
        m_SpriteRenderer.sprite = m_unpressedSprite;
    }

}
