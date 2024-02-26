using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class ARR_GameManager : MonoBehaviour
{
    private float GameTime = 11;
    //public float GameHp=100;

    public TextMeshProUGUI GameTimeText;
    // Update is called once per frame
    public ARR_HpControl hpControl;
    public ARR_ArrowGenerator arrowGenerator;
    public ARR_ArrowControl arrowControl;

    public GameObject PassPanel;
    public GameObject FailPanel;


    private AudioSource PassSound;
    private AudioSource FailSound;
    private BackgroundPlay2 backgroundPlay2;

    public bool isEnd;


    private void Awake()
    {
        backgroundPlay2 = GameObject.Find("EPGameBGMSystem").GetComponent<BackgroundPlay2>();
        PassSound = backgroundPlay2.transform.GetChild(1).GetComponent<AudioSource>();
        FailSound = backgroundPlay2.transform.GetChild(2).GetComponent<AudioSource>();

    }

    private void Start()
    {
        arrowGenerator.sound.mute = false;
        //arrowControl.attack.mute = false;
        PassPanel.SetActive(false);
        FailPanel.SetActive(false);
        isEnd = false;
        StartCoroutine(StartGameAfterDelay());



    }
    IEnumerator StartGameAfterDelay()
    {
        // 게임 시작 전 대기 시간
        Debug.Log("기다리기 시작");
        yield return new WaitForSeconds(0.55f);
        Debug.Log("기다리기끝");
        arrowGenerator.IsGameStarted = true; // 게임 시작 플래그를 활성화
    }

    public void Update()
    {
        if (arrowGenerator.IsGameStarted)
        {
            //hpControl = GetComponent<ARR_HpControl>(); // Get reference to ARR_HpControl script

            if ((int)GameTime == 0 || hpControl.GameHp <= 0)
            {

                isEnd = true;
                //backgroundPlay2.bgm.mute=true;
                GameTimeText.text = "게임 종료";
                arrowGenerator.sound.mute = true;
                //arrowControl.attack.mute = true;
                hpControl.attack.mute = true;
                if (hpControl.GameHp > 0)
                {
                    PlayerPrefs.SetString("EpiloguePlayLog", "ArrowGameClear");
                    Debug.Log("게임 성공");
                    GameTimeText.text = "게임 성공";


                    if (!PassPanel.activeSelf)
                    {
                        PassSound.Play();
                        PassPanel.SetActive(true);
                    }

                }
                else
                {
                    if (!FailPanel.activeSelf)
                    {
                        FailSound.Play();
                        FailPanel.SetActive(true);
                    }
                    Debug.Log("게임 종료");
                    GameTimeText.text = "게임 종료";


                }

            }
            else
            {
                GameTime -= Time.deltaTime;
                Debug.Log((int)GameTime);
                GameTimeText.text = "Time: " + (int)GameTime;
            }
        }
        else
        {
            Debug.Log("게임 시작 전");
        }


    }

    public void ReStart()
    {
        Time.timeScale = 1;
    }


}
