using UnityEngine;

public class FirstObject : MonoBehaviour

{
    public SecondObject secondGameObject;
    private void Start()
    {
        Debug.Log(secondGameObject.price);
    }
}