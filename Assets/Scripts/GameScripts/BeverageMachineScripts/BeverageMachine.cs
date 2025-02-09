using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;

public class BeverageMachine : MonoBehaviour
{
    [SerializeField] List<BeverageMachineBtn> m_Buttons;
    [SerializeField] CupHolder m_LiquidArea;
    [SerializeField] CupHolder m_FoamAndToppingArea;
    [SerializeField] CupHolder m_LidArea;

    [SerializeField] private AudioClip liquidSound;

    private AudioSource audioSource;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // foreach (BeverageMachineBtn button in m_Buttons) {
        //     button.m_ParentBeverageMachine = this;
        // }
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

    public bool AddLiquidToCup(BobaTea.Liquid i_InsertedLiquid)
    {
        if (m_LiquidArea.m_HeldCup != null)
        {
            bool successfulPour = m_LiquidArea.m_HeldCup.m_BobaTea.SetLiquid(i_InsertedLiquid);
            // Play liquid sound
            if (successfulPour && audioSource != null && liquidSound != null)
            {
                audioSource.Stop();
                audioSource.PlayOneShot(liquidSound);
            }
            m_LiquidArea.m_HeldCup.UpdateVisuals();
            return successfulPour;
        }
        return false;
    }

    public bool AddTapiocaToCup(BobaTea.Tapioca i_InsertedTapioca)
    {
        if (m_FoamAndToppingArea.m_HeldCup != null)
        {
            m_FoamAndToppingArea.m_HeldCup.m_BobaTea.SetTapioca(i_InsertedTapioca);
            m_LiquidArea.m_HeldCup.UpdateVisuals();
            return true;
        }
        return false;
    }

    public bool AddToppingToCup(BobaTea.Topping i_InsertedTopping) 
    {
        if (m_FoamAndToppingArea.m_HeldCup != null)
        {
            m_FoamAndToppingArea.m_HeldCup.m_BobaTea.AddTopping(i_InsertedTopping);
            m_LiquidArea.m_HeldCup.UpdateVisuals();
            return true;
        }
        return false;
    }

    public bool PutLidOnCup() 
    {
        if (m_LidArea.m_HeldCup != null)
        {
            m_FoamAndToppingArea.m_HeldCup.m_BobaTea.AddLid();
            m_LiquidArea.m_HeldCup.UpdateVisuals();
            return true;
        }
        return false;
    }

}
