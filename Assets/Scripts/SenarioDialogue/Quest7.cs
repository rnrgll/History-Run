using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest7 : MonoBehaviour
{


    [Header("Setting")]
    public DialogManager DialogManager;
    public GameObject ImgPanel;
    public GameObject RewardPanel;
    public GameObject Printer;
    public GameObject DialogAsset;

    public GameObject ClearPanel;

    public GameObject[] Popups;


    [Header("SceneChange")]
    public SceneChange sc;





    [Header("Character Name")]
    public string playerName;
    public string Garo;



    //시나리오 진행상황

    [Header("PlayLog")]
    public string PlayLog;

    [Header("FadeInOut")]
    public float fadeSpeed = 1.5f;
    public float SoundFadeSpeed = 0.5f;
    public CanvasGroup canvasGroup;



    List<DialogData> dialogTexts1 = new List<DialogData>();
    List<DialogData> dialogTexts2 = new List<DialogData>();
    List<DialogData> dialogTexts3 = new List<DialogData>();
    List<DialogData> dialogTexts4 = new List<DialogData>();

    public AudioSource BGM;
    public AudioSource currentplay;



    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init()
    {
        PlayLog = "#0";
        PlayerPrefs.SetString("Quest7PlayLog", PlayLog);
    }


    private void Awake()
    {

        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        RewardPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");


        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        Garo = PlayerPrefs.GetString("개로왕");


        //사니리오 진행 기록
        if (!PlayerPrefs.HasKey("Quest7PlayLog"))
        {
            Init();
            Debug.Log("초기화");
        }


        Debug.Log("장면 #1");
        //#1. 채팅 화면:통곡의 군주(개로왕)-사용자 간의 
        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "허억... 허억... 그래도 이번엔 근처라서 다행이네요. 이곳에 정의의 날이 있다는 건가요?", "User"));
        dialogTexts1.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "그렇다네. 좀 더 안으로 들어가려무나.", "Garo"));
        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "역시 석촌동이 ‘돌이 많은 마을’을 뜻하는 만큼 돌이 참 많네요! 우와...", "User"));
        dialogTexts1.Add(new DialogData("/emote:Anxious//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "그렇지. 그런데 많은 사람들의 무덤이니만큼 이곳저곳에서 부정적인 기운이 느껴지는구나...", "Garo"));
        dialogTexts1.Add(new DialogData("/emote:Anxious//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "원한, 슬픔, 후회... 왜인지 마음이 안 좋군그래.", "Garo"));
        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "이곳에 여러 사람이 동시에 매장된 가족묘와 같이 다양한 사람들이 잠들어 있어서 그런가 봐요..", "User"));
        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "잠시 묵념하고 가겠어요.", "User"));
        dialogTexts1.Add(new DialogData("/emote:None/(묵념 중)/wait:4/", "User", null, false));

        dialogTexts1.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "그럼 이제 다시 정의의 날을 얻기 위해 퀘스트를 하고 오려무나. 저 무덤들 앞에 있는 안내문과 이 공간 곳곳을 유의 깊게 살펴보도록 하거라.", "Garo"));
        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "네! 마지막 퀘스트도 잘 돌파하고 오겠습니다.", "User", () => UpdatePlayLog("#1")));


        /*

        #4. 채팅 화면: 통곡의 군주(개로왕)-사용자 간의 대화 



        사용자: 헉...! 저곳이 칼날이 숨겨진 곳...!

        통곡의 군주: 다행일세! 자, 여기서부터는 자네 혼자 가야 하네. 곧 모든 봉인이 풀릴 것 같으니 서두르게나. 

        아 참, 도적들이 칠지도를 빼앗기지 않으려고 함정을 만들어 놨을 터이니 조심하고. 부디 마지막까지 용기를 잃지 말고 칠지도를 되찾아주게!　

        사용자: 넵! 알겠습니다. 반드시 칠지도를 되찾아올게요. 

        통곡의 군주: 이건 내 작은 선물이네. 소소한 도움이 됐으면 좋겠군.

        (부싯돌 클릭) 

        (차원의 문 클릭) 

        (통곡의 군주가 채팅을 종료하였습니다.)

        (퀘스트 7 끝, 에필로그 클릭 유도)
         

        */

        Debug.Log("장면 #3");
        //#3. 보상 화면
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "헉! 저게 상자인가?", "User"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "마지막 칼날이 담긴 상자라 그런지 더 크고 빛나는 것 같네... 어서 열어봐야지!", "User", () => RewardPanelOpen()));

        Debug.Log("장면 #4");
        //#4 채팅 화면: 통곡의 군주(개로왕)-사용자 간의 대화  
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "드디어 칠지도 모든 칼날의 힘을 얻었어! 이제 칠지도를 되찾으러 갈 수 있다구!", "User"));
        dialogTexts3.Add(new DialogData("/emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "축하하네 꼬마 탐정! 나도 해낼 수 없는 일을 해내다니...!", "Garo"));
        dialogTexts3.Add(new DialogData("/emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "자네는 왕인 나보다 더 나은 사람이군.", "Garo"));



        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "감사해요. 그런데 어디 가야 칠지도를 찾을 수 있는 거죠?", "User"));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "칼날의 힘을 얻었지만 칠지도가 있는 곳을 모르는걸요? ", "User"));
        dialogTexts3.Add(new DialogData("/emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "그건 어렵지 않지. 눈을 감고 정신을 집중해 보게나.", "Garo"));
        dialogTexts3.Add(new DialogData("/emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "칼날의 힘이 자네를 칠지도가 있는 곳으로 데려다줄 거네.", "Garo"));
        dialogTexts3.Add(new DialogData("(정신을 집중해보자)", "None", () => FadeInOut()));



        Debug.Log("장면 #5");
        dialogTexts4.Add(new DialogData("/wait:0.8//sound:door//emote:None/차원의 문", "User"));
        dialogTexts4.Add(new DialogData("(칼날이 움직이며 차원의 문을 만들었다.)", "None"));
        dialogTexts4.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "헉...! 저곳이 칼날이 숨겨진 곳...!", "User"));



        dialogTexts4.Add(new DialogData("/emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "다행일세! 자, 여기서부터는 자네 혼자 가야 하네. 곧 모든 봉인이 풀릴 것 같으니 서두르게나. ", "Garo"));
        dialogTexts4.Add(new DialogData("/emote:Sad//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "아 참, 도적들이 칠지도를 빼앗기지 않으려고 함정을 만들어 놨을 터이니 조심하고.", "Garo"));
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "부디 마지막까지 용기를 잃지 말고 칠지도를 되찾아주게!", "Garo"));
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "넵! 알겠습니다. 반드시 칠지도를 되찾아올게요. ", "User"));


        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "이건 내 작은 선물이네. 소소한 도움이 됐으면 좋겠군.", "Garo", () => Show_Images(2)));
        dialogTexts4.Add(new DialogData("부싯돌", "None", () => Show_Images(3)));
        dialogTexts4.Add(new DialogData("/emote:None//sound:Phone/채팅종료", "User"));
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "좋아... 그럼 차원의 문으로 들어가보자!", "User", () => Show_Images(4)));
        dialogTexts4.Add(new DialogData("입장", "None", () => End()));


        PlayLog = PlayerPrefs.GetString("Quest7PlayLog");
        Debug.Log("현재 플레이 로그 " + PlayLog);
        switch (PlayLog)
        {
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts1);
                break;
            case "#1":
                sc.Q7_Input();
                break;
            case "#3":
                DialogManager.Show(dialogTexts3);
                break;
            case "#4":
                DialogManager.Show(dialogTexts4);
                break;
            case "GameClear":
                DialogManager.Show(dialogTexts2);
                break;
        }

    }




    private void Show_Images(int index)
    {
        Debug.Log("show_images");
        ImgPanel.SetActive(true);
        Popups[index].SetActive(true);
    }

    public void End()
    {
        UpdatePlayLog("End");
        DialogAsset.SetActive(false);
        ClearPanel.SetActive(true);

        PlayerPrefs.SetInt("UnlockE", 1);
        Debug.Log("unlockE");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest7PlayLog", PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if (playlog.Equals("#1"))
        {
            sc.Q7_Input();
        }
        else if (playlog.Equals("#4"))
        {
            DialogManager.Show(dialogTexts4);
        }
        else if (playlog.Equals("#3"))
        {
            DialogManager.Show(dialogTexts3);
        }



    }



    public void RewardPanelOpen()
    {
        RewardPanel.SetActive(true);
    }



    public void GetReward()
    {
        UpdatePlayLog("#3");
        RewardPanel.SetActive(false);
    }


    public void FadeInOut()
    {
        //canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
        }
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
        }
        Show_Images(0);
        UpdatePlayLog("#4");

    }



}



