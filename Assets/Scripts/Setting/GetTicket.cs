using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GetTicket : MonoBehaviour
{

    public TextMeshProUGUI TicektTxt;
    // Start is called before the first frame update
    void Start()
    {
        TicektTxt.text = PlayerPrefs.GetInt("TicketNum").ToString() + "장";
    }


}
