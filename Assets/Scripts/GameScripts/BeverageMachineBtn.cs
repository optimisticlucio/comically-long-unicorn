using UnityEngine;
using UnityEngine.UI;

public class BeverageMachineBtn : MonoBehaviour
{
    [SerializeField] GameObject button;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CheckMouseDown())
        {
            print("Mouse Clicked on Btn");
        }
    }

        private bool CheckMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            return true;
        }

        return false;
    }

    
}
