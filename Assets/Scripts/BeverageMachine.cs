using UnityEngine;
using System.Collections.Generic;

public class BeverageMachine : MonoBehaviour
{
    [SerializeField] List<BeverageMachineBtn> buttons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {

                    foreach (BeverageMachineBtn button in buttons)
                    {
                        button.CurrentClickedGameObject(raycastHit.transform.gameObject);
                    }
                }
            }
        }
    }
}
