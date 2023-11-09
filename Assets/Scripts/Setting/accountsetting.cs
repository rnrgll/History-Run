using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class accountsetting : MonoBehaviour
{
    public TextMeshProUGUI nametxt;
    public TextMeshProUGUI ticekttxt;

    private void Awake() {
        string name = PlayerPrefs.GetString("PlayerName");
        string ticket = PlayerPrefs.GetInt("TicketNum").ToString();

        nametxt.text = name;
        ticekttxt.text = ticket + "장";
    }
}
