using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class _ItemListMenu : MonoBehaviour
{
    private Toggle toggle1;
    private Toggle toggle2;
    private Toggle toggle3;
    private Toggle toggle4;
    private Toggle toggle5;
    private Toggle toggle6;
    private Toggle toggle7;

    private int count;
    
    public GameObject finalItem;

    bool GetItemStatus(String itemName)
    {
        int flag = PlayerPrefs.GetInt(itemName);
        if (flag == 1)
        {
            return true;
        }

        return false;
        // if ()
        // {
        //     toggle.isOn = true;
        // }
    }

    void ItemInit()
    {
        int count = 0;
        toggle1 = GameObject.Find("List (1)").GetComponent<Toggle>();
        toggle2 = GameObject.Find("List (2)").GetComponent<Toggle>();
        toggle3 = GameObject.Find("List (3)").GetComponent<Toggle>();
        toggle4 = GameObject.Find("List (4)").GetComponent<Toggle>();
        toggle5 = GameObject.Find("List (5)").GetComponent<Toggle>();
        toggle6 = GameObject.Find("List (6)").GetComponent<Toggle>();
        toggle7 = GameObject.Find("List (7)").GetComponent<Toggle>(); 
        
        toggle1.isOn = GetItemStatus("평화의 날");
        if(toggle1.isOn)
            count++;
        toggle2.isOn = GetItemStatus("용기의 날");
        toggle3.isOn = GetItemStatus("지혜의 날");
        toggle4.isOn = GetItemStatus("생명의 날");
        toggle5.isOn = GetItemStatus("신뢰의 날");
        toggle6.isOn = GetItemStatus("희망의 날");
        toggle7.isOn = GetItemStatus("정의의 날");        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ItemInit();
        
        if (GetItemStatus("칠지도"))
        {
            finalItem.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
