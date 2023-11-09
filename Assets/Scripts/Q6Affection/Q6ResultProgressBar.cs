using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Q6ResultProgressBar : MonoBehaviour
{   public Q6Progressbar Progressbar;

    int maximum = 100;
    int current;
    public Image mask;

    private void Awake() {
        current = Progressbar.result;
        Debug.Log("결과 점수 : " + current);
    }

    private void Start() {
        
        
        GetCurrentFill();
    }


    void GetCurrentFill(){
        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

    }
    


}
