using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using TMPro;
using System;
public class Epilogue : MonoBehaviour
{


    [Header("Setting")]
    public DialogManager DialogManager;
    public GameObject ImgPanel;
    public GameObject Printer;
    public GameObject DialogAsset;

    public GameObject ClearPanel;

    public GameObject[] Popups;


    [Header("SceneChange")]
    public SceneChange sc;




    [Header("Character Name")]
    public string playerName;
    public string Onjo;
    public string Soseono;
    public string Garo;
    public string Goheung;
    public string King;
    string Thief = "그림자 도적단";
    string Anchor = "앵커";




    //시나리오 진행상황

    [Header("PlayLog")]
    public string PlayLog;


    [Header("Audio")]
    public AudioSource[] Bgm;
    //public AudioSource Bgm2;
    //public AudioSource Bgm3;
    //public AudioSource Bgm4;


    [Header("Background")]
    public GameObject bg1;
    public GameObject bg2;





    List<DialogData> dialogTexts1 = new List<DialogData>();
    List<DialogData> dialogTexts2 = new List<DialogData>();
    List<DialogData> dialogTexts3 = new List<DialogData>();
    List<DialogData> dialogTexts4 = new List<DialogData>();
    List<DialogData> dialogTexts5 = new List<DialogData>();
    List<DialogData> dialogTexts6 = new List<DialogData>();
    List<DialogData> dialogTexts7 = new List<DialogData>();
    List<DialogData> dialogTexts8 = new List<DialogData>();
    List<DialogData> dialogTexts9 = new List<DialogData>();

    //int falseCount = 0; //오답 선택지 카운터



    //초기화
    void Init()
    {
        PlayLog = "#0";
        PlayerPrefs.SetString("EpiloguePlayLog", PlayLog);
    }


