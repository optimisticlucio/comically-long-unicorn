using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public BobaTea m_DesiredDrink;
    float m_TimeWaiting = 0;
    [SerializeField] float m_TimeToAnnoyed = 20f; // The amount of time until the customer leaves.

    public Customer(BobaTea drink)
    {
        m_DesiredDrink = drink;
    }
    private Customer() { } // Default constructor. Do not call without adding drink!!!

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CompareToDesiredDrink(BobaTea givenDrink)
    {
        return givenDrink.Equals(m_DesiredDrink);
    }

    public bool isAnnoyed()
    {
        return m_TimeWaiting >= m_TimeToAnnoyed;
    }
}
