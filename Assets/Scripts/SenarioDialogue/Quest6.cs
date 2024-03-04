using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest6 : MonoBehaviour
{


    [Header("Setting")]
    public DialogManager DialogManager;
    public GameObject ImgPanel;
    public GameObject RewardPanel;
    public GameObject Printer;
    public GameObject DialogAsset;

    public GameObject ClearPanel;

    public GameObject[] Popups;

    public TextMeshProUGUI TicketRewardText;

    [Header("SceneChange")]
    public SceneChange sc;




    [Header("Character Name")]
    public string playerName;
    public string Garo;



    //시나리오 진행상황

    [Header("PlayLog")]
    public string PlayLog;





    List<DialogData> dialogTexts1 = new List<DialogData>();
    List<DialogData> dialogTexts2 = new List<DialogData>();
    List<DialogData> dialogTexts3 = new List<DialogData>();
    List<DialogData> dialogTexts4 = new List<DialogData>();



    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init()
    {
        PlayLog = "#0";
        PlayerPrefs.SetString("Quest6PlayLog", PlayLog);
    }


    private void Awake()
    {

        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        RewardPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");

        PlayerPrefs.SetString("개로왕", "통곡의 군주");
        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        Garo = PlayerPrefs.GetString("개로왕");


        //사니리오 진행 기록
        if (!PlayerPrefs.HasKey("Quest6PlayLog"))
        {
            Init();
            Debug.Log("초기화");
        }


        Debug.Log("장면 #1");
        //#1. 채팅 화면: 독백




        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(이번엔 어떤 분이 계실까? 잘 대해드리라고 한 건 무슨 의미일까...)", "User"));
        dialogTexts1.Add(new DialogData("/sound:Phone//emote:None//color:blue/(띠링-알림이 울린다.)", "User"));
        dialogTexts1.Add(new DialogData("/color:black/(‘통곡의 군주’가 당신과 채팅하기를 신청하셨습니다.)", "None", () => Show_Images(0))); //확인 버튼 누르면 playlog update + show dialogue2





        Debug.Log("장면 #2");
        //#2. 채팅화면: 통곡의 군주(개로왕)-사용자 간의 대화 
        dialogTexts2.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + ".....", "Garo"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "통곡의 군주님, 계신가요?", "User"));
        dialogTexts2.Add(new DialogData("/sound:Hum//emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(이상하다, 왜 아무 말씀이 없으시지...?)", "User"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "군주님!!!!!!! 계신가요!!!!!!!", "User"));

        dialogTexts2.Add(new DialogData("/emote:Anxious//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "/speed:down/.../speed:init/어, 어이쿠. 누가 와있었나...", "Garo"));
        dialogTexts2.Add(new DialogData("/emote:Anxious//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "그대는, 희망의 날을 찾으러 온 장군인가?", "Garo"));

        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "장군까지는 아니구요...! 저는 탐정이고 희망의 날을 찾기 위해서는 통곡의 군주님의 도움이 필요해서 왔습니다.", "User"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "내 도움이라... 내가 자네에게 도움이 될지는 모르겠지만 말야... ", "Garo"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "일단 나도 자기소개를 해보자면, 한성 백제의 마지막 왕 개로왕일세.", "Garo"));

        dialogTexts2.Add(new DialogData("/sound:Uhh//emote:Shock//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(!!! 이분이, 개로왕...)", "User"));
        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "아, 개로왕이시군요! 익히 들어 알고 있습니다. 잘 부탁드립니다! ", "User"));
        dialogTexts2.Add(new DialogData("/emote:Sad//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "내가 후대에 어떤 왕으로 기록되었을지 불 보듯 뻔하군...", "Garo"));
        dialogTexts2.Add(new DialogData("/emote:Sad//sound:cry//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "나는 그토록 어리석고 무능한 왕이었으니 말야...", "Garo"));
        dialogTexts2.Add(new DialogData("/sound:cry//emote:Sad//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "나 때문에 백제가... 훌쩍...", "Garo"));
        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + " ...통곡의 군주님? 괜찮으세요?", "User"));
        dialogTexts2.Add(new DialogData("/sound:Sad//emote:Sad//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "내가 아니라 다른 사람이 왕이 되었더라면, 백제의 수도 한성이 함락되진 않았을 거라네... 흐어어엉...", "Garo"));
        dialogTexts2.Add(new DialogData("/sound:Uhh//emote:Embrass//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(으악...! 빨리 날을 찾아야 하는데....이를 어쩐다...!)", "User"));
        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(일단 빨리 군주님을 달래 드리고 칼날에 대한 힌트를 얻어야겠어!)", "User", () => UpdatePlayLog("#2")));






        Debug.Log("장면 #4");
        //#4. 보상 화면
        dialogTexts3.Add(new DialogData("/sound:cry//emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "흑... 정말 고맙네, 자네 덕분에 기분이 좀 나아졌다네.", "Garo"));
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "아닙니다! 군주님께서는 무능한 왕이 아니십니다. 너무 자책하지 마십시오...", "User"));
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "어라? 통곡의 군주님 발밑에서 뭔가 빛이 납니다...!", "User"));
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "내 발밑...? ", "Garo"));
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "제가 잠시 파보겠습니다!", "User"));
        dialogTexts3.Add(new DialogData("/sound:Enjoy//emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "헉. 이건 칼날이 들어있는 상자인 듯해요! 심봤다!!", "User", () => RewardPanelOpen()));




        Debug.Log("장면 #5");
        //#5 채팅 화면: 왕국의 막내아들(온조)-사용자 간의 대화 
        dialogTexts4.Add(new DialogData("/emote:Release//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "이런 곳에서 칼날이 나오다니! 희망의 날을 찾아 정말 다행일세.", "Garo"));
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "그러게요!! 그럼 이제 칼날이 하나 남은 거네요!!", "User"));
        dialogTexts4.Add(new DialogData("/sound:Sad//emote:Sad//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "흐윽... 흑... 고마워, 자네. 이제 마지막 칼날을 찾으러 함께 가봅세.", "Garo"));
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "마지막 칼날, 정의의 날을 찾을 수 있는 곳은 바로 이 근처라네.", "Garo", () => End()));



        PlayLog = PlayerPrefs.GetString("Quest6PlayLog");
        Debug.Log("현재 플레이 로그" + PlayLog);
        switch (PlayLog)
        {
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts1);
                break;
            case "#1":
                DialogManager.Show(dialogTexts2);
                break;
            case "#2":
                sc.Q6_Affection();
                break;
            case "#4":
                DialogManager.Show(dialogTexts4);
                break;
            case "GameClear":
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

        PlayerPrefs.SetInt("UnlockQ7", 1);
        Debug.Log("unlockQ7");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest6PlayLog", PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if (playlog.Equals("#2"))
        {
            sc.Q6_Affection();
        }
        else if (playlog.Equals("#1"))
        {
            DialogManager.Show(dialogTexts2);
        }
        else if (playlog.Equals("#4"))
        {
            DialogManager.Show(dialogTexts4);
        }



    }



    public void RewardPanelOpen()
    {
        RewardPanel.SetActive(true);
    }



    public void GetReward()
    {
        UpdatePlayLog("#4");
        RewardPanel.SetActive(false);
    }

}