    private void Awake()
    {
        //PlayerPrefs.DeleteKey("Quest2PlayLog");

        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");

        playerName = PlayerPrefs.GetString("PlayerName"); //default "플레이어"
        PlayerPrefs.SetString("온조", "왕국의 막내아들");
        PlayerPrefs.SetString("소서노", "두 국가의 여왕");
        PlayerPrefs.SetString("근초고왕", "일곱 빛깔 칼날의 주인");
        PlayerPrefs.SetString("개로왕", "통곡의 군주");
        PlayerPrefs.SetString("고흥", "기억을 걷는 학자");




        Onjo = PlayerPrefs.GetString("온조");
        Soseono = PlayerPrefs.GetString("소서노");
        King = PlayerPrefs.GetString("근초고왕");
        Garo = PlayerPrefs.GetString("개로왕");
        Goheung = PlayerPrefs.GetString("고흥");




        //사니리오 진행 기록
        if (!PlayerPrefs.HasKey("EpiloguePlayLog"))
        {
            Init();
            Debug.Log("초기화");
        }


        Debug.Log("장면 #1");
        //#1. 채팅 화면: 독백




        dialogTexts1.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "이 동굴 안에 칠지도가 숨겨져 있다는 거지?", "User"));
        dialogTexts1.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "나쁜 놈들! 중요한 고대 유적을 훔쳐 가다니. 가만두지 않겠어...! ", "User"));
        dialogTexts1.Add(new DialogData("(동굴을 클릭해보자)", "None", () => Show_Images(0)));
        dialogTexts1.Add(new DialogData("동굴클릭+발소리", "None"));
        dialogTexts1.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "어우 어두침침해. 왠지 으슥한 게 살짝 무서워지네. 불을 켜야겠는걸? ", "User"));
        dialogTexts1.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "아참, 아까 통곡의 군주에게 받은 부싯돌이 있었지?", "User", () => Show_Images(1)));
        dialogTexts1.Add(new DialogData("부싯돌 클릭", "None"));
        dialogTexts1.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "휴, 이제야 좀 밝아졌네. 일단 안으로 좀 더 들어가봐야겠어. ", "User"));
        dialogTexts1.Add(new DialogData("(동굴 안쪽에서 무언가가 반짝거린다.)", "None"));
        dialogTexts1.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "어? 저 반짝이는 거는 뭐지?", "User"));
        dialogTexts1.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "으악! 불화살이잖아", "User", () => UpdatePlayLog("#1")));





        Debug.Log("장면 #3");
        //#３. 채팅 화면: 독백
        dialogTexts2.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "휴, 다행이다. 불화살을 모두 피했어", "User"));
        dialogTexts2.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "이거 진짜 쉽지 않겠는걸? 설마 다음에 또 함정이 있는 거 아니겠지? ", "User"));
        dialogTexts2.Add(new DialogData("/emote:None//sound:FootSound/(동굴 안쪽으로 더 들어가보자)/wait:5.5/", "User", null, false));

        dialogTexts2.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "오? 이 문이랑 조각들은 뭐지? 문에 조각들을 맞춰야 하는 건가?", "User"));
        dialogTexts2.Add(new DialogData("/emote:None//sound:Kung/(덜커덕 쿵!)", "User", () => Show_Images(2), false));
        dialogTexts2.Add(new DialogData("/emote:None/문", "User"));

        dialogTexts2.Add(new DialogData("/emote:None/(걸어온 길 뒤에 돌문이 하나 생겼다.)", "User"));

        dialogTexts2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "이런! 고립되어버렸어.", "User"));
        dialogTexts2.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "앗 차가워? 이게 뭐지?", "User"));
        dialogTexts2.Add(new DialogData("/emote:None/(갇힌 공간으로 물이 차오르고 있다.)", "User"));

        dialogTexts2.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "큰일 났다! 물이 차오르고 있잖아? 빨리 문제를 해결하지 못하면 물에 잠겨 죽겠는데??!!!", "User", () => UpdatePlayLog("#3")));


        Debug.Log("장면 #5");
        //#5．채팅 화면: 그림자 도적단-사용자 간의 대화
        dialogTexts3.Add(new DialogData("(퍼즐을 맞추자 문이 열렸다.)", "None", () => Show_Images(2)));
        dialogTexts3.Add(new DialogData("문", "None", () => Show_Images(3)));
        dialogTexts3.Add(new DialogData("열림", "None"));
        Debug.Log("장면 #5-1");
        dialogTexts3.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "허억...허억...! 드디어 도착한 건가? 엇 저기 안에 뭔가 보인다!", "User"));
        dialogTexts3.Add(new DialogData("(동굴을 안쪽을 클릭해보자)", "None", () => Show_Images(0)));
        dialogTexts3.Add(new DialogData("동굴 클릭", "None", () => Show_Images(4)));
        Debug.Log("장면 #5-2");
        dialogTexts3.Add(new DialogData("/emote:None//sound:Effect/칠지도", "User"));
        Debug.Log("장면 #5001");
        dialogTexts3.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "칠지도다! 드디어 칠지도를 찾았어! ", "User"));
        Debug.Log("장면 #5002");
        dialogTexts3.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + "???" + "/color:black/\n/size:init/" + "훗, 용케도 함정을 뚫고 여기까지 왔군. 애송이인 줄 알았는데 제법이야.", "Thief"));
        Debug.Log("장면 #5003");
        dialogTexts3.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "너희들은 누구지? 너희들이 칠지도를 훔쳐 간 놈들이냐?", "User"));
        Debug.Log("장면 #5004");
        dialogTexts3.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + "???" + "/color:black/\n/size:init/" + "이런이런, 명색이 탐정인데 우리를 모른다니 섭섭한걸? ", "Thief"));
        Debug.Log("장면 #5005");
        Debug.Log("장면 #5-3");
        dialogTexts3.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(어디서 많이 본 것 같은데...누구지...? )", "User"));
        dialogTexts3.Add(new DialogData("/emote:Shock//sound:Surprise//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(헉 설마 범죄자 인명 파일에서 봤던 그림자 도적단...???!! 세계적인 고대 유물들을 약탈하는 것으로 유명한 비밀 지하 조직이잖아!)", "User"));
        Debug.Log("장면 #5-4");
        dialogTexts3.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(나도 소문으로만 들었지 실제로 마주쳐 본 적은 없는데...)", "User", () => DialogManager.Show(dialogTexts4)));



        Debug.Log("장면 #6");
        DialogData Text1 = new DialogData("그림자 도적단을 마주쳤다. 어떻게 행동할까?", "None", () => UpdatePlayLog("#5"));

        Text1.SelectList.Add("Wrong", "그림자 도적단이라니... \n내가 대적할 수 있을까? 일단 후퇴해야 하는 거 아니야? ");
        Text1.SelectList.Add("Correct", "쫄지 말자! 아직 내가 경험해본 \n놈들도 아니잖아! 이길 수 있어. ");

        Text1.Callback = () => Check1();
        dialogTexts4.Add(Text1);




        Debug.Log("장면 #7");
        dialogTexts5.Add(new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "설마 그 유명한 그림자 도적단?", "User"));
        dialogTexts5.Add(new DialogData("/sound:BadSmile//color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "으하하. /wait:0.5/ 역시 알아보는군.", "Thief"));
        dialogTexts5.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "당장 칠지도를 돌려줘. 백제의 귀중한 유물을 훔쳐가다니. 이 나쁜 놈들!", "User"));
        dialogTexts5.Add(new DialogData("/color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "그럴 순 없지. 이미 칠지도의 봉인은 다 풀었어.", "Thief"));
        dialogTexts5.Add(new DialogData("/color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "이제 칠지도는 우리 거다. 이걸로 역사를 바꾸고 세상의 주인이 될 수 있어.", "Thief"));
        dialogTexts5.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "뭐? 역사를 바꾸다니 절대 그렇게는 못 둬. ", "User"));
        dialogTexts5.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "기존의 역사를 바꾸는 것은 세상을 파괴하는 것이나 마찬가지라고! 소중한 고대 유적들을 잃을 순 없어!", "User"));
        dialogTexts5.Add(new DialogData("/color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "어차피 사람들이 기억도 못 하는 지나간 역사 따위가 뭐가 중요해. ", "Thief"));
        dialogTexts5.Add(new DialogData("/color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "이제부터 세상은 우리 그림자 도적단 차지다. 너도 살고 싶다면 우리에게 협력하는 게 좋을걸?", "Thief", () => DialogManager.Show(dialogTexts6)));


        //#5 선택 분기지점2
        Debug.Log("5");
        DialogData Text2 = new DialogData("/color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(어떡하지...? 그림자 도적단을 막아야 해!)", "None", () => UpdatePlayLog("#7"));

        Text2.SelectList.Add("Correct", "말이 통하는 놈들이 아니야. \n일단 싸워서 칠지도를 되찾자! ");
        Text2.SelectList.Add("Wrong", "급하게 싸우는 건 위험해. \n말로 차근차근 설득해보자. ");

        Text2.Callback = () => Check2();
        dialogTexts6.Add(Text2);

        //#10 채팅 화면: 그림자 도적단-사용자 간의 대화
        dialogTexts7.Add(new DialogData("/color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "으윽...이럴수가. 탐정 따위에게 당하다니. 분하지만 어쩔 수 없군.", "Thief"));
        dialogTexts7.Add(new DialogData("/color:#1F8A58//size:up/" + Thief + "/color:black/\n/size:init/" + "다음에는 이렇게 호락호락하게 끝나지 않을 거다!/sound:Run/", "Thief"));
        dialogTexts7.Add(new DialogData("(그림자 도적단이 도망쳤다.)", "None"));
        dialogTexts7.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "쳇, 별것도 아닌 놈들이었네.", "User"));
        dialogTexts7.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "그나저나 드디어 칠지도를 얻었어!", "User"));
        dialogTexts7.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "이걸 일곱 빛깔 칼날의 주인에게 전해줘야 할 텐데, 어떡하지?", "User", () => UpdatePlayLog("#10")));




        //#11．채팅 화면: 역사적 인물들-사용자 간의 대화
        dialogTexts8.Add(new DialogData("(환한 빛이 생겨나며 역사적 인물들이 나타난다.)", "None", () => Show_Images(5)));
        dialogTexts8.Add(new DialogData("빛", "None"));
        dialogTexts8.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "(아니, 모든 역사적 인물들이 한 번에...!) ", "User"));
        dialogTexts8.Add(new DialogData("/emote:KingHappy//color:#1F8A58//size:up/" + King + "/color:black/\n/size:init/" + "축하하네. 칠지도의 일곱 칼날의 힘을 얻어 악당들을 물리쳤군.", "Npc"));
        dialogTexts8.Add(new DialogData("/emote:Soseno//color:#1F8A58//size:up/" + Soseono + "/color:black/\n/size:init/" + "칠지도를 되찾아줘서 고맙구나. 네가 아니었으면 큰일날 뻔했어.", "Npc"));
        dialogTexts8.Add(new DialogData("/emote:Goheung//sound:Giggle//color:#1F8A58//size:up/" + Goheung + "/color:black/\n/size:init/" + "최고야 최고! 이왕 이렇게 된 거 내 수제자로 들어오는 것도 진지하게 고려해보라고~ 클클.", "Npc"));

        dialogTexts8.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "아니에요. 다 여러분들의 도움 덕분일걸요. 너무 감사해요. ", "User"));
        dialogTexts8.Add(new DialogData("/emote:Onjo//sound:OnjoHaHa//color:#1F8A58//size:up/" + Onjo + "/color:black/\n/size:init/" + "고럼고럼. 그건 맞지. 앞으로도 역사에 관심을 가지고 우리를 잊지 말라고? ", "Npc"));
        dialogTexts8.Add(new DialogData("/emote:GaroSad//sound:Sad//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "엉엉, 우리는 진짜 자네들에게 잊혀지는 줄 알았다고.", "Npc"));
        dialogTexts8.Add(new DialogData("/emote:GaroHappy//color:#1F8A58//size:up/" + Garo + "/color:black/\n/size:init/" + "우리를 잊지 않고 도와주는 후손들이 있다는 게 너무 감동이야. 엉엉.", "Npc"));

        dialogTexts8.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "당연하죠. 여러분 덕분에 저도 뜻깊은 경험을 할 수 있었어요. 앞으로도 역사를 기억하고 더 빛내는 후손이 될게요. ", "User"));
        dialogTexts8.Add(new DialogData("/emote:KingNormal//color:#1F8A58//size:up/" + King + "/color:black/\n/size:init/" + "고맙네. 자. 이제 집으로 돌아갈 시간이군. 앞으로 더 멋진 탐정이 되길 바라네! ", "Npc", () => UpdatePlayLog("#11")));



        //#12. 채팅 화면: 독백
        dialogTexts9.Add(new DialogData("/wait:0.5/(사건 해결 며칠 후, 뉴스)", "None"));
        dialogTexts9.Add(new DialogData("/sound:News//color:#1F8A58//size:up/" + Anchor + "/color:black/\n/size:init/" + "다음 소식입니다. 한동안 미궁으로 빠졌던 칠지도를 되찾았다는 소식입니다.", "Anchor"));
        dialogTexts9.Add(new DialogData("/color:#1F8A58//size:up/" + Anchor + "/color:black/\n/size:init/" + "FBI와 세계 최고 탐정들도 해결하지 못했던 사건을 초보 탐정 /color:#FF5B00/" + playerName + "/color:black/이 해결했다는 소식이 큰 화제를 모으고 있습니다...", "Anchor"));
        dialogTexts9.Add(new DialogData("/emote:Happy//sound:Smile//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "후훗, 사건도 해결하고 유명세도 타다니. 정말 최고야! ", "User"));
        dialogTexts9.Add(new DialogData("/emote:Happy//color:#FF5B00//size:up/" + playerName + "/color:black/\n/size:init/" + "이제 돈도 많이 벌 수 있다고. 다음에는 어떤 사건이 생겨날지 벌써 기대되는걸??", "User", () => End()));



        PlayLog = PlayerPrefs.GetString("EpiloguePlayLog");
        Debug.Log("현재 플레이 로그" + PlayLog);
        switch (PlayLog)
        {
            case "#0":
            case "End":
                for (int i = 0; i < Bgm.Length; i++)
                {
                    Bgm[i].Stop();
                }
                Bgm[0].Play();
                DialogManager.Show(dialogTexts1);
                break;
            case "#1":
                sc.EP_Arrow();
                break;
            case "#3":
                sc.EP_Puzzle();
                break;
            case "#5":
                if (!Bgm[1].isPlaying)
                    Bgm[1].Play();
                DialogManager.Show(dialogTexts4);
                break;
            case "#6":
                if (!Bgm[1].isPlaying)
                    Bgm[1].Play();
                DialogManager.Show(dialogTexts5);
                break;
            case "#7":
                if (!Bgm[1].isPlaying)
                    Bgm[1].Play();
                DialogManager.Show(dialogTexts6);
                break;
            case "#8":
                sc.EP_Battle();
                break;
            case "#10":
                if (!Bgm[2].isPlaying)
                {
                    if (Bgm[1].isPlaying)
                        Bgm[1].Stop();
                    Bgm[2].Play();
                }
                DialogManager.Show(dialogTexts8);
                break;
            case "#11":
                if (!Bgm[3].isPlaying)
                {
                    if (Bgm[2].isPlaying)
                        Bgm[2].Stop();
                    Bgm[3].Play();

                }
                bg1.SetActive(false);
                bg2.SetActive(true);
                DialogManager.Show(dialogTexts9);
                break;
            case "ArrowGameClear":
                if (!Bgm[1].isPlaying)
                    Bgm[1].Play();
                DialogManager.Show(dialogTexts2);
                break;
            case "PuzzleGameClear":
                if (!Bgm[1].isPlaying)
                    Bgm[1].Play();
                DialogManager.Show(dialogTexts3);
                break;
            case "BattleGameClear":
                if (!Bgm[1].isPlaying)
                    Bgm[1].Play();
                DialogManager.Show(dialogTexts7);
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
    }
    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("EpiloguePlayLog", PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);

        if (playlog.Equals("#3"))
        {
            sc.EP_Puzzle();
        }
        else if (playlog.Equals("#1"))
        {
            sc.EP_Arrow();
        }
        else if (playlog.Equals("#4"))
        {
            if (!Bgm[1].isPlaying)
                Bgm[1].Play();
            DialogManager.Show(dialogTexts4);
        }
        else if (playlog.Equals("#8"))
        {
            sc.EP_Battle();

        }
        else if (playlog.Equals("#10"))
        {
            if (!Bgm[2].isPlaying)
            {
                if (Bgm[1].isPlaying)
                    Bgm[1].Stop();
                Bgm[2].Play();
            }
            DialogManager.Show(dialogTexts8);
        }
        else if (playlog.Equals("#11"))
        {
            bg1.SetActive(false);
            bg2.SetActive(true);
            if (!Bgm[3].isPlaying)
            {
                if (Bgm[2].isPlaying)
                    Bgm[2].Stop();
                Bgm[3].Play();
            }
            DialogManager.Show(dialogTexts9);
        }


    }


    public void Check1()
    {

        Debug.Log("check1");
        if (DialogManager.Result == "Correct")
        {
            UpdatePlayLog("#6");
            DialogManager.Show(dialogTexts5);


        }
        else
        {
            Debug.Log("false");
            var resultFalse = new List<DialogData>();
            resultFalse.Add(new DialogData("그림자 도적단에 겁을 먹고 후퇴한 사이 도적단은 칠지도를 가지고 다시 도망갔다.", "None"));
            resultFalse.Add(new DialogData("결국 나는 칠지도를 되찾지 못했고 역사는 바뀌어버렸다.", "None"));
            resultFalse.Add(new DialogData("사람들은 백제라는 나라가 있다는 것조차 기억하지 못한다.", "None"));
            resultFalse.Add(new DialogData("오직 나만이 역사 인물들과의 연락 내용을 바탕으로 간간히 기억을 되새길 뿐이다.", "None"));
            resultFalse.Add(new DialogData("/speed:down/...", "none", null, false));
            resultFalse.Add(new DialogData("/speed:init/다시 선택해보자.", "none", () => DialogManager.Show(dialogTexts4)));
            DialogManager.Show(resultFalse);
        }
    }
    public void Check2()
    {

        Debug.Log("check2");
        if (DialogManager.Result == "Correct")
        {
            var resultTrue = new List<DialogData>();
            resultTrue.Add(new DialogData("/emote:Serious/너희들 맘대로 역사를 조종하게 절대 두진 않을 거야! ", "User", () => UpdatePlayLog("#8")));
            DialogManager.Show(resultTrue);


        }
        else
        {
            Debug.Log("false");
            var resultFalse = new List<DialogData>();
            resultFalse.Add(new DialogData("도적들과 이야기하며 그들을 설득해보려 했지만 도적들이 나를 속이고 몰래 칠지도를 동굴 밖으로 빼돌렸다.", "None"));
            resultFalse.Add(new DialogData("뒤늦게 이 사실을 알고 도적들을 쫓아가려 했지만 동굴이 무너졌고 /color:#FF5B00/" + playerName + "/color:black/은(는) 아직도 동굴에 갇혀 기약없이 구조대를 기다릴 뿐이다.", "None"));
            resultFalse.Add(new DialogData("오늘이... 동굴에 갇힌 지 10일째 되는 날인가...?? 아니 11일째...??", "None"));
            resultFalse.Add(new DialogData("점점 의식이 흐려져간다...", "None"));
            resultFalse.Add(new DialogData("/speed:down/...", "none", null, false));
            resultFalse.Add(new DialogData("/speed:init/다시 선택해보자.", "none", () => DialogManager.Show(dialogTexts6)));
            DialogManager.Show(resultFalse);
        }
    }


}



