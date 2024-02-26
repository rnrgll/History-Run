using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Q6QuizManager : MonoBehaviour
{
    //시도횟수
    public int PlayCount;

    public TextMeshProUGUI tryNumText;



    public List<Q6QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public TextMeshProUGUI QuestionTxt;


    //호감도 점수용

    public TextMeshProUGUI Points; //점수
    //public GameObject Panel;
    Color color;
    public Image heart;

    //표정 변화용
    public Image NPC;
    public Sprite Idle;
    public Sprite Angry;
    public Sprite Happy;

    public Q6PopUpSystem popUpSystem;
    public Q6SetResult Pass;

    public Q6Progressbar proBar;



    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject FailPanel;

    public GameObject PassPanel;
    public GameObject AnswerPanel;
    public GameObject HintPanel;
    public GameObject MoreInfoPanel;
    public GameObject GameUICanvas;



    public AudioSource correectsound;
    public AudioSource wrongsound;
    public AudioSource Passbgm;
    public AudioSource Failbgm;
    public AudioSource bgm;




    private void Awake()
    {



        FailPanel.SetActive(false);
        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        AnswerPanel.SetActive(false);
        GamePanel.SetActive(false);

        if (PlayerPrefs.HasKey("Q6GamePlayCount"))
        {
            PlayCount = PlayerPrefs.GetInt("Q6GamePlayCount");
            tryNumText.text = (PlayCount + 1).ToString() + "번째 시도";
        }
        else
        {
            tryNumText.text = "1번째 시도";
            PlayCount = 0;
        }


        StartPanel.SetActive(true);
    }
    public void start()
    {
        if (!PlayerPrefs.HasKey("Q6GamePlayCount"))
        {
            PlayCount++;
            PlayerPrefs.SetInt("Q6GamePlayCount", PlayCount);
        }
        else
        {
            PlayCount++;
            PlayerPrefs.SetInt("Q6GamePlayCount", PlayCount);

        }


        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        generateQuestion();
        if (AnswerPanel.activeSelf == true)
            Debug.Log("start : 활성화");
        else
            Debug.Log("start : 비활성화");

    }

    void gameOver(int score)
    {
        bgm.Stop();
        GamePanel.SetActive(false);
        GameUICanvas.SetActive(false);
        proBar.result = score;
        Debug.Log("게임 종료 시점의 누적 호감도 :  " + proBar.result);

        if (score >= proBar.goal)
        {
            Passbgm.Play();
            Pass.SetReultText(PlayCount);
            PassPanel.SetActive(true);
            PlayerPrefs.SetString("Quest6PlayLog", "GameClear");

        }
        else
        {
            Failbgm.Play();
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
        NPC.sprite = Happy;
        Points.text = "+20";
        heart.color = new Color32(255, 255, 255, 255);

        proBar.current += 20;
        popUpSystem.popUp();
        QnA.RemoveAt(currentQuestion);

    }
    public void wrong()
    {
        wrongsound.Play();
        NPC.sprite = Angry;
        Points.text = "-10";
        heart.color = new Color32(70, 70, 70, 255);

        proBar.current -= 10;
        popUpSystem.popUp();
        QnA.RemoveAt(currentQuestion);
    }




    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Q6Answers>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<Q6Answers>().isCorrect = true;
            }

        }
    }
    public void generateQuestion()
    {
        NPC.sprite = Idle;

        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswer();
        }
        else
        {
            Debug.Log("Out of range of questions");
            gameOver(proBar.current);

        }


    }


}
