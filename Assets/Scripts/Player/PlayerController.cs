using UnityEngine;

[RequireComponent(typeof(PlayerAttack))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private LayerMask m_Mask;
    private float detectionRadius = 100;
    private bool isFindEnenmy = true;

    private float smoothTime = 0.1f;
    private IInput _input;
    private CharacterController _characterController;
    private float currentVelocity;
    private Animator animator;
    private PlayerAttack _playerAttack;

    const float GRAVITY_SCALE = -9.81f;
    const string Run_STATE = "Run";
    const string ATTACK_STATE = "Attack";

    public void Initialize(IInput input)
    {
        _input = input;
        _characterController = GetComponent<CharacterController>();
        _playerAttack = GetComponent<PlayerAttack>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        
    }
    private void Movement()
    {
        Vector2 direction = _input.GetDirection();
        Vector3 newPosition = new Vector3(direction.x * speed, GRAVITY_SCALE, direction.y * speed);
        _characterController.Move(newPosition * Time.deltaTime);
        if(direction.magnitude >0)
        {
            animator.SetBool(Run_STATE, true);
            animator.SetBool(ATTACK_STATE, false);
            Rotate(direction);
        }
        else
        {
            animator.SetBool(Run_STATE, false);
            AttackClosestEnemy();
        }
    }
    private void Rotate(Vector2 direction)
    {
        float targetAngel = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        float angel = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngel, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angel, 0);
    }
    void AttackClosestEnemy()
    {
        if (isFindEnenmy)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, m_Mask);
            float closestDistance = Mathf.Infinity;
            Health closestEnemy = null;
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.TryGetComponent(out Health enemy))
                {
                    float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                    if (distanceToEnemy < closestDistance)
                    {
                        closestDistance = distanceToEnemy;
                        closestEnemy = enemy;
                    }
                }
            }
            if (closestEnemy != null)
            {
                animator.SetBool(ATTACK_STATE, true);
                Vector3 direction = closestEnemy.transform.position - transform.position;
                direction.y = 0;
                transform.rotation = Quaternion.LookRotation(direction.normalized);
            }
            else
                animator.SetBool(ATTACK_STATE, false);
        }
    }
}
