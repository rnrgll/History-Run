using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveManager : MonoBehaviour
{
    public TMP_InputField inputName;

    //Dictionary<string, string> senario = new Dictionary<string, string>();
    
    private void Awake() {
        //데이터 초기화
        PlayerPrefs.DeleteAll();
        //TicketNum 초기화
        PlayerPrefs.SetInt("TicketNum",0);
        //PlayLog 초기화
        
    }

    public void Save()
    {   
        //SetString : 지정한 키로 string 타입의 값을 저장
        PlayerPrefs.SetString("PlayerName", inputName.text);
        PlayerPrefs.SetInt("SignUp", 1);
    }

}


