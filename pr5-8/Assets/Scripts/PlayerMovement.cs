using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private LayerMask _groundCheckLayers;
    
    private CharacterController _characterController;
    private Vector3 _characterVelocity;
    private float _groundCheckDistance;
    private bool _isGrounded;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _groundCheckDistance = _characterController.skinWidth + Physics.defaultContactOffset;
    }

    private void Update()
    {
        GroundCheck(); 
        HandleMovement(); 
        HandleGravityAndJump();
    }

    
    private void GroundCheck()
    {
        _isGrounded = false;
    
        Vector3 bottomSphere = transform.position - Vector3.up * _characterController.radius;

    
        if (Physics.SphereCast(
            bottomSphere, 
            _characterController.radius, 
            Vector3.down, 
            out RaycastHit hit, 
            _groundCheckDistance, 
            _groundCheckLayers, 
            QueryTriggerInteraction.Ignore))
        {
            _isGrounded = true;
            if (hit.distance > _characterController.skinWidth)
            {
                _characterController.Move(Vector3.down * hit.distance);
            }
        }
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(horizontal, 0f, vertical);
        Vector3 motion = input * _speed;
        _characterVelocity = new Vector3(motion.x, _characterVelocity.y, motion.z);
    }

    private void HandleGravityAndJump()
    {
        if (_isGrounded)
        {
            _characterVelocity.y = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _characterVelocity.y = Mathf.Sqrt(-2f * Physics.gravity.y * _jumpHeight);
            }
        }
        else
        {
            _characterVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
        _characterController.Move(_characterVelocity * Time.deltaTime);
    }
}