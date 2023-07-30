using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDamage : MonoBehaviour
{
    public float damageInterval = 2f; // Intervalo de tiempo para restar vidas
    private float damageTimer = 0f;

    private void Update()
    {
        // Si damageSignal es true, significa que el jugador está en contacto con el collider del enemigo
        // Restamos vidas cada cierto intervalo de tiempo (damageInterval)
        if (DamagePlayer.damageSignal)
        {
            damageTimer += Time.deltaTime;
            if (damageTimer >= damageInterval)
            {
                // Restar vidas al jugador y reiniciar el temporizador
                GameObject.Find("Canvas").GetComponent<LifeManager>().DisminuirVida();
                damageTimer = 0f;
            }
        }
        else
        {
            // Si el jugador ya no está en contacto con el collider del enemigo, reiniciamos el temporizador
            damageTimer = 0f;
        }
    }
}

