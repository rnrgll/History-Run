using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Q1HintManager : MonoBehaviour
{
    public List<Q1HintForQuestion> Q1HintsForQuestion;
    public enum Q1Hint {Q1Hint1, Q1Hint2, Q1Hint3, Q1Hint4, Q1Hint5}
    public Q1Hint[] q1hints;



    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;


    private void Awake()
    {
        q1hints = (Q1Hint[])Enum.GetValues(typeof(Q1Hint));
        if(!PlayerPrefs.HasKey("Q1GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }


    }

    void Init()
    {
        foreach(Q1Hint q1hint in q1hints){
            PlayerPrefs.SetInt(q1hint.ToString(),0);
        }
    }



    /*
    private void Update() {
        if(quizManager.QnA[quizManager.currentQuestion].QuestionNum>=0)
            generateHint(quizManager.QnA[quizManager.currentQuestion].QuestionNum);
        else
            Debug.Log("배열밖을 벗어남");
    }*/


    public void generateHint(int buttonNum){
        HintTxt.text = Q1HintsForQuestion[buttonNum].Hint;
    }


    public void UnlockHint(int QuestionNum)
    {
        string currentHint = q1hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }

}
