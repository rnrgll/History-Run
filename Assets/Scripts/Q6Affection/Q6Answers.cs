using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q6Answers : MonoBehaviour



{
    public bool isCorrect = false;
    public Q6QuizManager quizManager;

   public void Answer(){
        if(isCorrect){
            quizManager.correct();
        }
        else
        {
            quizManager.wrong();
        }
   }

}
