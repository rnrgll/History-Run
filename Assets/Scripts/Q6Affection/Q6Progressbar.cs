using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class Q6Progressbar : MonoBehaviour
{
    

    public int maximum;
    public int current;
    public int goal = 70;
    public Image mask;
    public int result=0;


    
    private void Update() {
             GetCurrentFill();
    }


    void GetCurrentFill(){

        float fillAmount = (float)current / (float)maximum;
        mask.fillAmount = fillAmount;

    }
    


}
