using UnityEngine;
public class WaypointGeneration : MonoBehaviour
{
    [SerializeField] private GameObject _cylinderPrefab;
    [SerializeField] private Vector3[] _waypoints;
    private void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 30, 0);
        for (int i = 0; i < _waypoints.Length; i++)
        {
            Vector3 randomPosition = _waypoints[i];
            Instantiate(_cylinderPrefab, randomPosition, rotation);
        }
    }
}