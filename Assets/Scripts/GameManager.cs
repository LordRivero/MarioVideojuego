using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameManagerVariables { TIME, POINTS }; //Declara una estructura tipo enum (enumerar) para faciliar la lectura del código. time seria 0, points 1.

    private float time;
    private int points;

    private void Awake()
    {
        //SINGLETON
        if (!instance) //SI INSTANCE NO TIENE INFORMACION.
        {
            instance = this; //instance se asigna a este objeto
            DontDestroyOnLoad(gameObject); //se indica que el objetpo no se destruya con la carga de escenas.
        }
        else
        {
            Destroy(gameObject); //se destruye el GameObject, para que no haya dos o más GameObjects en el juegO.
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        time += Time.deltaTime;
    }

    public float GetTime()
    {
        return time;
    }

    public int GetPoints()
    {
        return points;
    }
    public void SetPoints(int value)
    {
        points = value;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
