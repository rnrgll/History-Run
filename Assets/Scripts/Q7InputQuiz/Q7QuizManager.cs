using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Q7QuizManager : MonoBehaviour
{
    public int PlayCount;
    public TextMeshProUGUI tryNumText;

    public List<Q7QuestionAndAnswers> QnA;
    public string Answer;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    public Q7PopUpSystem popUpSystem;
    public Q7SetResult Pass;
    public Q7SetResult Fail;


    // 현재 문제 인덱스

    public TextMeshProUGUI Current;
    int current = 0;
    public TextMeshProUGUI Total;

    //힌트셋팅
    public GameObject HintManager;


    //생명
    int life = 2;
    public Image Life1;
    public Image Life2;


    //Panel
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject FailPanel;

    public GameObject PassPanel;
    public GameObject AnswerPanel;
    public GameObject HintPanel;
    public GameObject MoreInfoPanel;
    public GameObject GameUICanvas;

    //Score
    int score = 0;
    public int pass;
    int playerTicket;

    //for hintmanger
    public int currentQuestionNum;
    public AudioSource correectsound;
    public AudioSource wrongsound;
    public AudioSource Passbgm;
    public AudioSource Failbgm;
    public AudioSource bgm;

    private void Awake()
    {
        playerTicket = PlayerPrefs.GetInt("TicketNum");

        FailPanel.SetActive(false);
        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        AnswerPanel.SetActive(false);
        GamePanel.SetActive(false);
        MoreInfoPanel.SetActive(false);


        if (PlayerPrefs.HasKey("Q7GamePlayCount"))
        {
            PlayCount = PlayerPrefs.GetInt("Q7GamePlayCount");
            tryNumText.text = (PlayCount + 1).ToString() + "번째 시도";

        }
        else
        {
            tryNumText.text = "1번째 시도";
            PlayCount = 0;

        }

        Total.text = QnA.Count.ToString();
        StartPanel.SetActive(true);
    }
    public void start()
    {
        if (!PlayerPrefs.HasKey("Q7GamePlayCount"))
        {
            PlayCount++;
            PlayerPrefs.SetInt("Q7GamePlayCount", PlayCount);
        }
        else
        {
            PlayCount++;
            PlayerPrefs.SetInt("Q7GamePlayCount", PlayCount);
        }



        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        Total.text = QnA.Count.ToString();

        generateQuestion();
        if (AnswerPanel.activeSelf == true)
            Debug.Log("start : 활성화");
        else
            Debug.Log("start : 비활성화");

    }
    void gameOver()
    {
        bgm.Stop();
        GameUICanvas.SetActive(false);
        // if(!PlayerPrefs.HasKey("Q7GamePlayCount"))
        // {
        //     PlayerPrefs.SetInt("Q7GamePlayCount", 1);
        // }
        // else
        // {
        //     PlayCount++;
        //     PlayerPrefs.SetInt("Q7GamePlayCount", PlayCount);
        // }
        GamePanel.SetActive(false);
        if (score >= pass)
        {
            Passbgm.Play();
            Pass.SetReult(PlayCount);
            Pass.SetScore(score);
            PassPanel.SetActive(true);
            PlayerPrefs.SetString("Quest7PlayLog", "GameClear");
        }
        else
        {
            Failbgm.Play();
            Fail.SetReult(score);
            Fail.SetScore(score);
            FailPanel.SetActive(true);
        }


    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    public void correct()
    {
        correectsound.Play();
        score += 1;
        popUpSystem.popUp(true);
        QnA.RemoveAt(currentQuestion);
        //팝다운과 같이 다음 질문으로 이동하도록 한다.
        Invoke("generateQuestion", 2);
        //generateQuestion();

    }

    public void wrong()
    {
        wrongsound.Play();
        popUpSystem.popUp(false);
        Die();
        if (life > 0)
        {
            //뭘 적어야할까요?
        }
        else
        {
            QnA.RemoveAt(currentQuestion);
            //팝다운과 같이 다음 질문으로 이동하도록  한다.
            Invoke("generateQuestion", 2);
            //generateQuestion();
        }



    }

    void SetAnswer()
    {
        Answer = QnA[currentQuestion].Answer;
    }
    public void generateQuestion()
    {

        if (QnA.Count > 0)
        {
            current += 1;
            Current.text = current.ToString();
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            currentQuestionNum = QnA[currentQuestion].QuestionNum;


            HintManager.GetComponent<Q7HintManager>().generateHint(currentQuestionNum);
            Debug.Log(currentQuestionNum);
            SetAnswer();
            SetLife();



        }
        else
        {
            Debug.Log("Out of range of questions");
            gameOver();

        }


    }

    void SetLife()
    {
        life = 2;
        Life1.color = new Color(1, 1, 1);
        Life2.color = new Color(1, 1, 1);

    }
    void Die()
    {
        life -= 1;
        if (life == 1)
        {
            Life1.color = new Color(0, 0, 0);
        }
        if (life == 0)
        {
            Life2.color = new Color(0, 0, 0);
        }

    }

}
