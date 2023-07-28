using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected: MonoBehaviour
{
    AudioSource sonido;

    private bool isCollected = false;

    void Start()
    {
        sonido = GetComponent<AudioSource>();
        GetComponent<SpriteRenderer>().enabled = true;
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            sonido.Play();
            GetComponent<SpriteRenderer>().enabled = false;
            //gameObject.transform.GetChild(0).gameObject.SetActive(true);

            Goal.Instance.CollectItem();
            isCollected = true;
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
