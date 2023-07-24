using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene: MonoBehaviour
{
    public int tagScene = 0;
    public void loadScene()
    {
        SceneManager.LoadScene(tagScene);
    }

    public void ReloadLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

        public void ReloadLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
