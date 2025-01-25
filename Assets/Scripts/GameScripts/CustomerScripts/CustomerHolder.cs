using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerHolder : MonoBehaviour
{
    [SerializeField] public Customer m_Customer;
    [SerializeField] public SpriteRenderer m_CustomerSpriteRenderer;
    [SerializeField] public SpriteRenderer m_CustomerbubbleSpriteRenderer;
    private DraggableBobaTea m_Cup = new DraggableBobaTea();
    [SerializeField] private float detectionRadius = 1.0f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioClip annoyedSound;  // Drag audio clip here
    [SerializeField] private AudioClip enterSound;    // Drag audio clip here
    [SerializeField] private List<AudioClip> happySounds;  // Drag happy sounds here
    [SerializeField] private AudioClip angrySound;    // Drag angry sound here

    private AudioSource audioSource;

    [SerializeField] public float m_iterationOfAnnoyed = 3.0f;
    public float m_annoyedTimeWaiting = 0;

    public int m_SpawnPointUsed = -1; // The Spawnpoint this customer is standing on.

    private bool isPlayingSound = false;  // Track if a sound is playing

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Please add an AudioSource to the GameObject.");
        }
    }

    void Update()
    {
        m_Customer.Update();
        checkForCup();

        if (m_Customer.isAnnoyed())
        {
            print("Customer is annoyed!");

            if (isAnnoyedIteration() && !isPlayingSound)
            {
                PlaySound(annoyedSound);
                m_annoyedTimeWaiting = 0;
            }

            m_annoyedTimeWaiting += Time.deltaTime;
        }
    }

    void checkForCup()
    {
        Collider2D cupCollider = Physics2D.OverlapCircle(transform.position, detectionRadius, layerMask);

        if (cupCollider != null)
        {
            DraggableBobaTea cup = cupCollider.GetComponent<DraggableBobaTea>();
            if (cup != null && !cup.isDragging)
            {
                if (m_Customer.CompareToDesiredDrink(cup.m_BobaTea))
                {
                    isPlayingSound = false;
                    PlayRandomHappySound();
                    print("Customer is happy!");
                }
                else
                {
                    print("Not my cup");
                    if(!isPlayingSound)
                        PlaySound(angrySound);
                }
                Destroy(cup.gameObject);
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
        if (m_Customer == null)
        {
            print("Customer not successfully set.");
        }

        // Ensure the SpriteRenderer is assigned (Add it dynamically if missing)
        if (m_CustomerSpriteRenderer == null)
        {
            m_CustomerSpriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        m_CustomerSpriteRenderer.sprite = sprite;
        m_CustomerSpriteRenderer.sortingLayerID = SortingLayer.NameToID("Customer");
        
        createBubbleForCup();

        PlaySound(enterSound);

        // m_CustomerSpriteRenderer.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
    }

    private void createBubbleForCup()
    {
        print("Creating bubble for cup");
        m_CustomerbubbleSpriteRenderer.enabled = true;
        print("Bubble sprite renderer enabled");
        print("m_cub.mBobatea liquid: " + m_Customer.m_DesiredDrink.m_Liquid);
        print("m_Cup.m_BobaTea: " + m_Cup.m_BobaTea);
        m_Cup.m_BobaTea = m_Customer.m_DesiredDrink;
        print("Set cup's boba tea to customer's desired drink");
        m_Cup.UpdateVisuals();
        print("Updated visuals for cup");
        m_Cup.SetDraggable(false);
        print("Set cup to not draggable");
    }

    private bool isAnnoyedIteration()
    {
        return m_annoyedTimeWaiting >= m_iterationOfAnnoyed;
    }

    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip);
            isPlayingSound = true;
            StartCoroutine(ResetSoundFlag(clip.length));
        }
    }

    private void PlayRandomHappySound()
    {
        if (audioSource != null && happySounds.Count > 0 && !audioSource.isPlaying)
        {
            int randomIndex = Random.Range(0, happySounds.Count);
            PlaySound(happySounds[randomIndex]);
        }
        else
        {
            Debug.LogWarning("No audio clips assigned to CustomerHolder.");
        }
    }

    private IEnumerator ResetSoundFlag(float duration)
    {
        yield return new WaitForSeconds(duration);
        isPlayingSound = false;
    }
}
