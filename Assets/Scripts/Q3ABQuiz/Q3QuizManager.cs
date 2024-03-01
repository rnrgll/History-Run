using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Q3QuizManager : MonoBehaviour
{
    //시도횟수
    public int PlayCount;

    public TextMeshProUGUI tryNumText;

    public List<Q3QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;

    //결과창 스크립
    public Q3PopUpSystem popUpSystem;
    public Q3SetResult Pass;
    public Q3SetResult Fail;



    // 현재 문제 인덱스

    public TextMeshProUGUI Current;
    int current = 0;
    public TextMeshProUGUI Total;

    //힌트셋팅
    public GameObject HintManager;


    // //문제당 시도횟수
    // int life = 2;
    // public Image Life1;
    // public Image Life2;


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


        //초기 -> panel 활성화, 비활성화
        FailPanel.SetActive(false);
        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        AnswerPanel.SetActive(false);
        GamePanel.SetActive(false);
        MoreInfoPanel.SetActive(false);

        if (PlayerPrefs.HasKey("Q3GamePlayCount"))
        {
            PlayCount = PlayerPrefs.GetInt("Q3GamePlayCount");
            tryNumText.text = (PlayCount + 1).ToString() + "번째 시도";
        }
        else
        {

            tryNumText.text = "1번째 시도";
            PlayCount = 0;

        }


        //start panel 활성화
        StartPanel.SetActive(true);

        //전체 문제 수 설정
        Total.text = QnA.Count.ToString();


        //시도횟수 설정
    }
    public void start()
    {
        if (!PlayerPrefs.HasKey("Q3GamePlayCount"))
        {
            PlayCount++;
            PlayerPrefs.SetInt("Q3GamePlayCount", PlayCount);
        }
        else
        {
            //PlayCount = PlayerPrefs.GetInt("Q3GamePlayCount");
            PlayCount++;
            PlayerPrefs.SetInt("Q3GamePlayCount", PlayCount);
        }



        //game panel 활성화
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        generateQuestion();
    }
    void gameOver()
    {
        bgm.Stop();
        GameUICanvas.SetActive(false);

        GamePanel.SetActive(false);

        if (score >= pass)
        {
            Passbgm.Play();
            Pass.SetReult(PlayCount);
            Pass.SetScore(score);
            PassPanel.SetActive(true);
            PlayerPrefs.SetString("Quest3PlayLog", "GameClear");
        }
        else
        {
            Failbgm.Play();
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
        // Die();


        QnA.RemoveAt(currentQuestion);
        //팝다운과 같이 다음 질문으로 이동하도록  한다.
        Invoke("generateQuestion", 2);
        //generateQuestion();


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
            HintManager.GetComponent<Q3HintManager>().generateHint(currentQuestionNum);
            Debug.Log(currentQuestionNum);
            SetAnswer();



        }
        else
        {
            Debug.Log("Out of range of questions");
            gameOver();

        }


    }
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Q3Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Q3Answers>().isCorrect = true;
            }

        }
    }

}
