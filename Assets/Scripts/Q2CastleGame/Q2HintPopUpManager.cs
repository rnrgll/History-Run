using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Q2HintPopUpManager : MonoBehaviour
{

    // Panel
    public GameObject ParentPanel;
    public GameObject HintPanel1;
    public GameObject HintPanel2;
    public GameObject UseTicket;
    public GameObject Fail;
    public TextMeshProUGUI currentTicket;

    //플레이어 승차권 개수
    int PlayerTicket;



    //managers
    public Q2CardGameManager gm;
    public Q2HintManager hm;

    //Hint's Lock state
    public string IsUnlock;
    public string CurrentHint;
    public int HintIndex;


    

    //1. HintPanel1 팝업
    public void HintPanel1opUp(){
        //card의 collider 비활성화
        for(int i=0;i<gm.activeDeck.Count;i++){
            gm.activeDeck[i].GetComponent<Collider2D>().enabled = false;
        }
        ParentPanel.SetActive(true);
        HintPanel1.SetActive(true);
   
    }
    public void HintPanel1popDown(){
        //card의 collider 활성화
        for(int i=0;i<gm.activeDeck.Count;i++){
            gm.activeDeck[i].GetComponent<Collider2D>().enabled = true;
        }
        HintPanel1.SetActive(false);
    }


    //2. HintPanel1에서 Button을 선택하면 해당하는 힌트 팝업 창
    public void ClickHint(int num){
        HintIndex = num-1;
        CurrentHint = hm.q2hints[num-1].ToString();
        bool isUnlock = PlayerPrefs.GetInt(CurrentHint) == 1;
        Debug.Log(CurrentHint+" isUnlock : " + isUnlock);
        IsUnlock = isUnlock.ToString();



        if(isUnlock)
        {
            HintPanel2Open();
        }
        else
        {
            UseTicketOpen();
        }
    }




    public void HintPanel2Open()
    {
        hm.generateHint(HintIndex);
        HintPanel2.SetActive(true);
    }
    public void UseTicketOpen()
    {
        HintPanel1.SetActive(false);
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

            hm.UnlockHint(HintIndex);
            UseTicket.SetActive(false);
            Debug.Log("승차권 차감, 힌트 오픈");
            HintPanel2Open();

        }
        else{
            UseTicket.SetActive(false);
            FailOpen();
        }
    }
}
