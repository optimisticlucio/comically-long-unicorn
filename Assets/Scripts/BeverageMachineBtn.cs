using UnityEngine;

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

    }

    public void CurrentClickedGameObject(GameObject gameObject)
{
    if(gameObject == button)
    {
        Debug.Log("Button clicked");
    }
    else
    {
    }
}
}
