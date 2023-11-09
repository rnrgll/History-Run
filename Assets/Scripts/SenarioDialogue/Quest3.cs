using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest3 : MonoBehaviour
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
    public string Soseono;



     //시나리오 진행상황
    
    [Header("PlayLog")]
    public string PlayLog;





    List<DialogData> dialogTexts1 = new List<DialogData>(); //#1
    List<DialogData> dialogTexts2 = new List<DialogData>(); //#2
    List<DialogData> dialogTexts3 = new List<DialogData>(); //#3



    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init(){
        PlayLog = "#0";
        PlayerPrefs.SetString("Quest3PlayLog",PlayLog);
    }


    private void Awake()
    {
       //PlayerPrefs.DeleteKey("Quest2PlayLog");
        
        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        RewardPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");
        
        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        Soseono = PlayerPrefs.GetString("소서노");


        //사니리오 진행 기록
        if(!PlayerPrefs.HasKey("Quest3PlayLog")){
            Init();
            Debug.Log("초기화");
        }


        Debug.Log("장면 #1");
        //#1. 채팅 화면: 두 국가의 여왕(소서노)-사용자 간의 대화 
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"이제부터 중요한 이야기니 잘 들어라.","Soseono"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"백제에 대한 기본적인 역사는 일곱 빛깔 칼날의 주인에게 이미 들어 알고 있겠지?","Soseono"));
        dialogTexts1.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네! 빨리 백제 유적지를 돌아다니며 퀘스트를 해결해야 한다고 들었어요.","User"));
        dialogTexts1.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"여기 몽촌토성에서는 뭐부터 하면 될까요?","User"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"몽촌토성 안의 /color:red/백제집자리전시관/color:black/에 가게 되면 몽촌토성에 대해 설명하는 /color:red/안내문/color:black/을 확인할 수 있을 거다.","Soseono"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"안내문에 퀘스트를 해결할 수 있는 단서들이 있을 테니 꼼꼼히 읽어보렴.","Soseono"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"힌트를 얻어 퀘스트를 다 풀게 되면 몽촌토성에 숨겨진 지혜의 날을 얻을 수 있을 것이야.","Soseono"));
        dialogTexts1.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네 감사합니다! 꼭 지혜의 날을 얻어올게요. 조금만 기다리세요!","User",()=>UpdatePlayLog("#1")));


        Debug.Log("장면 #3");
        //#3. 보상 화면
        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"어라? 저 집 뒤에 있는 상자는 뭐지? 확인해봐야겠어!","User",()=>RewardPanelOpen()));
        dialogTexts2.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"칼날이다! 일이 술술 풀리는걸! !","User",()=>UpdatePlayLog("#3")));






        Debug.Log("장면 #4");
        //#4. 채팅 화면: 두 국가의 여왕(소서노)-사용자 간의 대화 
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"여왕님! 성공이에요! 세 번째 날을 얻었어요. 이게 다 여왕님 덕분이에요.","User"));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"아니다. 네가 잘 수행한 거지. 그새 벌써 이렇게 성장하다니 대단하구나.","Soseono"));
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"자, 이제 다음 퀘스트로 넘어가거라. 몽촌토성에 왔으면 당연히 /color:red/풍납토성/color:black/에도 가봐야 하지 않겠니?","Soseono"));
        dialogTexts3.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"오, 그렇다면 다음 퀘스트는 풍납토성에서 시작되는 건가요...?","User"));
        dialogTexts3.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"맞아, 눈치가 빠르구나. 풍납토성의 수호자는 내 막내아들이란다.","Soseono"));
        dialogTexts3.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"정사를 돌보느라 시달려서 요즘에 많이 괴팍해졌지만 그래도 맘씨는 착한 아이야.","Soseono"));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"다음 퀘스트도 쉽진 않을 테지만 너 자신을 믿고 나아가거라.","Soseono",()=>Show_Images(0)));
        dialogTexts3.Add(new DialogData("/sound:Phone//emote:None/채팅 종료","User",()=>End()));



        
        PlayLog = PlayerPrefs.GetString("Quest3PlayLog");
        Debug.Log("현재 플레이 로그" + PlayLog);
        switch(PlayLog){
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts1);
                break;
            case "#1":
                sc.Q3_AB();
                break;
            case "#3":
                DialogManager.Show(dialogTexts3);
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

    public void End(){
        UpdatePlayLog("End");
        DialogAsset.SetActive(false);
        ClearPanel.SetActive(true);

        PlayerPrefs.SetInt("UnlockQ4",1);
        Debug.Log("unlockQ4");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest3PlayLog",PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if(playlog.Equals("#1")){
            sc.Q3_AB();
        }
        else if(playlog.Equals("#3")){
            DialogManager.Show(dialogTexts3);
        }
        

    }



    public void RewardPanelOpen(){
        RewardPanel.SetActive(true); 
    }



    public void GetReward()
    {
        RewardPanel.SetActive(false);
    }

}
//dialogTexts.Add(new DialogData());

/*
/color:#FF5B00/" + playerName +"/color:black/
"/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"
"/color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"
"/color:blue/ (꼬르륵)","None"

*/


