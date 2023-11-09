using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class P2QuizManager : MonoBehaviour
{
    

    public int PlayCount;
    /* 시도횟수 기능 삭제
        //시도횟수
    public static int tryNum = 1;

        //시도횟수 출력할 문자열과 오브젝트
    public TextMeshProUGUI tryNumTxt_Start;
    public TextMeshProUGUI tryNumTxt_Pass;

    public string TryNumString;
    */


    public List<P2QuestionAndAnswers> QnA;
    public bool Answer;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    public P2PopUpSystem popUpSystem;
    public P2SetResult Pass;
    public P2SetResult Fail;



    // 현재 문제 인덱스

    public TextMeshProUGUI Current;
    int current = 0;
    public TextMeshProUGUI Total;

    //힌트셋팅
    public GameObject HintManager;


    //문제당 시도횟수
    //int life = 2;
    //public Image Life1;
    //public Image Life2;


    //Panel
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject FailPanel;

    public GameObject PassPanel;
    public GameObject AnswerPanel;
    public GameObject HintPanel;
    public GameObject MoreInfoPanel;
    public GameObject GuidePanel;

    //Score
    int score = 0;
    public int pass;

    int playerTicket;





    //for hintmanager
    public int currentQuestionNum;





    public AudioSource correectsound;
    public AudioSource wrongsound;
    public AudioSource Passbgm;
    public AudioSource Failbgm;
    public AudioSource bgm;

    private void Awake() {
        playerTicket = PlayerPrefs.GetInt("TicketNum");

        //초기 -> panel 활성화, 비활성화
        FailPanel.SetActive(false);
        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        AnswerPanel.SetActive(false);
        GamePanel.SetActive(false);
        MoreInfoPanel.SetActive(false);

        //시도횟수 설정 + 활성화
        //tryNumTxt_Start.text = tryNum.ToString()+ TryNumString;
        //start panel 활성화
        StartPanel.SetActive(true);

        //전체 문제 수 설정
        Total.text = QnA.Count.ToString();


        //시도횟수 설정
    }
    public void start() {
        if(!PlayerPrefs.HasKey("P2GamePlayCount")){
            PlayerPrefs.SetInt("P2GamePlayCount",1);
            GuidePanel.SetActive(true);

        }
        else
        {
            PlayCount = PlayerPrefs.GetInt("P2GamePlayCount");
            PlayCount++;
            PlayerPrefs.SetInt("P2GamePlayCount",PlayCount);
        } 
        
        //game panel 활성화
        GamePanel.SetActive(true);
        generateQuestion();
    }
    void gameOver(){
        bgm.Stop();
        
        GamePanel.SetActive(false);
        if(score >= pass){
            //시도횟수 설정 + 활성화
            //tryNumTxt_Pass.text = tryNum.ToString()+ TryNumString;
            Passbgm.Play();
            Pass.SetReultText(score);
            Pass.SetScore(score);
            PassPanel.SetActive(true);
            PlayerPrefs.SetString("Prologue2PlayLog", "GameClear");
        }
        else{
            Failbgm.Play();
            Fail.SetReultText(score);
            Fail.SetScore(score);
            FailPanel.SetActive(true);
        }
        

    }

    public void retry(){
        //tryNum +=1;
        //Debug.Log("시도횟수 : "+tryNum);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    public void correct(){

        correectsound.Play();
        score +=1;
        popUpSystem.popUp(true);
        QnA.RemoveAt(currentQuestion);
        //팝다운과 같이 다음 질문으로 이동하도록 한다.
        Invoke("generateQuestion",2);
        //generateQuestion();

    }
    public void wrong(){
        wrongsound.Play();
        popUpSystem.popUp(false);
        //Die();
        /*
        if(life > 0){
            //뭘 적어야할까요?
        }
        else{
            QnA.RemoveAt(currentQuestion);
            //팝다운과 같이 다음 질문으로 이동하도록  한다.
            Invoke("generateQuestion",2);
            //generateQuestion();*/
        QnA.RemoveAt(currentQuestion);
        Invoke("generateQuestion",2);
        //}

    }

    public void generateQuestion()
    {   
        
        if(QnA.Count > 0){
        current += 1;
        Current.text = current.ToString();
        currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Question;
        
        //hint
        currentQuestionNum = QnA[currentQuestion].QuestionNum;
        HintManager.GetComponent<P2HintManager>().generateHint(currentQuestionNum);
        Debug.Log(currentQuestionNum);
        
        
        
        SetAnswer();
        //SetLife();



        }
        else{
            Debug.Log("Out of range of questions");
            gameOver();
  
        }

        
    }
    void SetAnswer(){
        Answer = QnA[currentQuestion].True;
    }

/* life 기능 삭제
    void SetLife(){
        life = 2;
        Life1.color = new Color(1,1,1);
        Life2.color = new Color(1,1,1);

    }
*/
/*
    void Die(){
        life -= 1;
        if(life==1){
            Life1.color = new Color(0,0,0);
        }
        if(life==0){
            Life2.color = new Color(0,0,0);
        }

    }*/

}
