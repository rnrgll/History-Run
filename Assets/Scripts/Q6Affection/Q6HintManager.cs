using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Q6HintManager : MonoBehaviour
{


    public Q6QuizManager quizManager;

    private void Awake()
    {
        if(!PlayerPrefs.HasKey("Q6GamePlayCount")){
            Debug.Log("Init 호출");
            Init();
        }

    }

    void Init()
    {
        PlayerPrefs.SetInt("Q6Hint",0);
    }


    public void UnlockHint()
    {
        PlayerPrefs.SetInt("Q6Hint", 1);
    }

}
