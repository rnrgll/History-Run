using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Q4HintPopUpManager : MonoBehaviour
{
    int PlayerTicket;
    public GameObject HintPanel;
    public GameObject HintBox;
    public GameObject UseTicket;
    public GameObject Fail;
    public TextMeshProUGUI currentTicket;



    public Q4QuizManager qm;
    public Q4HintManager hm;
    public string CurrentHint;
    public string IsUnlock;


    public void ClickHint()
    {
        CurrentHint = hm.q4hints[qm.currentQuestionNum].ToString();
        bool isUnlock = PlayerPrefs.GetInt(CurrentHint) == 1;
        Debug.Log(CurrentHint+" isUnlock : " + isUnlock);
        IsUnlock = isUnlock.ToString();


        if(isUnlock)
        {
            HintBoxOpen();
        }
        else
        {
            UseTicketOpen();
        }
        HintPanel.SetActive(true);

    

    }



    public void HintBoxOpen()
    {
        HintBox.SetActive(true);
    }
    public void UseTicketOpen()
    {
        UseTicket.SetActive(true);
        currentTicket.text = "티켓 보유 수량 : " + PlayerPrefs.GetInt("TicketNum").ToString()+ " 장";

    }

    public void FailOpen()
    {
        Fail.SetActive(true);
    }

    public void CanHint()
    {
        PlayerTicket = PlayerPrefs.GetInt("TicketNum");
        if(PlayerTicket>=1){
            PlayerTicket--;
            PlayerPrefs.SetInt("TicketNum",PlayerTicket);

            hm.UnlockHint(qm.currentQuestionNum);
            UseTicket.SetActive(false);
            Debug.Log("승차권 차감, 힌트 오픈");
            HintBoxOpen();

        }
        else{
            UseTicket.SetActive(false);
            FailOpen();
        }
    }



}
