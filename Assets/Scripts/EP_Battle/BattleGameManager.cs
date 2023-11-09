using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGameManager : MonoBehaviour
{
    public Boss boss;
    public PlayerMoveButton player;
    public GameObject FailPanel;
    public GameObject PassPanel;

    public AudioSource pass;
    public AudioSource fail;


    public BackgroundPlay2 bg;

    private void Start() {
        PassPanel.SetActive(false);
        FailPanel.SetActive(false);
        
    }
    private void Update() {
        if(boss.isDead)
        {
            //bg.bgm.mute=true;
            PlayerPrefs.SetString("EpiloguePlayLog", "BattleGameClear");
            PlayerPrefs.SetInt("칠지도", 1);
            if(!PassPanel.activeSelf){
                 PassPanel.SetActive(true);
                pass.Play();

            }

        }
        else if(player.isDead){
            bg.bgm.mute=true;
            if(!FailPanel.activeSelf){
                FailPanel.SetActive(true);
                fail.Play();

            }
        }
            
    }
}
