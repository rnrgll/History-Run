using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Q4PopUpSystem : MonoBehaviour
{
    public GameObject Panel;
    public TextMeshProUGUI ResultTxt; //정답 or 오답
    public Sprite CorrectImg; //정답일 때의 img source
    public Sprite WrongImg;  //오답일 때의 img source
    
    public Image Image; //이미지 오브젝트


    public Q4QuizManager quizManager;

    public void popUp(bool result){
        if(result){
            ResultTxt.text = "정답";
            Image.sprite = CorrectImg;

        }
        else{
            ResultTxt.text = "오답";
            Image.sprite = WrongImg;
        }
        Panel.SetActive(true);

        Invoke("popDown", 2);
   
    }
    public void popDown(){
        Panel.SetActive(false);
    }
}
