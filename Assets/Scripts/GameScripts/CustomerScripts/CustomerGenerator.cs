using System.Collections.Generic;
using UnityEngine;


public class CustomerGenerator : MonoBehaviour
{
    int m_CustomerRequestComplexity = 0; // Advances as requests get more complicated.
    int m_DrinksToNextComplexity = 1; // Amount of drinks left until complexity increases.
    List<BobaTea.Liquid> m_AvailableLiquids = new List<BobaTea.Liquid>();
    List<BobaTea.Tapioca> m_AvailableTapiocas = new List<BobaTea.Tapioca>();
    List<BobaTea.Topping> m_AvailableToppings = new List<BobaTea.Topping>();

    List<CustomerHolder> m_Customers = new List<CustomerHolder>();

    [SerializeField] public List<Sprite> CustomerspriteRenderers;

    [SerializeField] private GameObject customerHolderPrefab;  // Drag your prefab in the Inspector



    public CustomerGenerator()
    {
        // BASIC INGREDIENTS!

        m_AvailableLiquids.Add(BobaTea.Liquid.Blueberry);

        m_AvailableTapiocas.Add(BobaTea.Tapioca.Classic);

        // No toppings to start
    }

    public void DrinkSuccessfulyServed()
    {
        m_DrinksToNextComplexity--;

        if (m_DrinksToNextComplexity == 0)
        {
            AdvanceComplexityLevel();
        }
    }

    public void AdvanceComplexityLevel()
    {
        m_CustomerRequestComplexity++;

        switch (m_CustomerRequestComplexity)
        {
            case 1:
                m_AvailableTapiocas.Add(BobaTea.Tapioca.None);
                m_DrinksToNextComplexity = 2;
                break;

            case 2:
                m_AvailableLiquids.Add(BobaTea.Liquid.GreenTea);
                m_AvailableLiquids.Add(BobaTea.Liquid.Matcha);
                m_DrinksToNextComplexity = 3;
                break;

            case 3:
                m_AvailableLiquids.Add(BobaTea.Liquid.Strawberry);
                m_AvailableTapiocas.Add(BobaTea.Tapioca.Matcha);
                m_DrinksToNextComplexity = 6;
                break;

            case 4:
                m_AvailableLiquids.Add(BobaTea.Liquid.Banana);
                m_AvailableLiquids.Add(BobaTea.Liquid.Peach);
                m_AvailableTapiocas.Add(BobaTea.Tapioca.Pineapple);
                m_AvailableTapiocas.Add(BobaTea.Tapioca.Strawberry);
                m_AvailableTapiocas.Add(BobaTea.Tapioca.Coffee);
                m_DrinksToNextComplexity = 12;
                break;

            default:
                print("WARNING! Attempted to advance Customer Complexity Level beyond what's coded! Final Complexity: " + m_CustomerRequestComplexity);
                break;
        }
    }

    public CustomerHolder GenerateRandomCustomer()
    {
        BobaTea randomDrink = GenerateRandomDrink();
        Customer newCustomer = new Customer(randomDrink);
        Sprite randomSprite = GetRandomFromList(CustomerspriteRenderers);

        // Instantiate the prefab and initialize it
        GameObject newCustomerObject = Instantiate(customerHolderPrefab);
        CustomerHolder customerHolder = newCustomerObject.GetComponent<CustomerHolder>();

        if (customerHolder != null)
        {
            customerHolder.Initialize(newCustomer, randomSprite);
            print("Generated new customer who wants " + newCustomer.m_DesiredDrink.m_Liquid + " tea with " + newCustomer.m_DesiredDrink.m_Tapioca + " tapioca.");
        }

        return customerHolder;
    }

    public BobaTea GenerateRandomDrink()
    {
        // Grabs random available items and tosses into a drink.
        BobaTea.Liquid randLiquid = GetRandomFromList(m_AvailableLiquids);
        BobaTea.Tapioca randTapioca = GetRandomFromList(m_AvailableTapiocas);
        // BobaTea.Topping randTopping = GetRandomFromList(m_AvailableToppings); // NOTE - Assumes only one topping.

        return new BobaTea(randLiquid, randTapioca);
    }

    public T GetRandomFromList<T>(List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }
}