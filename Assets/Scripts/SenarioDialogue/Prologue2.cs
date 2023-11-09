using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.UI;
using System;
public class Prologue2 : MonoBehaviour
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


    [Header("Audio")]
    public AudioSource Bgm;





    List<DialogData> dialogTexts1 = new List<DialogData>(); //#1
    List<DialogData> dialogTexts2 = new List<DialogData>(); //#2


    //int falseCount = 0; //오답 선택지 카운터


   


    void Init(){
        PlayLog = "#0";
        PlayerPrefs.SetString("Prologue2PlayLog",PlayLog);
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
        if(!PlayerPrefs.HasKey("Prologue2PlayLog"))
            Init();



        Debug.Log("1");
        
        dialogTexts1.Add(new DialogData("/emote:Smile//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"백제의 숨결이 살아있는 한성백제박물관에 온 것을 환영하네.","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"본 퀘스트를 수행하기에 앞서 자네는 여기서 백제의 역사에 대해 알 수 있는 사전 퀘스트를 수행하게 될 거야.","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"모든 퀘스트들은 백제에 대한 자네의 이해를 돕기 위한 것이니 너무 부담 갖지 말고 편하게 풀면 돼.","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"자, 그럼 제2전시실로 가볼까?","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/emote:None//sound:FootSound/(한성백제박물관 제2전시실로 이동하자)/wait:4/","User",null,false));

        dialogTexts1.Add(new DialogData("/emote:Embrass//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"아, 그러고보니 깜빡할 뻔했네. 자 이걸 받게.","King_Geunchogo",()=>Show_Images(0)));
        dialogTexts1.Add(new DialogData("금관","None"));
        dialogTexts1.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"우와, 이게 뭔가요?","User"));



        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"이건 /color:red/어라하의 금관/color:black/이네. 퀘스트를 풀 때 어려움이 있다면 금관을 클릭해보게나.","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"퀘스트에 대한 /color:red/힌트/color:black/를 얻을 수 있을 걸세. 앞으로 퀘스트를 수행할 때도 힌트가 필요하다면 금관을 클릭하면 돼","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"힌트를 보려면 승차권을 지불해야 하네!","King_Geunchogo"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"지금은 사전 퀘스트이므로 승차권 3개를 주겠네.","King_Geunchogo",()=>Show_Images(1)));
        dialogTexts1.Add(new DialogData("승차권","None"));
        dialogTexts1.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"자 그럼 사전 퀘스트를 수행하고 오게나.","King_Geunchogo",()=>UpdatePlayLog("#1")));

        


        Debug.Log("4");
        //#4. 채팅 화면: 일곱 빛깔 칼날의 주인(근초고왕)-사용자 간의 대화
        dialogTexts2.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"여기까지 오느라 수고 많았네. 이제 백제가 어떤 나라인지 조금이나마 알았겠지? ","King_Geunchogo"));
        dialogTexts2.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"이런 훌륭한 나라의 보물을 빼앗아가다니. 이런 나쁜 놈들! 제가 꼭 칠지도를 되찾아올게요.","User"));
        dialogTexts2.Add(new DialogData("/emote:Smile//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"껄껄, 자네가 그렇게 말하니 나도 좀 마음이 놓이는구먼.","King_Geunchogo"));
        dialogTexts2.Add(new DialogData("/emote:Smile//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"칠지도를 훔쳐 간 도적들도 만만치 않은 상대지만 자네라면 능히 해낼 수 있을걸세.","King_Geunchogo"));
        dialogTexts2.Add(new DialogData("/emote:Smile//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"이제 다음 장소인 /color:red/한성백제역/color:black/으로 이동하면 본격적인 퀘스트가 시작될 거야. 바로 가보자고!","King_Geunchogo",()=>End()));
        
        PlayLog = PlayerPrefs.GetString("Prologue2PlayLog");
        Debug.Log("현재 플레이 로그" + PlayLog);
        switch(PlayLog){
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts1);
                Bgm.Play();
                break;
            case "#1":
                sc.P2_OX();
                break;
            case "GameClear":
                Bgm.Stop();
                RewardPanelOpen();
                Debug.Log("오픈");
                break;
            case "#3":
                Bgm.Play();
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

        PlayerPrefs.SetInt("UnlockQ1",1);
        Debug.Log("unlockQ1");
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Prologue2PlayLog",PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if(playlog.Equals("#1")){
            if(!PlayerPrefs.HasKey("P2GamePlayCount")){
                PlayerPrefs.SetInt("TicketNum",PlayerPrefs.GetInt("TicketNum")+3);
                Debug.Log("PlayerPrefs 승차권 수 : " + PlayerPrefs.GetInt("TicketNum").ToString());
            }

            sc.P2_OX();


        }
            


    }


    public void RewardPanelOpen(){
        RewardPanel.SetActive(true); 

    }



    public void GetReward()
    {
        UpdatePlayLog("#3");
        RewardPanel.SetActive(false);
        DialogManager.Show(dialogTexts2);
        Bgm.Play();
    }







}
//dialogTexts.Add(new DialogData());

/*
/color:#FF5B00/" + playerName +"/color:black/
"/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"
"/color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"
"/color:blue/ (꼬르륵)","None"

*/


