using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EP2HintManager : MonoBehaviour
{

    public GameObject HintPanel;
    public GameObject ParentPanel;
    public GameObject UseTicket;
    public GameObject Fail;

    public TextMeshProUGUI currentTicket;

    private int PlayerTicket;

    public void HintPanelOpen()
    {
        HintPanel.SetActive(true);
        Invoke("FiveSec",5);
    }
    public void UseTicketOpen()
    {
        UseTicket.SetActive(true);
        currentTicket.text = "티켓 보유 수량 : " + PlayerPrefs.GetInt("TicketNum").ToString() + " 장";
    }

    public void CanHint()
    {
        PlayerTicket = PlayerPrefs.GetInt("TicketNum");
        if (PlayerTicket >= 1)
        {
            PlayerTicket -= 5;
            PlayerPrefs.SetInt("TicketNum", PlayerTicket);
            
            UseTicket.SetActive(false);
            HintPanelOpen();
        }
        else
        {
            UseTicket.SetActive(false);
            Fail.SetActive(true);
        }
    }

    public void FiveSec(){
        HintPanel.SetActive(false);
        ParentPanel.SetActive(false);

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
