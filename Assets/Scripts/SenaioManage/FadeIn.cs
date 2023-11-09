using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    [Header("FadeInOut")]
    public float fadeSpeed = 1.5f;
    private CanvasGroup canvasGroup;



    public void Fadein(){
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;
        Fadein();
    }


}
