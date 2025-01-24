using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    class CustomerGenerator {
        int m_CustomerRequestComplexity = 0; // Advances as requests get more complicated.
        int m_DrinksToNextComplexity = 1; // Amount of drinks left until complexity increases.
        List<BobaTea.Liquid> m_AvailableLiquids;
        List<BobaTea.Tapioca> m_AvailableTapiocas;
        List<BobaTea.Foam> m_AvailableFoams;
        List<BobaTea.Topping> m_AvailableToppings;

        public CustomerGenerator() {
            // BASIC INGREDIENTS!

            m_AvailableLiquids.Add(BobaTea.Liquid.BlackTea);

            m_AvailableTapiocas.Add(BobaTea.Tapioca.Classic);

            // No foams or toppings to start
            m_AvailableFoams.Add(BobaTea.Foam.None);
            m_AvailableToppings.Add(BobaTea.Topping.None);
        }

        public void AdvanceComplexityLevel() {
            m_CustomerRequestComplexity++;

            switch (m_CustomerRequestComplexity) {
                case 1:
                    m_AvailableTapiocas.Add(BobaTea.Tapioca.None);
                    m_DrinksToNextComplexity = 2;
                    break;
            
                case 2:
                    m_AvailableLiquids.Add(BobaTea.Liquid.GreenTea);
                    m_DrinksToNextComplexity = 3;
                    break;

                case 3:
                    m_AvailableLiquids.Add(BobaTea.Liquid.Strawberry);
                    m_AvailableLiquids.Add(BobaTea.Liquid.Matcha);
                    m_AvailableTapiocas.Add(BobaTea.Tapioca.Matcha);
                    m_DrinksToNextComplexity = 6;
                    break;

                default:
                    print("WARNING! Attempted to advance Customer Complexity Level beyond what's allowed! New Complexity: " + m_CustomerRequestComplexity);
                    break;
            }
        }

        public BobaTea GenerateRandomDrink() {
            // Grabs random available items and tosses into a drink.
            BobaTea.Liquid randLiquid = GetRandomFromList(m_AvailableLiquids);
            BobaTea.Tapioca randTapioca = GetRandomFromList(m_AvailableTapiocas);
            BobaTea.Foam randFoam = GetRandomFromList(m_AvailableFoams);
            BobaTea.Topping randTopping = GetRandomFromList(m_AvailableToppings); // NOTE - Assumes only one topping.

            return new BobaTea(randLiquid, randTapioca, randTopping, randFoam);
        }

        private T GetRandomFromList<T>(List<T> list) {
            return list[Random.Range(0, list.Count)];
        }
    }
}
