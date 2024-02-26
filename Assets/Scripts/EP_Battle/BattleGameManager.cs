using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameManager : MonoBehaviour
{
    public Boss boss;
    public PlayerMoveButton player;
    public GameObject FailPanel;
    public GameObject PassPanel;

    private AudioSource pass;
    private AudioSource fail;


    private BackgroundPlay2 bg;
    private BattleBgmControl bgmControl;

    private void Awake()
    {
        bg = GameObject.Find("EPGameBGMSystem").GetComponent<BackgroundPlay2>();
        bgmControl = GameObject.Find("EPGameBGMSystem").GetComponent<BattleBgmControl>();
        pass = bg.transform.GetChild(1).GetComponent<AudioSource>();
        fail = bg.transform.GetChild(2).GetComponent<AudioSource>();

    }

    private void Start()
    {
        PassPanel.SetActive(false);
        FailPanel.SetActive(false);

    }
    private void Update()
    {
        if (boss.isDead)
        {
            //bg.bgm.mute=true;
            PlayerPrefs.SetString("EpiloguePlayLog", "BattleGameClear");
            PlayerPrefs.SetInt("칠지도", 1);
            if (!PassPanel.activeSelf)
            {
                PassPanel.SetActive(true);
                pass.Play();

            }

        }
        else if (player.isDead)
        {
            bg.bgm.mute = true;
            bgmControl.StopLowEnergyBgm();
            if (!FailPanel.activeSelf)
            {
                FailPanel.SetActive(true);
                fail.Play();

            }
        }

    }
}
