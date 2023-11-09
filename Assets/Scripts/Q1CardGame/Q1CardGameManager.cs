using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Q1CardGameManager : MonoBehaviour
{
    //게임 횟수
    public int PlayCount;

    public TextMeshProUGUI tryNumText;


    //점수
    public int score = 0;

    //CardDeck
    public List<Q1Card> deck = new List<Q1Card>();
    //CardSlots 위치
    public Transform[] cardSlots;
    //available CardSlots
    public bool[] AnswerSlots;
    public bool[] SelectSlots;
    
    //마지막에 비활성화를 위해 카드 덱으로 저장
    public List<Q1Card> activeDeck = new List<Q1Card>();


    //Panel
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject PassPanel;
    public GameObject FailPanel;
    public GameObject HintPanel;

    //Scripts
    public Q1SetResult Pass;
    public Q1SetResult Fail;


    public AudioSource Passbgm;
    public AudioSource Failbgm;

    public AudioSource bgm;


    private void Awake() {
        Debug.Log("awake()입니다.");
        FailPanel.SetActive(false);
        PassPanel.SetActive(false);
        HintPanel.SetActive(false);
        GamePanel.SetActive(false);





        if(PlayerPrefs.HasKey("Q1GamePlayCount"))
        {
            PlayCount = PlayerPrefs.GetInt("Q1GamePlayCount");
            tryNumText.text = (PlayCount+1).ToString() + "번째 시도";
        }
        else{
            tryNumText.text = "1번째 시도";
            PlayCount = 0;
        }

        Debug.Log("도전횟수"+tryNumText.text);
        StartPanel.SetActive(true);

    }


    public void start() {
        if(!PlayerPrefs.HasKey("Q1GamePlayCount")){
            PlayCount++;
            PlayerPrefs.SetInt("Q1GamePlayCount",PlayCount);
            

        }
        else
        {
            PlayCount = PlayerPrefs.GetInt("Q1GamePlayCount");
            PlayCount++;
            PlayerPrefs.SetInt("Q1GamePlayCount",PlayCount);
        } 



        StartPanel.SetActive(false);
        GamePanel.SetActive(true);


        for(int i=0;i<cardSlots.Length;i++){
            AnswerSlots[i]=false;
            SelectSlots[i]=false;
        }
        SetCard();
    }
    //카드 랜덤 배치 함수
    public void SetCard(){
        for(int i=0; i<cardSlots.Length; i++){
            if(deck.Count >= 1){
                Q1Card randCard = deck[Random.Range(0,deck.Count)];
                randCard.gameObject.SetActive(true);
                randCard.cardIndex = i;
                randCard.transform.position=cardSlots[i].position;

                //정답 배열에 표시
                if(randCard.answer){
                    AnswerSlots[i] = true;
                }

                activeDeck.Add(randCard);
                //덱에서 카드 제거
                deck.Remove(randCard);
            }
        }
    }


    public void Submit(){
        GameOver();
    }

    public void GameOver(){
        bgm.Stop();

        GamePanel.SetActive(false);
        for(int i=0;i<AnswerSlots.Length;i++){
            if(AnswerSlots[i]&&AnswerSlots[i]==SelectSlots[i]){
                score++;
            }

        }

        //카드 비활성화
        for(int i=0; i<activeDeck.Count;i++){
            activeDeck[i].gameObject.SetActive(false);
        }



        if(score==5){
            Passbgm.Play();
            Pass.setResult(PlayCount);
            Pass.setScore(score);
            PassPanel.SetActive(true);
            PlayerPrefs.SetString("Quest1PlayLog", "GameClear");
        }
        else{
            Failbgm.Play();
            Fail.setScore(score);
            FailPanel.SetActive(true);
        }
    }




    public void retry(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




}
