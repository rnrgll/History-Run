using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class POP_MusicOnOff : MonoBehaviour
{
    [SerializeField] private GameObject textOFF;
    [SerializeField] private GameObject textON;
    [SerializeField] private POP_Switch_Slide switchSlide;

    
    private void Start()
    {
        textON.SetActive(false);
    }

    private void Update()
    {
        if(switchSlide.textIsOn == true)
        {
            SetOn();
        } else
        {
            SetOff();
        }
    }
    public void SetOn()
    {
        textON.SetActive(true);
        textOFF.SetActive(false);
    }

    public void SetOff()
    {
        textON.SetActive(false);
        textOFF.SetActive(true);
    }
}
