using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Q5InputManager : MonoBehaviour
{
    public Q5QuizManager quizManager;
    private string playerAnswer = null;

    [SerializeField]
    private TMP_InputField answerInput;


    //placeholder
    [SerializeField]
    private bool _isPlaceholderHideOnSelect;

    public void Clear(){
      answerInput.text = "";
      OutClick();
     }

    /*
    private void Update() {
        playerAnswer=answerInput.text;
        //OutClick();
    }*/

    public void OK(){
        bool result = CompareAnswer();
        if(result){
            Clear();
            quizManager.correct();
        }
        else{
            Clear();
            quizManager.wrong();
        }
    
    }
   
   
    bool CompareAnswer() {
        playerAnswer = answerInput.text;
        if(playerAnswer == null){
            Debug.Log("정답을 입력해주세요");
            return false;
        }
        else if(Equals(playerAnswer, quizManager.Answer)){
            return true;
        }
        else{
            return false;
        }
    } 


//input field를 클릭하면 placeholder가 false가 되도록 한다.
public void OnClick(){
    _isPlaceholderHideOnSelect = true;
    if (this._isPlaceholderHideOnSelect == true)
    {
        this.answerInput.placeholder.gameObject.SetActive(false);
    }
}

public void OutClick(){
if (this._isPlaceholderHideOnSelect == true)
    {
        this.answerInput.placeholder.gameObject.SetActive(true);

    }
}

}

