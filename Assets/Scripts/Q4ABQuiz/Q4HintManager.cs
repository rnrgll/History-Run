using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Q4HintManager : MonoBehaviour
{
    public List<Q3HintForQuestion> Q4Hints;

    public enum Q4Hint {Q4Hint1, Q4Hint2, Q4Hint3, Q4Hint4, Q4Hint5}
    public Q4Hint[] q4hints;

    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;

    public Q4QuizManager quizManager;


    /*
    private void Update() {
        if(quizManager.QnA[quizManager.currentQuestion].QuestionNum>=0)
            generateHint(quizManager.QnA[quizManager.currentQuestion].QuestionNum);
        else
            Debug.Log("배열밖을 벗어남");
    }*/
    private void Awake()
    {
        q4hints = (Q4Hint[])Enum.GetValues(typeof(Q4Hint));
        if(!PlayerPrefs.HasKey("Q4GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }

    }

    void Init()
    {
        foreach(Q4Hint q4hint in q4hints){
            PlayerPrefs.SetInt(q4hint.ToString(),0);
        }
    }




    public void generateHint(int currentQuestion){
        HintTxt.text = Q4Hints[currentQuestion].Hint;
    }
    public void UnlockHint(int QuestionNum)
    {
        string currentHint = q4hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }

}
