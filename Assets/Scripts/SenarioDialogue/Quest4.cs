using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Quest4 : MonoBehaviour
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
    public string Onjo;



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
        PlayerPrefs.SetString("Quest4PlayLog",PlayLog);
    }


    private void Awake()
    {
       //PlayerPrefs.DeleteKey("Quest2PlayLog");
        
        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        RewardPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");
        
        PlayerPrefs.SetString("온조", "왕국의 막내아들");
        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        Onjo = PlayerPrefs.GetString("온조");


        //사니리오 진행 기록
        if(!PlayerPrefs.HasKey("Quest4PlayLog")){
            Init();
            Debug.Log("초기화");
        }


        Debug.Log("장면 #1");
        //#1. 채팅 화면: 독백




        dialogTexts1.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"여왕님의 막내아들이라... 왕족이니 그렇게 호락호락한 사람은 아니겠지. ","User"));
        dialogTexts1.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"그나저나 지금 가고 있는 이 길이 맞나?","User"));
        dialogTexts1.Add(new DialogData("/emote:None//sound:Phone//color:blue/(띠링-알림이 울린다.)","User"));
        dialogTexts1.Add(new DialogData("/color:black/(‘왕국의 막내아들’이 당신과 채팅하기를 신청하셨습니다.)","None",()=>Show_Images(0))); //확인 버튼 누르면 playlog update + show dialogue2





        Debug.Log("장면 #2");
        //#2. 채팅 화면: 왕국의 막내아들(온조)-사용자 간의 대화 
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"거기 누구 없느냐!","Onjo"));
        dialogTexts2.Add(new DialogData("/sound:Uhh//emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"으악!?","User"));

        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"어허, 거기 너. 네가 어머니께서 말씀하신 탐정인가 뭔가 하는 녀석이냐?","Onjo"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"건방지구나. 난 백제를 건국한 초대 왕, 온조다.","Onjo"));

        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"헉, 죄송합니다...! 온조 왕을 몰라뵈었습니다...!","User"));


        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"쯧. 요즘 애들이란... 어른을 봐도 인사를 안 하고 말이야.","Onjo"));
        dialogTexts2.Add(new DialogData("/emote:Arrogant//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"내가 너그러운 마음으로 한 번은 넘어가주겠다.","Onjo"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"흠, 듣자 하니 네가 이곳 풍납토성에 숨겨진 생명의 날을 찾아야 한다던데.","Onjo"));
       
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네, 맞습니다! 여왕님께서 이곳에 오면 힌트를 얻을 수 있을 거라고 하셨습니다.","User"));
        
        dialogTexts2.Add(new DialogData("/emote:Arrogant//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"그래? 흐음... 이 몸이 은혜를 베풀어 그 칼날이 있는 곳을 알려주겠다.","Onjo"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"현재 네가 있는 곳이 풍납토성 근처 맞느냐?","Onjo"));

        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네, 그렇습니다!! 천호역에서 표지판을 따라 풍납시장과 풍납공원을 거쳐오게 되었습니다. ","User"));

        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"그래그래, 지도를 보면서 쭉 오다보면 분명 풍납백제문화공원이 보일 거란다.","Onjo"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"생명의 날은 그 공원에서 퀘스트를 해결해야만 얻을 수 있다.","Onjo"));
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"그리고 공원을 잘 돌아다니다 보면 힌트를 쉬이 얻을 수 있을 거다. 할 수 있겠느냐?","Onjo"));


        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"당연하죠! 좀만 기다려주세요. 어서 해치우고 오겠습니다!","User"));
        dialogTexts2.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"흠... 건방지지만 이런 패기가 나쁘지는 않군.","Onjo"));
        dialogTexts2.Add(new DialogData("/emote:Arrogant//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"성격이 급해서 오래는 못 기다려 준단다.","Onjo"));
        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(으악...역시 그 엄마에 그 아들이군. 후딱 해치워야겠어!)","User",()=>UpdatePlayLog("#2")));



        Debug.Log("장면 #4");
        //#4. 보상 화면
        dialogTexts3.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"어, 뭐지? 저 나무 밑에 한 상자가 있네... ","User"));
        dialogTexts3.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"뭔가 있을 것 같은데 설마 생명의 날?? 에이 설마...","User",()=>RewardPanelOpen()));
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아니 이게 진짜라고?","User"));
        dialogTexts3.Add(new DialogData("/sound:Enjoy//emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"앗싸~! 해냈다!! 얼른 온조 왕께 자랑하러 가야겠다!","User",()=>UpdatePlayLog("#4")));



        Debug.Log("장면 #5");
        //#5 채팅 화면: 왕국의 막내아들(온조)-사용자 간의 대화 
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"오오, 퀘스트를 모두 해결해 생명의 날을 얻었다고?? 대단하구나.","Onjo"));
        dialogTexts4.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"하핫, 감사합니다. 온조 왕께서 도와주신 덕분이지요.","User"));
        
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"에헴, 에헴. 이제 다음 칼날은... /color:red/방이동 고분군/color:black/에 있구나.","Onjo"));
        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"걷기에는 거리가 조금 있으니 지하철을 타고 이동해도 좋겠구나.","Onjo"));

        dialogTexts4.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"앗... 온조 왕께서는 함께하시지 않는 건가요?","User"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"그렇단다. 나는 중요한 일이 있어서 말이지.","Onjo"));
        dialogTexts4.Add(new DialogData("/sound:OnjoLaugh//emote:Arrogant//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"너라면 잘 해낼 수 있을 거다. 이 온조 왕이 인정한 사람이지 않느냐?","Onjo"));
        dialogTexts4.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"감사합니다...! 반드시 칼날의 힘을 모두 얻어서 칠지도를 되찾아올게요! 그때까지 조금만 기다려주세요!","User"));


        dialogTexts4.Add(new DialogData("/emote:Normal//color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"그래그래. 방이동 고분군에서 널 도와줄 사람은... 꽤 자유분방한 사람이란다.","Onjo"));

        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + Onjo +"/color:black/\n/size:init/"+"정말 이상하고 독특한 사람이지. 앞 똑바로 보고 걸어가려무나.","Onjo",()=>Show_Images(1)));
        dialogTexts4.Add(new DialogData("/sound:Phone//emote:None/채팅 종료","User",()=>End()));



        
        PlayLog = PlayerPrefs.GetString("Quest4PlayLog");
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
                sc.Q4_AB();
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

        PlayerPrefs.SetInt("UnlockQ5",1);
        Debug.Log("unlockQ5");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Quest4PlayLog",PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if(playlog.Equals("#2")){
            sc.Q4_AB();
        }
        else if(playlog.Equals("#1")){
            DialogManager.Show(dialogTexts2);
        }
        else if(playlog.Equals("#4")){
            DialogManager.Show(dialogTexts4);
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



