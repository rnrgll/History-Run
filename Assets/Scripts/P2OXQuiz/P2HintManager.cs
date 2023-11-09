using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class P2HintManager : MonoBehaviour
{
    public List<P2HintForQuestion> P2Hints;
    public enum P2Hint {P2Hint1, P2Hint2, P2Hint3, P2Hint4, P2Hint5}
    public P2Hint[] p2hints;



    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;
    public P2QuizManager quizManager;


    private void Awake()
    {
        p2hints = (P2Hint[])Enum.GetValues(typeof(P2Hint));
        if(!PlayerPrefs.HasKey("P2GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }

    }

    void Init()
    {
        foreach(P2Hint p2hint in p2hints){
            PlayerPrefs.SetInt(p2hint.ToString(),0);
        }
    }



    /*
    private void Update() {
        if(quizManager.QnA[quizManager.currentQuestion].QuestionNum>=0)
            generateHint(quizManager.QnA[quizManager.currentQuestion].QuestionNum);
        else
            Debug.Log("배열밖을 벗어남");
    }*/


    public void generateHint(int currentQuestion){
        HintTxt.text = P2Hints[currentQuestion].Hint;
    }


    public void UnlockHint(int QuestionNum)
    {
        string currentHint = p2hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }

}
