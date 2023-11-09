using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class P2SetResult : MonoBehaviour
{
    public Text Text;
    public Text Score;
    public int TicketReward;


    public void SetReultText(int score){
        string Bad = "이런... 백제에 대해 잘 알지 못하고는\n다음 퀘스트를 수행하기 힘들걸세.\n다시 한번 도전해보게!";
        string Good = "아직 조금 부족하지만\n그래도 퀘스트를 진행하다 보면\n실력이 팍팍 늘걸세!";
        string Great = "모든 퀴즈를 다 풀다니 정말 대단해!";
        
        if(score<3){
            Text.text = Bad;
        }
        else if(score<5){
            Text.text = Good;
            if(score==3)
                TicketReward = 1;
            else
                TicketReward = 2;
        }
        
        else{
            Text.text = Great;
            TicketReward = 3;
        }
        PlayerPrefs.SetInt("P2GameTicketReward",TicketReward);
        int playerTicket = PlayerPrefs.GetInt("TicketNum");
        PlayerPrefs.SetInt("TicketNum",playerTicket+TicketReward);


    }

    public void SetScore(int score){
        Score.text = score.ToString()+"문제";
    }
}

