using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Q3Answers : MonoBehaviour
{

    public bool isCorrect = false;
    public Q3QuizManager quizManager;

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
