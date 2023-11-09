using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenarioNameSetting : MonoBehaviour
{

    private void Awake() {
        SenarioName();
        if(!PlayerPrefs.HasKey("ItemSetting"))
            itemInit();

    }
    public void SenarioName(){
        Dictionary<string, string> senario = new Dictionary<string, string>();
        senario.Add("P1", "프롤로그 1");
        senario.Add("P2", "프롤로그 2");
        senario.Add("Q1", "퀘스트 1");
        senario.Add("Q2", "퀘스트 2");
        senario.Add("Q3", "퀘스트 3");
        senario.Add("Q4", "퀘스트 4");
        senario.Add("Q5", "퀘스트 5");
        senario.Add("Q6", "퀘스트 6");
        senario.Add("Q7", "퀘스트 7");
        senario.Add("E", "에필로그");

        foreach (KeyValuePair<string,string> entry in senario){
            PlayerPrefs.SetString(entry.Key,entry.Value);
        }

        Debug.Log("시나리오 이름 셋팅");
    }
 public void itemInit(){
        PlayerPrefs.SetInt("평화의 날", 0);
        PlayerPrefs.SetInt("용기의 날", 0);

        PlayerPrefs.SetInt("지혜의 날", 0);
        PlayerPrefs.SetInt("생명의 날", 0);
        PlayerPrefs.SetInt("신뢰의 날", 0);
        PlayerPrefs.SetInt("희망의 날", 0);
        PlayerPrefs.SetInt("정의의 날", 0);
        PlayerPrefs.SetInt("칠지도", 0);


        PlayerPrefs.SetInt("ItemSetting", 1);




 }

    
}
