using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Q6SetResult : MonoBehaviour
{

    public int TicketReward;


    public void SetReultText(int tryNum){
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
        PlayerPrefs.SetInt("Q6GameTicketReward",TicketReward);
        int playerTicket = PlayerPrefs.GetInt("TicketNum");
        PlayerPrefs.SetInt("TicketNum",playerTicket+TicketReward);
        PlayerPrefs.SetInt("희망의 날", 1);
        Debug.Log("보상 설정");


    }

}

