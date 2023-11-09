using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Q6PopUpSystem : MonoBehaviour
{
    public GameObject Panel;
    public Q6QuizManager quizManager;


    public void popUp(){
        Panel.SetActive(true);
        Invoke("popDown", 2);
        
   
    }
    public void popDown(){
        Panel.SetActive(false);
        quizManager.generateQuestion();
    }


}
