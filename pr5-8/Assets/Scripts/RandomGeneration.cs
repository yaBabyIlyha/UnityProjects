using UnityEngine;
public class RandomGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _cylinderPrefab;
    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 30, 0);
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
            Instantiate(_cylinderPrefab, randomPosition, rotation);
        }
    }
}