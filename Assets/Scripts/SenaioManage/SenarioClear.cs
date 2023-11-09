using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SenarioClear : MonoBehaviour
{

    public string nextSenario;
    public TextMeshProUGUI Reward;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("nextSernario : "+ nextSenario );
        Debug.Log("다음 시나리오 이름 : " + PlayerPrefs.GetString(nextSenario));
        if(!nextSenario.Equals("None"))
            Reward.text = PlayerPrefs.GetString(nextSenario) + " 해제";
        else
            Reward.text = "<칠지도의 비밀>을 모두 클리어했습니다";
        
    }
}
