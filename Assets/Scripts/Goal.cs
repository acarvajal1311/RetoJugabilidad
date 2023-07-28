using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public static Goal Instance { get; private set; }  
    
    [SerializeField] int totalItemCount = 0;
    private int collectedItemCount = 0;
    private int currentSceneIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void CollectItem()
    {
        collectedItemCount++;
        if (collectedItemCount >= totalItemCount )
        {
            SceneChanger();
        }
    }

    private void SceneChanger()
    {
        if (currentSceneIndex == 0)
        {
            SceneManager.LoadScene(3);
        }
        else if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1) 
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

    }
}