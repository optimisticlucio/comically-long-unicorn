using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<CustomerHolder> m_WaitingCustomers = new List<CustomerHolder>();
    [SerializeField] int m_MaxCustomersAtOnce = 1;
    [SerializeField] float m_DayTimeLeft = 60f;

    int m_EarnedMoney = 0;

    [SerializeField] static int s_PriceOfDrink = 10;

    float m_TimeToNextCustomer = 5f;

    [SerializeField] CustomerGenerator m_CustomerGenerator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateDaytime();

        if (m_DayTimeLeft >= 0)
        {
            WaitForNextCustomer();

            foreach (CustomerHolder customerHolder in m_WaitingCustomers)
            {
                if (customerHolder.m_Customer.isAnnoyed())
                {
                    // TODO - Make customer leave!
                }
            }
        }
    }

    void UpdateDaytime()
    {
        m_DayTimeLeft -= Time.deltaTime;

        // TODO - Check if day is over?
    }

    void WaitForNextCustomer()
    {
        m_TimeToNextCustomer -= Time.deltaTime;

        if (m_TimeToNextCustomer <= 0)
        {
            if (m_WaitingCustomers.Count >= m_MaxCustomersAtOnce)
            {
                m_TimeToNextCustomer = 2f; // Wait two seconds before checking again.
            }
            else
            {
            // Generate and spawn a new customer
            CustomerHolder newCustomer = m_CustomerGenerator.GenerateRandomCustomer();
            
            // Position the customer somewhere in the scene
            newCustomer.transform.position = new Vector3(Random.Range(-5f, 5f), 0, 0);

            m_WaitingCustomers.Add(newCustomer);
            Debug.Log("New customer spawned!");
            }
        }
    }

    bool GiveCustomerDrink(int i_CustomerNumber, BobaTea i_GivenDrink)
    { // Returns true if correct drink.
        if (m_WaitingCustomers[i_CustomerNumber].m_Customer.CompareToDesiredDrink(i_GivenDrink))
        {
            // TODO - Animation of customer happy and leaving!
            m_CustomerGenerator.DrinkSuccessfulyServed();
            m_EarnedMoney += s_PriceOfDrink;
            return true;
        }
        else
        {
            // TODO - Give user indication of what's wrong! Noise, animation, whatever
            return false;
        }
    }
}
