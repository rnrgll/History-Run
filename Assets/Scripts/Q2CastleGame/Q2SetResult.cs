using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Q2SetResult : MonoBehaviour
{
    public Text dialogueText;
   
    public Text ScoreText;

     public int TicketReward;
    
    public void setResult(int tryNum){
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
        PlayerPrefs.SetInt("Q2GameTicketReward",TicketReward);
        int playerTicket = PlayerPrefs.GetInt("TicketNum");
        PlayerPrefs.SetInt("TicketNum",playerTicket+TicketReward);
        PlayerPrefs.SetInt("용기의 날", 1);
        Debug.Log("보상 설정");


    }
    public void setScore(int score){
        ScoreText.text = score.ToString() + "점";
    }




}
