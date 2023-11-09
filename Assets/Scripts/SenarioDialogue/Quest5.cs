using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest5 : MonoBehaviour
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
    public string Goheung;



     //시나리오 진행상황
    
    [Header("PlayLog")]
    public string PlayLog;





    List<DialogData> dialogTexts1 = new List<DialogData>(); 
    List<DialogData> dialogTexts2 = new List<DialogData>(); 
    List<DialogData> dialogTexts3 = new List<DialogData>(); 
    List<DialogData> dialogTexts4 = new List<DialogData>(); 



    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init(){
        PlayLog = "#0";
        PlayerPrefs.SetString("Quest5PlayLog",PlayLog);
    }


    private void Awake()
    {
        
        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        RewardPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");
        
        PlayerPrefs.SetString("고흥", "기억을 걷는 학자");
        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        Goheung = PlayerPrefs.GetString("고흥");


        //사니리오 진행 기록
        if(!PlayerPrefs.HasKey("Quest5PlayLog")){
            Init();
            Debug.Log("초기화");
        }


        Debug.Log("장면 #1");
        //#1. 채팅 화면: 독백
        dialogTexts1.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"자유분방한 사람이라니... 대체 어떤 사람일까? 재미있는 분이면 좋겠다.","User"));
        dialogTexts1.Add(new DialogData("/sound:Phone//emote:None//color:blue/(띠링-알림이 울린다.)","User"));
        dialogTexts1.Add(new DialogData("/color:black/(기억을 걷는 학자가 당신과 채팅하기를 신청하셨습니다.)","None",()=>Show_Images(0))); //확인 버튼 누르면 playlog update + show dialogue2





        Debug.Log("장면 #2");
        //#2. 채팅 화면: 기억을 걷는 학자(고흥)-사용자 간의 대화 
        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"안녕하세요! 기억을 걷는 학자님.","User"));
        dialogTexts2.Add(new DialogData("/sound:Giggle//emote:Evil//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"킬킬킬킬. 그대가 바로 칼날을 찾으러 다니는 탐정인가?","Goheung"));
        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"헉! 어떻게 아셨지요? 신뢰의 날을 찾기 위해 이곳, 방이동 고분군에 왔습니다.","User"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"그래그래. 나는 고흥이다. 내가 누군지는 당연히 알겠지?","Goheung"));
        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"당연하죠...! 백제 최초의 역사서인 서기를 편찬한 학자시잖아요! ","User"));
    
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"그렇지. 신뢰의 날을 찾으러 이곳에 왔다고 했었나? ","Goheung"));
        dialogTexts2.Add(new DialogData("/emote:Evil//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"신뢰의 날은 방이동 고분군을 토끼뜀으로 세 바퀴 돌아야 찾을 수 있을 거란다.","Goheung"));
        dialogTexts2.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네!? 거짓말이시죠?","User"));

        dialogTexts2.Add(new DialogData("/emote:Smile//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"으하하하!! 당연히 거짓말이지. 이제 정말 제대로 알려줄 테니 잘 듣거라.","Goheung"));
        dialogTexts2.Add(new DialogData("/sound:Embrass//emote:What//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(윽, 칼날을 위해 내가 참는다...)","User"));


        dialogTexts2.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"생명의 날은 방이동 고분군 안으로 들어서게 되면 나오는 퀘스트를 풀어야만 얻을 수 있지. 자, 어서 안쪽으로 들어오게.","Goheung"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네! 안쪽으로 들어오니 안내문도 있고 무덤으로 가는 길도 있네요.","User"));
        dialogTexts2.Add(new DialogData("/emote:Evil//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"큭큭. 잘 캐치했군. 그 안내문에서 힌트를 얻으면 퀘스트를 더 쉽게 해결할 수 있을까...아닐까...?","Goheung"));
        dialogTexts2.Add(new DialogData("/sound:Giggle//emote:Evil//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"아무튼 잘해보라고. 캬하하학.","Goheung",()=>UpdatePlayLog("#2")));



        Debug.Log("장면 #4");
        //#4. 보상 화면
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"어라, 무덤 근처에서 뭔가 빛이 나는 것 같은데? 가보자!","User"));
        dialogTexts3.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"헉헉... 이건 상자잖아!","User",()=>RewardPanelOpen()));
        


        Debug.Log("장면 #5");
        //#5 채팅 화면: 기억을 걷는 학자(고흥)-사용자 간의 대화 
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"학자님! 저 돌아왔어요. 신뢰의 날을 얻었습니다!","User"));

        dialogTexts4.Add(new DialogData("/emote:Smile//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"조금 아쉽게 됐군, 크하하하.","Goheung"));
        dialogTexts4.Add(new DialogData("/emote:What//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네?","User"));
        
        dialogTexts4.Add(new DialogData("/emote:Evil//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"클클, 실패했으면 평생 내 조수로 삼는 건데 말이다.","Goheung"));
        dialogTexts4.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"허어억?!","User"));
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"아무튼 축하한다. 그다음 행선지는 /color:red/석촌 고분역/color:black/이란다. 이쪽으로 가면 길이 나올 터다.","Goheung"));
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"그곳에서 너를 기다리고 있는 사람은... 유약한 분이니 네가 잘 대해드리도록 해라.","Goheung"));
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Goheung +"/color:black/\n/size:init/"+"서두르지 않으면 늦을지도 모른단다? ","Goheung",()=>Show_Images(1)));
        dialogTexts4.Add(new DialogData("/sound:Phone//emote:None/채팅 종료","User",()=>End()));




        
        PlayLog = PlayerPrefs.GetString("Quest5PlayLog");
        Debug.Log("현재 플레이 로그" + PlayLog);
        switch(PlayLog){
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts1);
                break;
            case "#1":
                DialogManager.Show(dialogTexts2);
                break;
            case "#2":
                sc.Q5_Input();
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

    public void End(){
        UpdatePlayLog("End");
        DialogAsset.SetActive(false);
        ClearPanel.SetActive(true);

        PlayerPrefs.SetInt("UnlockQ6",1);
        Debug.Log("unlockQ6");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest5PlayLog",PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if(playlog.Equals("#2")){
            sc.Q5_Input();
        }
        else if(playlog.Equals("#1")){
            DialogManager.Show(dialogTexts2);
        }
        

    }



    public void RewardPanelOpen(){
        RewardPanel.SetActive(true); 
    }



    public void GetReward()
    {
        UpdatePlayLog("#4");
        RewardPanel.SetActive(false);
        DialogManager.Show(dialogTexts4);
    }

}



