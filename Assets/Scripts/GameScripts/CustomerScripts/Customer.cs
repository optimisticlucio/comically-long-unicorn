using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public BobaTea m_DesiredDrink;
    public float m_TimeWaiting = 0;
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
    public void Update()
    {
        m_TimeWaiting += Time.deltaTime;
    }

    public bool CompareToDesiredDrink(BobaTea givenDrink)
    {
        Debug.Log("Comparing " + givenDrink + " to " + m_DesiredDrink);
        Debug.Log("givingDrink: " + givenDrink.m_Liquid + " " + givenDrink.m_Tapioca + " " + givenDrink.m_Toppings);
        Debug.Log("m_DesiredDrink: " + m_DesiredDrink.m_Liquid + " " + m_DesiredDrink.m_Tapioca + " " + m_DesiredDrink.m_Toppings);

        Debug.Log("Sanity test = " + givenDrink.Equals(givenDrink));

        return givenDrink.Equals(m_DesiredDrink);
    }

    public bool isAnnoyed()
    {
        return m_TimeWaiting >= m_TimeToAnnoyed;
    }
}
