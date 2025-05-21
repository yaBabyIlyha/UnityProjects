using UnityEngine;
public class BaseGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    private void Start()
    {
        Vector3 displacement = new Vector3(3.5f, 1, 3);
        Quaternion rotation = Quaternion.Euler(0,30,0);
        Instantiate(_cubePrefab, displacement, rotation);
    }
}