using System.Collections;
using System.Collections.Generic;
using TMPro; //avisas al codigo que vas a utilizar un c�digo que est� en otro lugar.
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable; //actualiza el texto a la variable de GameManager que le indiquemos.

    private TMP_Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (variable)
        {
            case GameManager.GameManagerVariables.TIME:
                textComponent.text = "Time: " + GameManager.instance.GetTime(); //lO NARANJA SE LLAMA CONNATENACION.
                break;
            case GameManager.GameManagerVariables.POINTS:
                textComponent.text = "Points: " + GameManager.instance.GetPoints();
                break;
            default:
                break;
        }
    }
}
