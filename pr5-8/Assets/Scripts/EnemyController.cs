using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private float _sightRange = 10f;
    [SerializeField] private float _walkRange = 5f;
    [SerializeField] private float _moveSpeed = 3.5f;

    private NavMeshAgent _navAgent;
    private Vector3 _walkPoint;
    private bool _walkPointSet;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _navAgent.speed = _moveSpeed;
    }

    private void Update()
    {
        if (IsPlayerInSight())
            MoveToTarget(_playerTransform.position);
        else
            Patrol();
    }

    private void MoveToTarget(Vector3 target)
    {
        _navAgent.SetDestination(target);
    }

    private bool IsPlayerInSight()
    {
        Vector3 direction = _playerTransform.position - transform.position;
        bool playerInRange = Physics.Raycast(transform.position, direction, _sightRange, _playerMask);
        bool obstacleBetween = Physics.Raycast(transform.position, direction, direction.magnitude, _obstacleMask);
        return playerInRange && !obstacleBetween;
    }

    private void Patrol()
    {
        if (!_walkPointSet)
            SearchWalkPoint();

        if (_walkPointSet)
            _navAgent.SetDestination(_walkPoint);

        if (Vector3.Distance(transform.position, _walkPoint) < 1f)
            _walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        float randomX = Random.Range(-_walkRange, _walkRange);
        float randomZ = Random.Range(-_walkRange, _walkRange);
        _walkPoint = new Vector3(
            transform.position.x + randomX,
            transform.position.y,
            transform.position.z + randomZ
        );

        NavMeshPath path = new NavMeshPath();
        if (_navAgent.CalculatePath(_walkPoint, path) && path.status == NavMeshPathStatus.PathComplete)
        {
            _walkPointSet = true;
            Debug.DrawLine(_walkPoint, _walkPoint + Vector3.up * 2, Color.green, 2f);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(_walkRange * 2, 0.1f, _walkRange * 2));
    }
}