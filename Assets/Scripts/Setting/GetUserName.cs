using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetUserName : MonoBehaviour
{
    public TextMeshProUGUI nameTxt;
    // Start is called before the first frame update
    void Start()
    {
        nameTxt.text = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
