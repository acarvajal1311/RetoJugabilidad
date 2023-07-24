using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    public static bool damageSignal = false;
    public static float damageTime = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageSignal = true;
            damageTime = 0f;
            GameObject.Find("Canvas").GetComponent<LifeManager>().DisminuirVida();
            Destroy(gameObject);
        }
    }
}

