using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] int requiredItemCount = 0;
    [SerializeField] int collectedItemCount = 0;
    [SerializeField] int nextSceneIndex = 0;

    public void CollectItem()
    {
        collectedItemCount++;
        if (collectedItemCount >= requiredItemCount)
        {
            SceneChanger();
        }
    }

    private void SceneChanger()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
