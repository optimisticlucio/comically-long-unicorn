using UnityEngine;
using System.Collections.Generic;

public class BeverageMachine : MonoBehaviour
{
    [SerializeField] List<BeverageMachineBtn> m_Buttons;
    [SerializeField] GameObject m_LiquidArea;
    [SerializeField] GameObject m_FoamAndToppingArea;
    [SerializeField] GameObject m_LidArea;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddLiquidToCup(BobaTea.Liquid i_InsertedLiquid) {
        // PSEUDOCODE! check if m_LiquidArea has a cup. If not, return. If yes:
        // m_LiquidArea's drink is now cup:
        BobaTea cup;
        cup.AddLiquidToCup(i_InsertedLiquid);
        // PSEUDOCODE - Update visuals of entire cup.
    }

    public void AddTapiocaToCup(BobaTea.Tapioca i_InsertedTapioca) {
        // PSEUDOCODE! check if m_FoamAndToppingArea has a cup. If not, return. If yes:
        // m_FoamAndToppingArea's drink is now cup:
        BobaTea cup;
        cup.AddTapiocaToCup(i_InsertedTapioca);
        // PSEUDOCODE - Update visuals of entire cup.
    }

}
