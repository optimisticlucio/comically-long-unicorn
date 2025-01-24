using UnityEngine;

public class Customer : MonoBehaviour
{
    BobaTea m_DesiredDrink;
    float m_TimeWaiting = 0;
    [SerializeField] float m_TimeToAnnoyed = 20f; // The amount of time until the customer leaves.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
