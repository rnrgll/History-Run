using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q4Answers : MonoBehaviour
{

    public bool isCorrect = false;
    public Q4QuizManager quizManager;

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
