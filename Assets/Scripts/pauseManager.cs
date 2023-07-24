using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class pauseManager : MonoBehaviour
{
    public static bool pause = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (pause == false))
        {
            modePause();
            Console.WriteLine("Pausa");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && (pause == true))
        {
            modePlay();
            Console.WriteLine("Continue");
        }
    }
    public void modePause()
    {
        pause = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);

        Time.timeScale = 0;
    }
    public void modePlay()
    {
        pause = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);

        Time.timeScale = 1;
    }
}
