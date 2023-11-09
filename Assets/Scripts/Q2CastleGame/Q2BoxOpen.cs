using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class Q2BoxOpen : MonoBehaviour, IPointerClickHandler
{

    [Header("Img")]
    Image box;
    public Sprite open;
    public GameObject effectImg;
    public GameObject slots;
    public GameObject title;
    public GameObject button;
    public TextMeshProUGUI ticketCountTxt;
    public AudioSource sound;

    Animator am_shake;


    private void Start() {
        slots.SetActive(false);
        button.SetActive(false);
        effectImg.SetActive(false);


        box = GetComponent<Image>();
        am_shake = GetComponent<Animator>();

        am_shake.SetBool("shake",true);
        //ticketCountTxt.text= "승차권 x" + PlayerPrefs.GetInt("Q2GameTicketReward").ToString();
    }



    public void BoxOpening()
    {
        title.SetActive(false);
        am_shake.SetBool("shake",false);
        box.sprite = open;
        button.SetActive(true);
        effectImg.SetActive(true);
        slots.SetActive(true);
        ticketCountTxt.text= "승차권 x" + PlayerPrefs.GetInt("Q2GameTicketReward").ToString();
    }


    public void OnPointerClick(PointerEventData eventData)
    {
         if(eventData.button == PointerEventData.InputButton.Left)
        {
            sound.Play();
            BoxOpening();
        }
    }







}
