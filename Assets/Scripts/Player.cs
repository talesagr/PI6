using UnityEngine;
using System.Collections;
using UnityEngine.UIElements;


public class Player : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("Attack Settings")]
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private LayerMask enemyLayer;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isAttacking = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigid body is not defined");
        }
    
    }
    private void Update()
    {
        float moveZ = Input.GetAxis("Vertical"); // W e S
        float moveX = Input.GetAxis("Horizontal"); // A e D
        movement = new Vector3(moveX, 0, moveZ).normalized;
        if (movement != Vector3.zero)
        {
            RotatePlayer();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isAttacking)
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector3 moveVelocity = movement * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveVelocity);
    }

    private void RotatePlayer()
    {
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        Quaternion smoothedRotation = Quaternion.Lerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        rb.MoveRotation(smoothedRotation);
    }

    private void Attack()
    {
        isAttacking = true;
        Debug.Log("Atacando!");

        
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Inimigo atingido: " + enemy.name);
            // Aqui você pode adicionar lógica para causar dano ao inimigo
            // Exemplo: enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }

        // Reseta o estado de ataque após um pequeno delay
        Invoke(nameof(ResetAttack), 0.5f);
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }





}
