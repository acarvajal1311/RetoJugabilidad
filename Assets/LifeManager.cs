using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    [SerializeField] int vidaActual = 3;
    [SerializeField] GameObject [] contenedorCorazones;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisminuirVida()
    {
        vidaActual -= 1;

     if(vidaActual <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
     else
        {
            contenedorCorazones[0].SetActive(vidaActual>=1);
            contenedorCorazones[1].SetActive(vidaActual>=2);
            contenedorCorazones[2].SetActive(vidaActual>=3);
        }
    }
}
