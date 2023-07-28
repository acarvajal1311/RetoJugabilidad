using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum MovementType { LeftToRight, UpAndDown }

    public MovementType movementType = MovementType.LeftToRight;
    public float moveSpeed = 2.0f;

    private int jumpsToKill = 3; // Cantidad de saltos necesarios para eliminar al enemigo
    private int jumpCount = 0;
    private bool isDead = false;

    private void Update()
    {
        if (!isDead)
        {
            Move();
        }
    }

    private void Move()
    {
        if (movementType == MovementType.LeftToRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

            // Si llega al límite de movimiento, cambiamos de dirección
            if (transform.position.x >= 5.0f || transform.position.x <= -5.0f)
            {
                moveSpeed *= -1;
            }
        }
        else if (movementType == MovementType.UpAndDown)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

            // Si llega al límite de movimiento, cambiamos de dirección
            if (transform.position.y >= 5.0f || transform.position.y <= -5.0f)
            {
                moveSpeed *= -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el enemigo entra en contacto con el jugador y el enemigo no está muerto
        if (collision.CompareTag("Player") && !isDead)
        {
            // Incrementamos el contador de saltos
            jumpCount++;
            Debug.Log("Saltos: " + jumpCount);

            // Si el contador de saltos llega a la cantidad necesaria para eliminar al enemigo
            if (jumpCount >= jumpsToKill)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        // Lógica para reproducir sonido o animaciones de muerte del enemigo, si deseas

        // Eliminamos el enemigo
        Destroy(gameObject);
    }
}


