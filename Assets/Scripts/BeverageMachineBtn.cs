using UnityEngine;
using UnityEngine.UI;

public class BeverageMachineBtn : MonoBehaviour
{
    [SerializeField] Button button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Mouse Clicked");
        }
    }

    
}
