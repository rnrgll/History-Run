using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class _ItemDoneCount : MonoBehaviour
{
    public Text text;
    
    public Slider slider; // 슬라이더 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        int count = PlayerPrefs.GetInt("평화의 날")
            + PlayerPrefs.GetInt("용기의 날")
            + PlayerPrefs.GetInt("지혜의 날")
            + PlayerPrefs.GetInt("생명의 날")
            + PlayerPrefs.GetInt("신뢰의 날")
            + PlayerPrefs.GetInt("희망의 날")
            + PlayerPrefs.GetInt("정의의 날");
        
        text.text = count.ToString();

        slider.value = count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
