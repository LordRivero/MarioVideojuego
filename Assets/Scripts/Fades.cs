using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fades : MonoBehaviour
{
    private SpriteRenderer _rend;
    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut() //Se llama FadeOut porque va disminuyendo el alpha.
    {
        Color color = _rend.color; //almacena el color actual del gameobject.
        for(float alpha = 1.0f; alpha>=0; alpha-= 0.01f) //para ir reduciendo el alpha.
        {
            color.a = alpha;
            _rend.color = color;
            yield return new WaitForSeconds(0.02f); //oye devuelvele el control a unity durante 0.02 segundos. 
        }
    }    
}
