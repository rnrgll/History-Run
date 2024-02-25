using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2AnswerManager : MonoBehaviour
{
    public P2QuizManager quizManager;

    [SerializeField]
    bool playerAnswer;


    public void ClickO()
    {
        playerAnswer = true;
        CompareAnswer();

    }
    public void ClickX()
    {
        playerAnswer = false;
        CompareAnswer();
    }

    public void CompareAnswer()
    {
        if (playerAnswer == quizManager.Answer)
            quizManager.correct();

        else
            quizManager.wrong();
    }



}
