using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform groundCheck;
    public Transform attackPoint;
    public float groundCheckRadius = 0.1f;
    public float attackRadius = 0.5f;
    public LayerMask groundLayer;
    public LayerMask playerLayer; // Layer del jugador
    public float moveSpeed = 2f; // Velocidad de movimiento del enemigo
    public float moveDistance = 3f; // Distancia de movimiento antes de hacer el flip
    public float flipDelay = 0.5f; // Tiempo de espera antes de hacer el flip

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;
    private int attacksCount = 0;
    private bool isMovingRight = true;
    private float moveStartPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        moveStartPos = transform.position.x;
    }

    private void Update()
    {
        DetectAttacks();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // Verificar colisi�n con el suelo
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Si no est� en el suelo, cambia de direcci�n y se detiene por un breve per�odo antes de hacer el flip
        if (!isGrounded || rb.velocity.x == 0)
        {
            rb.velocity = Vector2.zero;
            if (Time.time >= moveStartPos + flipDelay)
            {
                Flip();
            }
            else
            {
                return;
            }
        }

        // Mover al enemigo hacia la direcci�n en la que est� mirando
        float horizontalMovement = isFacingRight ? moveSpeed : -moveSpeed;

        // Calcular la distancia recorrida
        float distance = Mathf.Abs(transform.position.x - moveStartPos);

        if (distance >= moveDistance)
        {
            // Si alcanza la distancia m�xima de movimiento, se detiene por un breve per�odo antes de hacer el flip
            rb.velocity = Vector2.zero;
            if (Time.time >= moveStartPos + flipDelay)
            {
                Flip();
            }
        }
        else
        {
            // Continuar movi�ndose hacia la direcci�n actual
            rb.velocity = new Vector2(horizontalMovement, rb.velocity.y);
        }
    }

    private void Flip()
    {
        // Cambiar direcci�n del enemigo
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !isFacingRight;

        // Ajustar posici�n del attackPoint cuando el enemigo cambia de direcci�n
        attackPoint.localPosition = new Vector3(-attackPoint.localPosition.x, attackPoint.localPosition.y, attackPoint.localPosition.z);

        // Reiniciar el tiempo de inicio del movimiento y esperar antes de moverse nuevamente
        moveStartPos = Time.time;
    }

    private void DetectAttacks()
    {
        // Detectar ataques al jugador
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, playerLayer);
        foreach (Collider2D hit in hits)
        {
            // Si el jugador ataca al enemigo con la espada, aumenta el contador de ataques
            attacksCount++;

            // Si el contador de ataques llega a 3, el enemigo quita vidas al jugador
            if (attacksCount >= 3)
            {
                GameObject.Find("Canvas").GetComponent<LifeManager>().DisminuirVida();
                attacksCount = 0;
            }
        }
    }
}












