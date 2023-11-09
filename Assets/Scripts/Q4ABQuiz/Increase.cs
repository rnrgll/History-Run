using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Increase : MonoBehaviour
{
    public TextMeshProUGUI tmp_num;
    public string pk_name; //inspector 창에서 해당 
    private int current_num = 0;


    public void GetCurrentPK(){
        pk_name = PlayerPrefs.GetString(tmp_num.text);
        current_num = PlayerPrefs.GetInt(pk_name, current_num);
    }
    

    public void IncreaseNum() //button 눌렀을 때 숫자 증가될 수 있도록
    {
        GetCurrentPK();

        if (current_num < 4)
        {
            current_num += 1; 

            tmp_num.text = current_num.ToString();
            PlayerPrefs.SetInt(pk_name, current_num);
            
        }
        else
        {
            return;
        }
    }
}
