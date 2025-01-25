using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip m_MusicClip;  // Music clip to play
    private AudioSource audioSource;

    [SerializeField] private float m_Volume = 0.5f;  // Music volume
    [SerializeField] private bool m_Loop = true;     // Should the music loop
    [SerializeField] private float Delay = 1.2f;     // Delay before music starts

    private float m_TimeToStart = 0;
    private bool hasStarted = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component not found. Please add an AudioSource to the GameObject.");
            return;
        }

        audioSource.clip = m_MusicClip;
        audioSource.volume = m_Volume;
        audioSource.loop = m_Loop;
    }

    void Update()
    {
        if (!hasStarted && m_TimeToStart >= Delay)
        {
            PlayMusic();
            hasStarted = true;
        }

        m_TimeToStart += Time.deltaTime;
    }

    private void PlayMusic()
    {
        if (audioSource != null && m_MusicClip != null)
        {
            audioSource.Play();
            Debug.Log("Music started playing");
        }
        else
        {
            Debug.LogError("Audio clip is not assigned to the MusicPlayer.");
        }
    }
}
