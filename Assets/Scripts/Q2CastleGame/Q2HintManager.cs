using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Q2HintManager : MonoBehaviour
{
    public List<Q2HintForQuestion> Q2HintsForQuestion;
    public enum Q2Hint {Q2Hint1, Q2Hint2, Q2Hint3, Q2Hint4, Q2Hint5}
    public Q2Hint[] q2hints;



    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;


    private void Awake()
    {
        q2hints = (Q2Hint[])Enum.GetValues(typeof(Q2Hint));
        if(!PlayerPrefs.HasKey("Q2GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }


    }

    void Init()
    {
        foreach(Q2Hint q2hint in q2hints){
            PlayerPrefs.SetInt(q2hint.ToString(),0);
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
        HintTxt.text = Q2HintsForQuestion[buttonNum].Hint;
    }


    public void UnlockHint(int QuestionNum)
    {
        string currentHint = q2hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }

}
