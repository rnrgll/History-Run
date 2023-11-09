using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Q5SetResult : MonoBehaviour
{
     public Text dialogueText;
   
    public Text ScoreText;

     public int TicketReward;

    public void SetReult(int tryNum){
        switch(tryNum){
            case 1:
                TicketReward = 3;
                break;
            case 2:
                TicketReward = 2;
                break;
            default:
               TicketReward = 1;
                break;
        }
        PlayerPrefs.SetInt("Q5GameTicketReward",TicketReward);
        int playerTicket = PlayerPrefs.GetInt("TicketNum");
        PlayerPrefs.SetInt("TicketNum",playerTicket+TicketReward);
        PlayerPrefs.SetInt("신뢰의 날", 1);
        Debug.Log("보상 설정");
        



    }

    public void SetScore(int score){
        ScoreText.text = score.ToString() + "문제";
    }
}

