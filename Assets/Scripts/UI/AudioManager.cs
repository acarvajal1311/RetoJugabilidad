using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class AudioManager : MonoBehaviour
{
    public static bool sound = true;
    //public Sprite soundOn;
    //public Sprite soundOff;

    [SerializeField] GameObject iconoSonido; 

    
    public void SoundOn()
    {
        //gameObject.GetComponent<Image>().sprite = soundOn;
        iconoSonido.GetComponent<Image>().color = Color.green;
        sound = true;
    }
    public void SoundOff() 
    {
       // gameObject.GetComponent<Image>().sprite = soundOff;
        iconoSonido.GetComponent<Image>().color = Color.red;
        sound = false;
    }
    public void ChangeSound()
    {
        if (sound)
        {
           // gameObject.GetComponent<Image>().sprite = soundOff;
            iconoSonido.GetComponent<Image>().color = Color.red;
            sound = false;
        }
        else
        {
           // gameObject.GetComponent<Image>().sprite = soundOn;
            iconoSonido.GetComponent<Image>().color = Color.green;
            sound = true;
        }
    }
}
