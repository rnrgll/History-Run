using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EP2GameManager : MonoBehaviour
{


    public GameObject StartPanel;
    public GameObject GamePanel;

    public GameObject PassPanel;
    public GameObject HintPanel;

    private void Awake()
    {


        //초기 -> panel 활성화, 비활성화

        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        GamePanel.SetActive(false);


        //시도횟수 설정 + 활성화
        //tryNumTxt_Start.text = tryNum.ToString()+ TryNumString;
        //start panel 활성화
        StartPanel.SetActive(true);
    }
    public void start()
    {

        //game panel 활성화
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
    }


}
