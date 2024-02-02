using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioClip audioClip;
    public bool isLoop, playOnGameStart; //que empiece nada m�s empezar el juego.
    public float volume;
    public string gameObjectName;

    // Start is called before the first frame update
    void Start()
    {
        if (playOnGameStart) //Que suene al principio nada m�s emepzar.
        {
            AudioManager.instance.PlayAudio(audioClip, gameObjectName, isLoop, volume);
        }
    }

  
}
