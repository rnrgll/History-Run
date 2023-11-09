using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest2 : MonoBehaviour
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
     List<DialogData> dialogTexts4 = new List<DialogData>(); //#4


    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init(){
        PlayLog = "#0";
        PlayerPrefs.SetString("Quest2PlayLog",PlayLog);
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
        PlayerPrefs.SetString("소서노", "두 국가의 여왕");
        Soseono = PlayerPrefs.GetString("소서노");


        //사니리오 진행 기록
        if(!PlayerPrefs.HasKey("Quest2PlayLog")){
            Init();
            Debug.Log("초기화");
        }
            



        Debug.Log("장면 #1");
        //#1. 채팅 화면: 독백
        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아직도 6개의 칼날이 더 남았다니 쉽지 않겠군...","User"));
        dialogTexts1.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"몽촌토성역에 도착했으니까 뭔가 연락이 곧 있으면 올 것 같은데... 누굴지 궁금하다!","User"));

        dialogTexts1.Add(new DialogData("/emote:None//sound:Phone//color:blue/(띠링-알림이 울린다.)","User"));
        dialogTexts1.Add(new DialogData("/color:black/(‘두 국가의 여왕’이 당신과 채팅하기를 신청하셨습니다.)","None",()=>Show_Images(0))); //확인 버튼 누르면 playlog update + show dialogue2

        Debug.Log("장면 #2");
        //#2. 채팅 화면: 두 국가의 여왕(소서노)-사용자 간의 대화 
        
        dialogTexts2.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(두 국가의 여왕이라면... 설마 백제와 고구려를 건국한 소서노??!!)","User"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"만나서 반갑다. 일곱 빛깔 칼날의 주인을 통해 이야기 들었다. 칠지도를 찾는 데 도움을 주어서 고맙구나. ","Soseono"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"이번 퀘스트를 함께 하게 된 몽촌토성의 수호자이자 두 국가의 여왕, 소서노다. 너는 여기서 평화의 날을 얻어야 해.","Soseono"));

        dialogTexts2.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"우와! 안녕하세요! 저는 /color:#FF5B00/"+  playerName +"/color:black/이고 이번에 칠지도를 찾는 데 함께하게 됐어요.","User"));
        dialogTexts2.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"세상에 소서노 님이라니 생각지도 못했는데 너무 신기...","User"));
        dialogTexts2.Add(new DialogData("/sound:Hansoom//emote:Angry//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"그만, 앞으로의 여정이 짧지 않을 터이니 지금 꼭 필요한 얘기가 아니라면 나중에 하거라.","Soseono"));


        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"앗... 네! 죄송합니다...!","User"));
        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(역시 하나도 아니고 두 국가를 세운 사람이라 그런가 분위기 장난 아니네. 카리스마 쩔어...!!)","User"));

        dialogTexts2.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"어차피 할 얘기니까 지금 솔직히 말하겠다.","Soseono"));
        dialogTexts2.Add(new DialogData("/emote:Angry//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"일곱 빛깔 칼날의 주인이 뭘 믿고 너를 보냈는지는 모르겠지만... 초보 탐정이라니... 난 믿음이 가지 않는구나.","Soseono"));
        dialogTexts2.Add(new DialogData("/emote:Angry//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"이건 백제 전체의 운명이 걸린 중요한 일이다. 아무리 칼날의 주인에게 선택받았다고는 하지만 나는 인정할 수 없어. ","Soseono"));
        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(수호자에게 인정조차 받지 못한 탐정이라니... 역시 아직 내 능력이 부족한 건가...)","User"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"왜 말이 없지? 네가 생각해도 아직 네가 부족하다고 여기는 거냐?","Soseono"));


        dialogTexts2.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아직 제가 많이 부족한 것은 맞습니다.","User"));
        dialogTexts2.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"하지만 기회를 주세요. \n저도 백제의 역사를 지키고 싶은 마음은 소서노 님 못지않아요.","User"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"/speed:down/흐음... /speed:init/그렇단 말이지?","Soseono"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"좋다. 하지만 의지만 가지고 할 수 있는 것은 없어.","Soseono"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"네 능력을 한 번 시험해 봐야겠다. 내 테스트를 통과하면 너를 인정해주마. ","Soseono"));
        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(으아아...테스트라니...? 큰일이다. 하지만 어쩔 수 없지.)","User"));
        dialogTexts2.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네! 해보겠습니다.","User",()=>UpdatePlayLog("#2")));







/*

#

두 국가의 여왕: 호오....아직 풋내기 탐정인 줄만 알았더니 제법이구나. 튼튼한 성벽이 만들어졌어. 이제 적들이 침입해도 한시름 놓을 수 있겠구나. 물론 내 기준으론 아직 조금 부족하지만 일곱 빛깔 칼날의 주인의 눈이 틀리지 않은 것 같아. 널 인정하겠다. 

사용자: (대박...!! 소서노 님에게 인정받다니...!! 성공이야!) 

(퀘스트 2 끝, 퀘스트 3 클릭 유도)
*/


        Debug.Log("#4");
        //#4. 보상 화면
        dialogTexts3.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"앗! 저기 상자가 나타났다!","User",()=>RewardPanelOpen()));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"용기의 날도 획득 완료!","User",()=>UpdatePlayLog("#4")));



        Debug.Log("#5");
        //#5 채팅 화면: 두 국가의 여왕(소서노)-사용자 간의 대화 
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"여왕님, 퀘스트를 통과하고 칼날을 얻었어요! 이제 인정해주시는 건가요?","User"));
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"호오....아직 풋내기 탐정인 줄만 알았더니 제법이구나.","Soseono"));

        dialogTexts4.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+"튼튼한 성벽이 만들어졌어. 이제 적들이 침입해도 한시름 놓을 수 있겠구나.","Soseono"));
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Soseono +"/color:black/\n/size:init/"+" 물론 내 기준으론 아직 조금 부족하지만 일곱 빛깔 칼날의 주인의 눈이 틀리지 않은 것 같아. 널 인정하겠다.","Soseono"));

        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(대박...!! 소서노 님에게 인정받다니...!! 성공이야!)","User",()=>End()));



        
        PlayLog = PlayerPrefs.GetString("Quest2PlayLog");
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
                sc.Q2_Castle();
                break;
            case "GameClear":
                DialogManager.Show(dialogTexts3);
                break;
            case "#4":
                DialogManager.Show(dialogTexts4);
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

        PlayerPrefs.SetInt("UnlockQ3",1);
        Debug.Log("unlockQ3");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest2PlayLog",PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if(playlog.Equals("#2")){
            sc.Q2_Castle();
        }

        else if(playlog.Equals("#4"))
        {
            DialogManager.Show(dialogTexts4);
        }
        else if(playlog.Equals("#1"))
        {
            DialogManager.Show(dialogTexts2);
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



