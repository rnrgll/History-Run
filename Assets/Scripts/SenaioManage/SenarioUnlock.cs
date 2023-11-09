using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SenarioUnlock : MonoBehaviour
{
    public GameObject InfoPanel;
    public GameObject[] Senario;
    enum Achieve {UnlockP2, UnlockQ1, UnlockQ2, UnlockQ3, UnlockQ4, UnlockQ5, UnlockQ6, UnlockQ7, UnlockE}
    Achieve[] achieves;

    private void Awake() {
        achieves = (Achieve[])Enum.GetValues(typeof(Achieve));
        Debug.Log("Mydata :  " + PlayerPrefs.GetInt("MyData").ToString());
        if(PlayerPrefs.GetInt("MyData")==0)
            Init();
    }

    void Init()
    {
        PlayerPrefs.SetInt("MyData",1);
        foreach(Achieve achieve in achieves){
            PlayerPrefs.SetInt(achieve.ToString(),0);
        }

        
    }
    void Start()
    {
        Debug.Log("SenarioUnlock.cs Start()호출");
        InfoPanel.SetActive(false);
        UnlockSenario();

    }


    void UnlockSenario()
    {
        for(int index=0;index<Senario.Length;index++)
        {
            //achieves array를 순서대로 접근하여 unlock 되었는지 판단
            string achieveName = achieves[index].ToString();
            bool isUnlock = PlayerPrefs.GetInt(achieveName)==1;
            if(isUnlock){
                Button slot = Senario[index].GetComponent<Button>();
                //Senario[index].GetComponent<Button>().interactable=true;
                slot.interactable=true;
                slot.transform.GetChild(0).gameObject.SetActive(true);
                slot.transform.GetChild(1).gameObject.SetActive(false);
            }
            
        }

    }
    // Update is called once per frame
    /*
    void LateUpdate()
    {
        Debug.Log("lastupdate");
        UnlockSenario();
    }*/
}
