using UnityEngine;
using System.Collections.Generic;

public class BeverageMachine : MonoBehaviour
{
    [SerializeField] List<BeverageMachineBtn> m_Buttons;
    [SerializeField] CupHolder m_LiquidArea;
    [SerializeField] CupHolder m_FoamAndToppingArea;
    [SerializeField] CupHolder m_LidArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddLiquidToCup(BobaTea.Liquid i_InsertedLiquid) {
        if (m_LiquidArea.m_HeldCup != null) {
            m_LiquidArea.m_HeldCup.SetLiquid(i_InsertedLiquid);
            // TODO - Update cup visuals.
        }
    }

    public void AddTapiocaToCup(BobaTea.Tapioca i_InsertedTapioca) {
        if (m_FoamAndToppingArea.m_HeldCup != null) {
            m_FoamAndToppingArea.m_HeldCup.SetTapioca(i_InsertedTapioca);
            // TODO - Update cup visuals.
        }
    }

}
