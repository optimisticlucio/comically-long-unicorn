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
        foreach (BeverageMachineBtn button in m_Buttons) {
            button.m_ParentBeverageMachine = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddLiquidToCup(BobaTea.Liquid i_InsertedLiquid) {
        if (m_LiquidArea.m_HeldCup != null) {
            m_LiquidArea.m_HeldCup.m_BobaTea.SetLiquid(i_InsertedLiquid);
            m_LiquidArea.m_HeldCup.UpdateVisuals();
        }
    }

    public void AddTapiocaToCup(BobaTea.Tapioca i_InsertedTapioca) {
        if (m_FoamAndToppingArea.m_HeldCup != null) {
            m_FoamAndToppingArea.m_HeldCup.m_BobaTea.SetTapioca(i_InsertedTapioca);
            m_LiquidArea.m_HeldCup.UpdateVisuals();
        }
    }

}
