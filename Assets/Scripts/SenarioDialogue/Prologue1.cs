using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.UI;

public class Prologue1 : MonoBehaviour
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
    public string unknown;
    

    [Header("PlayLog")]

    public string PlayLog;


    List<DialogData> dialogTexts = new List<DialogData>(); //#1
    List<DialogData> dialogTexts2 = new List<DialogData>(); //#2

    List<DialogData> dialogTexts3 = new List<DialogData>();//#3 선택분기점1
    List<DialogData> dialogTexts4 = new List<DialogData>(); //#4
    List<DialogData> dialogTexts4_2 = new List<DialogData>(); //#4-8

    List<DialogData> dialogTexts5 = new List<DialogData>(); //#5
    List<DialogData> dialogTexts6 = new List<DialogData>(); //#6


    int falseCount = 0; //오답 선택지 카운터

    void Init(){
        PlayLog = "#0";
        PlayerPrefs.SetString("Prologue1PlayLog",PlayLog);
    }

    private void Awake()
    {   
        if(!PlayerPrefs.HasKey("Prologue1PlayLog"))
            Init();

        
        Debug.Log("이미지&클리어 Panel 비활성화");
        ClearPanel.SetActive(false);
        ImgPanel.SetActive(false);
        Debug.Log("사용자 이름 가져오기, 변수 초기화");
        PlayerPrefs.SetString("Unknown", "알 수 없음");
        PlayerPrefs.SetString("근초고왕", "일곱 빛깔 칼날의 주인");

        playerName = PlayerPrefs.GetString("PlayerName", "플레이어"); //default "플레이어"
        unknown = PlayerPrefs.GetString("Unknown");
        King_Geunchogo = PlayerPrefs.GetString("근초고왕");


        //#1. 채팅 화면: 독백
        //짙은 주황색 : FF5B00
        //짙은 초록색 : 1F8A58

        Debug.Log("1");
        dialogTexts.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"흐암...따분해. 오늘도 일이 없네. 빚까지 내가면서 개업한 사무소인데 이러다간 제대로 시작도 못하고 문닫게 생겼잖아? ", "User"));
        dialogTexts.Add(new DialogData("/sound:Hungry//color:blue/(이때 배에서 꼬르륵, 소리가 난다.)","None"));

        dialogTexts.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아니, 벌써 점심먹을 시간이네.\n/emote:Think/근데 돈이 어딨더라...?", "User", ()=>Show_Images(0)));



        dialogTexts.Add(new DialogData("지갑","",()=>Show_Images(1)));
        //dialogTexts.Add(new DialogData("","",);
        dialogTexts.Add(new DialogData("지갑오픈"));

        dialogTexts.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/" +"엥? 2000원?? 이거 실화야...? 나 진짜 탐정 일 하기도 전에 굶어 죽는거 아닐까....", "User"));

        dialogTexts.Add(new DialogData("/sound:Phone//color:blue/(갑작스레 울리는 문자 알람 소리)","None"));
        dialogTexts.Add(new DialogData("/color:black/ (‘알 수 없음’이 당신과 채팅하기를 신청하셨습니다.)","None",()=>Show_Images(2)));
        dialogTexts.Add(new DialogData("문자","",()=>DialogManager.Show(dialogTexts2)));
        

         Debug.Log("2");
        //#2. 채팅 화면: 일곱 빛깔 칼날의 주인(근초고왕)-사용자 간의 대화
        dialogTexts2.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"+"다짜고짜 연락하네 미안하군. 이렇게 자네를 만나게 되어 반갑기 그지없네.","King_Geunchogo",()=>UpdatePlayLog("#1")));
        dialogTexts2.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"+"초면에 미안하지만 한시가 급한 상황이라 자네가 내 부탁을 좀 들어줘야 겠어.","King_Geunchogo"));
        dialogTexts2.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(뭐야 이사람? 다짜고짜 연락해서 부탁을 들어달라고...? 혹시 보이스피싱 그런거 아니야?)","User",() => DialogManager.Show(dialogTexts3)));
    


         Debug.Log("3");
        //#3 선택 분기지점1
        DialogData Text1 = new DialogData("어떻게 행동할까?","None");
        Debug.Log("3-1");
        Text1.SelectList.Add("Wrong", "쓸데없이 시간 낭비하지 말자! \n연락을 차단한다.");
        Text1.SelectList.Add("Correct", "무슨 사정이 있을 수도 있겠지! \n연락을 계속한다.");
        Debug.Log("3 -2");
        Text1.Callback = () => Check1();
        Debug.Log("3 add 전");
        dialogTexts3.Add(Text1);


        //#4
        Debug.Log("4");
        dialogTexts4.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"+"아차차, 맘이 급해서 내소개를 깜빡했군. 미안하네.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Black//color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"+"우리끼리는 일곱 빛깔 칼날의 주인이라고 부르지만 이러면 잘 모를 테니깐...","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Embrass//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그래, /color:#1F8A58/근초고왕/color:black/이라고 말하면 알겠나?","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"잠깐, 근초고왕이라고요? 백제의 중흥을 이끈 그 왕?","User"));
        dialogTexts4.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"근데 우리는 또 누군가요? /emote:Think/혹시 장난전화 하시는 거라면 신고할 수 있어요 ㅡ,ㅡ","User"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그래 궁금한게 많겠지. 믿기 쉽지 않을 것이라는 것도 알아. 내가 다 설명해 줌세.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"우선 자네는 탐정이니까 최근에 벌어진 /color:red/칠지도 도난 사건/color:black/에 대해 알고 있겠지?","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네 알고 있어요. 얼마 전에 신문에서 봤어요. /speed:down//emote:Think/음.../wait:0.3//speed:init/그 신문을 어디에 뒀더라...","User",()=>Show_Images(3)));
        dialogTexts4.Add(new DialogData("신문",""));

         Debug.Log("4-1");
        dialogTexts4.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"이소노카미 신궁에 보관된 칠지도가 사라져서 최근 난리잖아요.","User"));
        dialogTexts4.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"세계 최고의 탐정들과 수사기관에서 조사했는데도 아직까지 증거도 찾지 못해서 해결하는데 어려움을 겪고 있다고 들었는데...","User"));
        dialogTexts4.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아니, 그런데 칠지도라면 근초고왕님이 만드신 보검 아닌가요?","User"));

        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"맞아, 사실 그 사건 때문에 연락했다네.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아니 근데 잠시만요... 지금 너무 이해가 안가요. 어떻게 저에게 연락을 할 수 있었던 거죠?","User"));
        dialogTexts4.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"진짜 근초고왕님이라면... 이미 역사 속 인물이잖아요!","User"));

        Debug.Log("4-2");
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그래, 자네 말이 맞아. 나는 자네들이 기억해주는 역사 속 인물이지.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"물론 내 육신은 이미 떠나갔지만 많은 사람들이 기억해주고 믿어주는 한 내 영혼의 숨결이 살아 숨쉴 수 있어.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"다른 역사속 인물들도 마찬가지고.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그리고 우리는 /color:#1F8A58/코드 네임/color:black/을 통해서 활동하고 있지.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"지금 자네와 연락하는 화면에 보이는 것처럼 내 코드 네임은 /color:#1F8A58/‘일곱 빛깔 칼날의 주인’/color:black/이야.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"자네가 생각하는 대로 내 보검에서 따온 이름이지.","King_Geunchogo"));
       
        Debug.Log("4-3");
        dialogTexts4.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"음...어렵네요. 그럼 귀신이라는 말씀이세요?","User"));

        dialogTexts4.Add(new DialogData("/emote:Unhappy//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"/speed:down/뭐.../speed:init/잡신 취급은 조금 맘에 안들지만 지금은 그게 중요한게 아니니깐 일단 그렇다고 해 두겠네.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"지금은 현실 세계로 잠깐 빙의해서 자네와 연락을 하고 있는 상태야.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"원래 우리들은 현실에 개입해서는 안되지만.... 지금은 상황이 좀 급해서.","King_Geunchogo"));

        dialogTexts4.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아까부터 급한 상황이라고 하셨는데 그 도난 사건과 근초고왕님이 어떤 관련이 있으신 건가요? ","User"));


        Debug.Log("4-4");
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"사실 칠지도에는 백제 모든 위인들의 힘과 역사의 힘이 깃들어 있다네. 칠지도가 백제의 전부라고 해도 과언이 아니야.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Sigh//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"뭐, 원래부터 칠지도에 우리 힘을 모으려고 했던 건 아니지만.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Sigh//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그런데 자네도 알다시피...요즘 역사에 대한 사람들의 관심이 예전같지 않아.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Sigh//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"사람들이 우리를 기억해주지 않는다면 우리도 존재할 수 없다네. 이미 여러 위인들이 사라지거나 사라질뻔 했어.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"/color:#1F8A58/망국의 수호자/color:black/(흑치상지, 나당 연합군으로 인해 백제가 멸망한 이후 백제부흥운동을 이끈 장수)까지 사라질 뻔 한 일을 겪고 나서","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"우리는 임시적으로나마 더 강력한 힘을 발동시키기 위해서 서로의 힘을 한군데에 모았네.","King_Geunchogo"));
        
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그 대상으로 대(大)백제국의 위상을 잘 나타낼 수 있는 칠지도가 선택된거고. ","King_Geunchogo"));


        Debug.Log("4-5");
        dialogTexts4.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"그렇군요... 이해는 되지만 그럼 지금처럼 칠지도가 사라진 위험한 상황에서는 아무것도 할 수 없는 것 아니에요?","User"));
        dialogTexts4.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"아무리 그래도 한곳에 힘을 모으는 것은 너무 무모한 선택이었어요! ","User"));

        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"크흠, 솔직히 말하자면... 이유가 꼭 그것만은 아니긴 해","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"사실 모든 역사적 위인들이 사이가 좋지 않거든. 우리끼리만 해도 삼국 간의 위인들은 그다지 사이가 좋지 않으니깐... ","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"지난번에는 /color:#1F8A58/통수의 달인/color:black/(신라 진흥왕, 백제와 연합하여 한강 유역을 나누어 수복했지만 백제를 급습하여 다시 한강 유역을 모두 차지했다)과","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"/color:#1F8A58/칠전팔기 야심가/color:black/(성왕, 백제 수도 천도 후 백제 중흥을 위해 지속적으로 노력했지만 진흥왕과의 전투에서 피살당하고 한강 유역을 빼앗김)가 만났다가 또 싸움이 날뻔한 것만 생각해도... 어휴...말도말게.","King_Geunchogo"));

        
        Debug.Log("4-6");
        dialogTexts4.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(뭐야 결국 자신들 자존심 싸움 때문에 그랬다는 거잖아. 삼국 통일을 위해 치열하게 경쟁한 나라의 위인을 답네...)","User"));

        dialogTexts4.Add(new DialogData("/emote:Restless//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"아, 암튼 중요한건 그게 아닐세.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Restless//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"칠지도에는 아무나 그 힘을 사용할 수 없도록 봉인이 걸려 있는데 그 힘에 대한 봉인을 풀게 된다면 현실 세계에서 힘이 사용될 수 있는 강력한 무기가 돼.","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Restless//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그 무기로 사람들의 정신을 지배해 역사를 조작할 수도 있다고. ","King_Geunchogo"));
        dialogTexts4.Add(new DialogData("/emote:Restless//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"문제는 칠지도를 가져간 무리들이 그 사실을 알고 있는 것 같아. 우리쪽 위인들이 봉인이 풀리고 있다는 것을 감지했거든.","King_Geunchogo"));

        dialogTexts4.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(이분 은근히 말돌리시네...암튼...중요한건 칠지도를 찾는 거니깐!)","User"));

        Debug.Log("4-7");
        dialogTexts4.Add(new DialogData("/emote:Shock//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"그럼 정말 큰일이네요. 당장 칠지도를 찾아야하겠는데요??","User"));
        dialogTexts4.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"그런데 최고 탐정들을 두고 왜 초짜인 저를 찾아온거죠?","User"));

        dialogTexts4.Add(new DialogData("/emote:Embrass//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"/speed:down/사실.../speed:init/솔직히 말하자면 이미 그들에게도 모두 찾아가 봤지만 이상한 사람이라고 생각했는지 바로 차단당했다네. 허허.","King_Geunchogo"));

        dialogTexts4.Add(new DialogData("/emote:What//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(나같아도 보이스피싱이라고 생각했는데 그사람들이라고 아닐수가....)","User"));
        dialogTexts4.Add(new DialogData("/emote:What//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"/speed:down/(잠깐.. /speed:init/그럼 내가 그냥 마지막에 얻어 걸렸다는 소리잖아? ) ","User",()=>DialogManager.Show(dialogTexts4_2)));



        Debug.Log("4-8");
        dialogTexts4_2.Add(new DialogData("/emote:Unhappy//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"자네...^^ 무슨 생각 하는지 다 보이네....^^ ","King_Geunchogo",()=>UpdatePlayLog("#4")));
        dialogTexts4_2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(어우 뭐야;;; 관심법도 있는거야...? 쉽지 않네...)","User"));
        dialogTexts4_2.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"물론 좀 서운할 수는 있겠지만 그래도 난 자네의 능력을 믿어. 앞으로의 모든 일은 자네에게 전적으로 달려 있다고.","King_Geunchogo"));
        dialogTexts4_2.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네? 잠시만요! 저는 아직 수락한 적이 없는걸요?? 저에게도 생각할 시간을 좀 주셔야죠!","User"));
        dialogTexts4_2.Add(new DialogData("/emote:Unhappy//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"이런이런, 자네 내 말을 뭘 들은건가? 한시가 급한 일이야. 시간이 없다고.","King_Geunchogo"));
        dialogTexts4_2.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그리고 자네... 어차피 사무소 잘 안되서 파리만 날리지 않나? 내 말이 틀린 겐가..? ","King_Geunchogo",()=>DialogManager.Show(dialogTexts5)));

        //#5 선택 분기지점2
        Debug.Log("5");
        DialogData Text2 = new DialogData("/sound:Hum//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(끙... 팩폭도 잘하시네.. 이를 어쩐다?)","None");

        Text2.SelectList.Add("Wrong","세계 탐정들도 모두 해결하지 못한 문제를 내가 어떻게..?\n정중하게 거절하자.");
        Text2.SelectList.Add("Correct", "이건 유명한 탐정으로 \n거듭날 수 있는 기회야! \n일단 수락해야지");

        Text2.Callback = () => Check2();
        dialogTexts5.Add(Text2);



        //#6

        dialogTexts6.Add(new DialogData("/emote:Think//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"알겠어요. 그럼 저는 뭐부터 하면 되는거죠? 저는 지금 칠지도에 대해 아는 것이 하나도 없는걸요...?","User"));


        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"잘 생각했네. 자네가 칠지도를 되찾기 위해서는 칠지도 일곱 칼날의 힘을 얻어야 해. 그래야 칠지도를 훔쳐 간 도적들과 대결을 할 수 있어.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"칠지도의 힘은 /color:red/백제와 관련된 유적지와 거점 지하철역/color:black/을 돌아다니며 얻을 수 있다네. 그러나 아마 혼자서는 힘들게야.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그래서 내가 각 유적지를 수호하는 역사적 인물들에게 이미 연락을 돌려놨네.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"자네가 방문하는 장소마다 그들이 자네에게 도움을 줄 거야.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그러니 너무 걱정하지 말게. 곧 그들이 자네에게 연락을 할테니 핸드폰을 잘 확인하는게 좋겠네.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"유적지와 지하철역에서 백제와 관련한 다양한 퀘스트를 진행하게 되는데 이때 성공한다면 /color:red/칠지도 칼날의 힘/color:black/과 /color:red/승차권/color:black/을 얻을 수 있어. ","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"이 승차권들은 자네가 퀘스트를 해결하기 어려울 때 필요한 힌트를 구매하는데 요긴하게 사용할 수 있으니 획득해두면 좋겠지?","King_Geunchogo"));


        dialogTexts6.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"으아...복잡하네요... 그런데 저는 백제에 대해 아는 것도 별로 없는데 괜찮을까요...?","User"));
        dialogTexts6.Add(new DialogData("/emote:Embrass//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"도움을 받을 수는 있다고 하지만... 너무 걱정돼요!","User"));

        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"그럴 줄 알고 내가 다 생각을 해뒀지.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"본격적인 퀘스트를 시작하기 전에 자네가 백제에 대해 좀 더 잘 알 수 있도록 내가 친히 가이드를 해줌세.","King_Geunchogo"));
        dialogTexts6.Add(new DialogData("/color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"자, 그럼 시작해볼까?","King_Geunchogo"));


        dialogTexts6.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"(휴, 진짜 시작이라니, 걱정된다 정말. 어쩔 수 없지...뭐 일단 가보자고!)","User"));
        dialogTexts6.Add(new DialogData("/emote:Serious//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"네 좋아요!!","User",()=>End()));






        PlayLog = PlayerPrefs.GetString("Prologue1PlayLog");
        Debug.Log("현재 플레이 로그 : " + PlayLog);
        //PlayLog = "#0";
        switch(PlayLog){
            case "#0":
            case "End":
                DialogManager.Show(dialogTexts);
                break;
            case "#1":
                DialogManager.Show(dialogTexts2);
                break;
            case "#2":
                DialogManager.Show(dialogTexts3);
                break;
            case "#4":
                DialogManager.Show(dialogTexts4_2);
                break;
            case "#3":
                DialogManager.Show(dialogTexts4);
                break;
            case "#5":
                DialogManager.Show(dialogTexts6);
                break;
        }

        
    }
    

    private void Show_Images(int index)
    {
         Debug.Log("show_images");
        //Printer.GetComponent<Button>().interactable = false;
        ImgPanel.SetActive(true);
        Popups[index].SetActive(true);
    }

    public void Check1()
    {

        Debug.Log("check1");
        if(DialogManager.Result == "Correct")
        {
            Debug.Log("True");
            var resultTrue = new List<DialogData>();
            resultTrue.Add(new DialogData("/emote:Normal//color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"부탁이라뇨...? 혹시 뭘 말씀하시는 걸까요...?","User"));
            resultTrue.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"그리고 우선 의뢰인 분이 누구신지 말씀해 주셔야 도움을 드릴 수 있을 것 같아요!","User",()=>DialogManager.Show(dialogTexts4)));

            UpdatePlayLog("#3");
            DialogManager.Show(resultTrue);


        }
        else
        {
            Debug.Log("false");
            var resultFalse = new List<DialogData>();
            resultFalse.Add(new DialogData("이후에도 /color:#FF5B00/" + playerName +"/color:black/의 탐정 사무소에는 일이 쭉 없었다.","None"));
            resultFalse.Add(new DialogData("결국 많은 빚을 지고 사무소를 폐업한 /color:#FF5B00/" + playerName +"/color:black/는 다시 아르바이트에 전전하며 빚을 갚는데 인생을 보내게 된다.... ","None"));
            resultFalse.Add(new DialogData("/speed:down/...","none",null,false));
            resultFalse.Add(new DialogData("/speed:init/다시 한 번 선택해보자.","None",()=>DialogManager.Show(dialogTexts3),false));
            DialogManager.Show(resultFalse);
        }
    }


    public void Check2()
    {
        
        Debug.Log("check2");

        if(DialogManager.Result == "Correct")
        {
            UpdatePlayLog("#5");
            Debug.Log("True");
            DialogManager.Show(dialogTexts6);


        }
        else
        {
            Debug.Log("false");
            falseCount++;
            Debug.Log("false++");
            var resultFalse = new List<DialogData>();
            resultFalse.Add(new DialogData("/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"+"말씀은 감사하지만 저는 아직 많이 부족해요. 다른 사람을 찾으시는 건 어떨까요?","User"));
            if(falseCount==1)
            {

                resultFalse.Add(new DialogData("/emote:Unhappy//color:#1F8A58//size:up/" + King_Geunchogo +"/color:black/\n/size:init/"+"정말 그게 자네 선택인가? 다시한 번 생각해볼 기회를 주겠네.","King_Geunchogo",()=>DialogManager.Show(dialogTexts5),false));

            }
            else{
                resultFalse.Add(new DialogData("사건이 있고 얼마 후/speed:down/... /speed:init/결국 칠지도를 빼앗아간 무리들은 힘을 발동시켜 역사를 뒤바꿔버렸다.","None"));
                resultFalse.Add(new DialogData("사람들은 백제라는 나라가 있다는 것조차 기억 하지 못한다.","None"));
                resultFalse.Add(new DialogData("오직 /color:#FF5B00/" + playerName +"/color:black/만이 근초고왕과의 연락 내용을 바탕으로 간간히 기억을 되새길 뿐이다.","None"));
                resultFalse.Add(new DialogData("/speed:down/...","none",null,false));
                resultFalse.Add(new DialogData("/speed:init/다시 한 번 선택해보자.","None",()=>DialogManager.Show(dialogTexts5),false));
            }
            DialogManager.Show(resultFalse);
        }
    }
    public void End(){
        //PlayLog
        UpdatePlayLog("End");

        
        DialogAsset.SetActive(false);
        ClearPanel.SetActive(true);

        PlayerPrefs.SetInt("UnlockP2",1);
        Debug.Log("unlockP2");
    }



    public void UpdatePlayLog(string playlog)
    {
        PlayLog = playlog;
        PlayerPrefs.SetString("Prologue1PlayLog",PlayLog);
        Debug.Log("UpdatePlyaerLog : " + playlog);
    }


}
//dialogTexts.Add(new DialogData());

/*
/color:#FF5B00/" + playerName +"/color:black/
"/color:#FF5B00//size:up/" + playerName +"/color:black/\n/size:init/"
"/color:#1F8A58//size:up/" + unknown +"/color:black/\n/size:init/"
"/color:blue/ (꼬르륵)","None"

*/


