using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   public static AudioManager instance;
    private List<GameObject> audioList;
    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioList = new List<GameObject>();
    }

    public AudioSource PlayAudio(AudioClip audioClip, string gameObjectName, bool isLoop = false, float volume = 1.0f) //isLoop y floatvolume son parametros por defecto, tienen que ir al final siempre y no pueden estar intercalados.
    {
        GameObject audioObject = new GameObject(gameObjectName);
        audioObject.transform.SetParent(transform); //todos los audios que se van creando son hijos de AudioManager.
        AudioSource audioSourceComponent = audioObject.AddComponent<AudioSource>(); //Añado a GameObject nuevo comoponente audioSource.
        audioSourceComponent.clip = audioClip; //asignamos el clip al componente y el clip que asignamos es nuestro método.
        audioSourceComponent.volume = volume;
        audioSourceComponent.loop = isLoop;
        audioSourceComponent.Play(); //incia el audio.
        audioList.Add(audioObject); //llevar un seguimiento de los objetos que estan sonando en la escena.
        if (!isLoop)
        {
           StartCoroutine(WaitAudioEnd(audioSourceComponent)); //si el audio no esta en loop espero a que acabe para destruirlo. pero el audio no tiene que estar en loop porque de ser así nunca acabaría.
        }

        return audioSourceComponent; //por si acaso desde otros componentes queremos utilizar otros parámetros de audioSource. 
    }

    IEnumerator WaitAudioEnd(AudioSource src) //IEnumerator  = corrutina para crear hilos y procesos.
    {
        while(src && src.isPlaying)
        {
          yield return null; //yield le devuelve el control a Unity.
        }

        Destroy(src.gameObject); //espera a que src deje de sonar para destruirlo.
    }

 public void ClearAudios() //por todos los audios de la lista, tenemos que ir uno por uno destruyendolos.
    {
      foreach(GameObject audioObject in audioList)
        {
            Destroy(audioObject);
        }
      audioList.Clear();
    }
}
