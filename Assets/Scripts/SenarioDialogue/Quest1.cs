using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest1 : MonoBehaviour
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
    public string King_Geunchogo;



    //시나리오 진행상황

    [Header("PlayLog")]
    public string PlayLog;





    List<DialogData> dialogTexts1 = new List<DialogData>(); //#1
    List<DialogData> dialogTexts2 = new List<DialogData>(); //#2
    List<DialogData> dialogTexts3 = new List<DialogData>(); //#3


    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init()
    {
        PlayLog = "#0";
        PlayerPrefs.SetString("Quest1PlayLog", PlayLog);
    }


    private void Awake()
    {


        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        RewardPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");
        //PlayerPrefs.SetString("근초고왕", "일곱 빛깔 칼날의 주인");

        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        King_Geunchogo = PlayerPrefs.GetString("근초고왕");


        //사니리오 진행 기록
        if (!PlayerPrefs.HasKey("Quest1PlayLog"))
        {
            Init();
            Debug.Log("초기화");
        }
        else
        {
            Debug.Log(PlayerPrefs.HasKey("Quest1PlayLog"));
            Debug.Log(PlayerPrefs.GetString("Quest1PlayLog"));
        }






        Debug.Log("#1");
        //#1. 채팅 화면: 일곱 빛깔 칼날의 주인(근초고왕)-사용자 간의 대화
        dialogTexts1.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "허억, 드디어 한성백제역에 도착했어요.\n이제 칼날을 찾기 위한 여정이 시작되는 건가요? 갑자기 떨리네요!!", "User"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "그렇지! 하지만 너무 걱정하지 말게. 자네 곁에 내가 있지 않나?", "King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "맞아요!! 첫 번째 칼날도 무사히 얻어보겠습니다!!", "User"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "그래, 자신감이 좋구먼.", "King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "아마 퀘스트는 이 지하철역 안에서 발생할 거네. 뭔가 수상쩍은 게 보이면 말해주게나...", "King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "네!!", "User"));
        dialogTexts1.Add(new DialogData("/speed:0.1/(주변을 조사 중...)", "User"));
        dialogTexts1.Add(new DialogData("/speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "헉! 여기 카드들이 떨어져 있어요. \n그리고 뭔가 쪽지가...", "User", () => Show_Images(0)));
        dialogTexts1.Add(new DialogData("쪽지", "None", () => Show_Images(1)));
        dialogTexts1.Add(new DialogData("쪽지 오픈", "None"));

        dialogTexts1.Add(new DialogData("/emote:Think//speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "‘평화의 날을 얻고 싶으면 이 카드 가운데 백제를 가리키는 카드를 선택하라’...? \n이게 퀘스트인가 봐요!", "User"));
        dialogTexts1.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "잘 찾았네! 그럼 퀘스트를 해결하러 가볼까?", "King_Geunchogo", () => UpdatePlayLog("#1"))); //게임으로 이동 //표정 : 웃음


        /*

        #4. 채팅 화면: 일곱 빛깔 칼날의 주인(근초고왕)-사용자 간의 대화

        사용자: 평화의 날을 얻었어요! 생각보다 어렵지 않은데요? 아까 근초고왕께서 많이 가르쳐주셔서 그런가 봐요! 

        일곱 빛깔 칼날의 주인: 허허, 다행이구먼. 하지만 모든 퀘스트가 이번 퀘스트처럼 호락호락하지만은 않을 걸세. 물론 자네도 알고 있겠지만 말이야. 

        사용자: 네, 명심할게요! 꼭 모든 칼날을 모아 근초고왕께 힘을 돌려드릴게요!

        일곱 빛깔 칼날의 주인: 그래. 지금까지 나와 퀘스트를 수행하느라 고생했네. 다음 퀘스트부터는 다른 인물이 자네를 도와줄 걸세. 다음 퀘스트는 풍납 토성역에서 시작될 거야. 자네를 도와줄 인물은 조금 까다롭고 엄격하지만 현명한 분이네. 예의를 매우 중시하니까 이 부분도 명심하게. 무사히 일곱 가지 퀘스트를 모두 해결하기를 응원하네. 행운을 빌지!

        (일곱 빛깔 칼날의 주인이 채팅을 종료하였습니다.) 

        (퀘스트 1 끝, 퀘스트 2 클릭 유도)

        */



        Debug.Log("#3");
        //#3. 보상 화면
        dialogTexts2.Add(new DialogData("/speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "앗 상자가 나타났어! 이게 뭐지? ", "User", () => RewardPanelOpen()));
        dialogTexts2.Add(new DialogData("/emote:Happy//speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "성공이야! 칼날을 얻었어!", "User", () => UpdatePlayLog("#3")));



        Debug.Log("#4");
        //#4. 채팅 화면: 일곱 빛깔 칼날의 주인(근초고왕)-사용자 간의 대화
        dialogTexts3.Add(new DialogData("/emote:Happy//speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "평화의 날을 얻었어요!", "User"));
        dialogTexts3.Add(new DialogData("/emote:Happy//speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "생각보다 어렵지 않은데요? 아까 근초고왕께서 많이 가르쳐주셔서 그런가 봐요!", "User"));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "허허, 다행이구먼. \n하지만 모든 퀘스트가 이번 퀘스트처럼 호락호락하지만은 않을 걸세.", "King_Geunchogo")); //표정 : 웃음
        dialogTexts3.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "물론 자네도 알고 있겠지만 말이야.", "King_Geunchogo"));

        dialogTexts2.Add(new DialogData("/emote:Serious//speed:init//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + " 네, 명심할게요! \n꼭 모든 칼날을 모아 근초고왕께 힘을 돌려드릴게요!", "User"));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "그래. 지금까지 나와 퀘스트를 수행하느라 고생했네.", "King_Geunchogo")); //표정 : 웃음 
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "다음 퀘스트부터는 다른 인물이 자네를 도와줄 걸세.", "King_Geunchogo"));
        dialogTexts3.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "다음 퀘스트는 /color:red/몽촌토성역/color:black/에서 시작될 거야.", "King_Geunchogo"));
        dialogTexts3.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "자네를 도와줄 인물은 조금 까다롭고 엄격하지만 현명한 분이네. 예의를 매우 중시하니까 이 부분도 명심하게.", "King_Geunchogo"));
        dialogTexts3.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo + "/color:black/\n/size:init/" + "무사히 일곱 가지 퀘스트를 모두 해결하기를 응원하네. 행운을 빌지!", "King_Geunchogo", () => Show_Images(2)));
        dialogTexts3.Add(new DialogData("/emote:None//sound:Phone/채팅 종료", "User", () => End()));



        PlayLog = PlayerPrefs.GetString("Quest1PlayLog");
        Debug.Log("현재 플레이 로그" + PlayLog);
        switch (PlayLog)
        {
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts1);
                break;
            case "#1":
                sc.Q1_Card();
                break;
            case "GameClear":
                DialogManager.Show(dialogTexts2);
                break;
            case "#3":
                DialogManager.Show(dialogTexts3);
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

        PlayerPrefs.SetInt("UnlockQ2", 1);
        Debug.Log("unlockQ2");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest1PlayLog", PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if (playlog.Equals("#1"))
        {
            sc.Q1_Card();
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

        RewardPanel.SetActive(false);
    }


}
