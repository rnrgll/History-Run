using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Q3HintManager : MonoBehaviour
{
    public List<Q3HintForQuestion> Q3Hints;

    public enum Q3Hint {Q3Hint1, Q3Hint2, Q3Hint3, Q3Hint4, Q3Hint5}
    public Q3Hint[] q3hints;

    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;

    public Q3QuizManager quizManager;


    /*
    private void Update() {
        if(quizManager.QnA[quizManager.currentQuestion].QuestionNum>=0)
            generateHint(quizManager.QnA[quizManager.currentQuestion].QuestionNum);
        else
            Debug.Log("배열밖을 벗어남");
    }*/
    private void Awake()
    {
        q3hints = (Q3Hint[])Enum.GetValues(typeof(Q3Hint));
        if(!PlayerPrefs.HasKey("Q3GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }

    }

    void Init()
    {
        foreach(Q3Hint q3hint in q3hints){
            PlayerPrefs.SetInt(q3hint.ToString(),0);
        }
    }




    public void generateHint(int currentQuestion){
        HintTxt.text = Q3Hints[currentQuestion].Hint;
    }
    public void UnlockHint(int QuestionNum)
    {
        string currentHint = q3hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }

}
