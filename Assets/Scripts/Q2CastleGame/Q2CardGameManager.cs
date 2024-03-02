using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Q2CardGameManager : MonoBehaviour
{
    //게임 횟수
    public int PlayCount;

    public TextMeshProUGUI tryNumText;


    //점수
    public int score = 0;
    public int wrongAnswer = 0;

    //CardDeck
    public List<Q2Card> deck = new List<Q2Card>();
    //CardSlots 위치
    public Transform[] cardSlots;
    //available CardSlots
    public bool[] AnswerSlots;
    public bool[] SelectSlots;

    //마지막에 비활성화를 위해 카드 덱으로 저장
    public List<Q2Card> activeDeck = new List<Q2Card>();


    //Panel
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject PassPanel;
    public GameObject FailPanel;
    public GameObject HintPanel;
    public GameObject GameUICanvas;

    //Scripts
    public Q2SetResult Pass;
    public Q2SetResult Fail;

    public AudioSource Passbgm;
    public AudioSource Failbgm;

    public AudioSource bgm;

    private void Awake()
    {

        Debug.Log("awake()입니다.");
        FailPanel.SetActive(false);
        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        GamePanel.SetActive(false);





        if (PlayerPrefs.HasKey("Q2GamePlayCount"))
        {
            PlayCount = PlayerPrefs.GetInt("Q2GamePlayCount");
            tryNumText.text = (PlayCount + 1).ToString() + "번째 시도";
        }
        else
        {
            tryNumText.text = "1번째 시도";
            PlayCount = 0;

        }

        Debug.Log("도전횟수" + tryNumText.text);
        StartPanel.SetActive(true);

    }


    public void start()
    {
        if (!PlayerPrefs.HasKey("Q2GamePlayCount"))
        {
            PlayCount++;
            PlayerPrefs.SetInt("Q2GamePlayCount", PlayCount);

        }
        else
        {
            //PlayCount = PlayerPrefs.GetInt("Q2GamePlayCount");
            PlayCount++;
            PlayerPrefs.SetInt("Q2GamePlayCount", PlayCount);
        }



        StartPanel.SetActive(false);
        GamePanel.SetActive(true);


        for (int i = 0; i < cardSlots.Length; i++)
        {
            AnswerSlots[i] = false;
            SelectSlots[i] = false;
        }
        SetCard();
    }
    //카드 랜덤 배치 함수
    public void SetCard()
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (deck.Count >= 1)
            {
                Q2Card randCard = deck[Random.Range(0, deck.Count)];
                randCard.gameObject.SetActive(true);
                randCard.cardIndex = i;
                randCard.transform.position = cardSlots[i].position;

                //정답 배열에 표시
                if (randCard.answer)
                {
                    AnswerSlots[i] = true;
                }

                activeDeck.Add(randCard);
                //덱에서 카드 제거
                deck.Remove(randCard);
            }
        }
    }


    public void Submit()
    {
        GameOver();
    }

    public void GameOver()
    {


        //00000
        bgm.Stop();
        GameUICanvas.SetActive(false);

        GamePanel.SetActive(false);
        for (int i = 0; i < AnswerSlots.Length; i++)
        {
            if (AnswerSlots[i] == SelectSlots[i])
            {
                if (AnswerSlots[i])
                {
                    score++;
                }

            }
            else
            {
                wrongAnswer++;
            }
        }

        //카드 비활성화
        for (int i = 0; i < activeDeck.Count; i++)
        {
            activeDeck[i].gameObject.SetActive(false);
        }



        if (score == 3 && wrongAnswer == 0)
        {
            GameSuccess();
        }
        else
        {
            GameFail();
        }
    }



    void GameSuccess()
    {
        Passbgm.Play();
        Pass.setResult(PlayCount);
        Pass.setScore(score);
        PassPanel.SetActive(true);
        PlayerPrefs.SetString("Quest2PlayLog", "GameClear");
    }
    void GameFail()
    {
        Failbgm.Play();
        Fail.setScore(score);
        FailPanel.SetActive(true);
    }



    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
