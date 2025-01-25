using UnityEngine;

public class ToppingButton : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] BobaTea.Topping m_DispensedTopping = BobaTea.Topping.None;

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
        if (m_pressedSprite == null) {
            m_pressedSprite = m_unpressedSprite;
        }

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
        print("Mouse Down on Topping Button for " + m_DispensedTopping);
        m_SpriteRenderer.sprite = m_pressedSprite;
        // Play click sound
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        print("Mouse Clicked on Topping Button for " + m_DispensedTopping);
        m_ParentBeverageMachine.AddToppingToCup(m_DispensedTopping);
    }

    void OnMouseUp()
    {
        m_SpriteRenderer.sprite = m_unpressedSprite;
    }

}
