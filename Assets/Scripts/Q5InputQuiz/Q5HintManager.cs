using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Q5HintManager : MonoBehaviour
{
    public List<Q5HintForQuestion> Q5Hints;


    public enum Q5Hint {Q5Hint1, Q5Hint2, Q5Hint3}
    public Q5Hint[] q5hints;

    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;

    public Q5QuizManager quizManager;



     private void Awake()
    {
        q5hints = (Q5Hint[])Enum.GetValues(typeof(Q5Hint));
        if(!PlayerPrefs.HasKey("Q5GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }

    }

    void Init()
    {
        foreach(Q5Hint q5hint in q5hints){
            PlayerPrefs.SetInt(q5hint.ToString(),0);
        }
    }




    public void generateHint(int currentQuestion){
        HintTxt.text = Q5Hints[currentQuestion].Hint;
    }
    public void UnlockHint(int QuestionNum)
    {
        string currentHint = q5hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }
}
