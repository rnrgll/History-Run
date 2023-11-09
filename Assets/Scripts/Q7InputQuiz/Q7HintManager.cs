using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class Q7HintManager : MonoBehaviour
{
    public List<Q7HintForQuestion> Q7Hints;

    public enum Q7Hint {Q7Hint1, Q7Hint2, Q7Hint3}
    public Q7Hint[] q7hints;

    //힌트 내용이 들어갈 TMPro 오브젝트
    public TextMeshProUGUI HintTxt;

    public Q7QuizManager quizManager;



        private void Awake()
    {
        q7hints = (Q7Hint[])Enum.GetValues(typeof(Q7Hint));
        if(!PlayerPrefs.HasKey("Q7GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }

    }

    void Init()
    {
        foreach(Q7Hint q7hint in q7hints){
            PlayerPrefs.SetInt(q7hint.ToString(),0);
        }
    }




    public void generateHint(int currentQuestion){
        HintTxt.text = Q7Hints[currentQuestion].Hint;
    }
    public void UnlockHint(int QuestionNum)
    {
        string currentHint = q7hints[QuestionNum].ToString();
        PlayerPrefs.SetInt(currentHint, 1);
    }
}
