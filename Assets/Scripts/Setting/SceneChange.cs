using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeToMainScene(){
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ChangeToStartScene(){
        SceneManager.LoadScene("StartScene");
    }
    public void ChangeToAccountScene(){
        SceneManager.LoadScene("AccountScene");
    }

    public void ChangeToCollectionScene(){
        SceneManager.LoadScene("CollectionViewScene");
    }

    public void ChangeToMission1(){
        SceneManager.LoadScene("Mission1Scene");
    }

    public void SenarioStart()
    {
        string SlotName = PlayerPrefs.GetString("SelectSlot");
        switch(SlotName){
            case "P1":
                //if(PlayerPrefs.GetString("Prologue1PlayLog").Equals("End"))

                Prologue1();
                break;
            case "P2":
                Prologue2();
                break;
            case "Q1":
                Quest1();
                break;
            case "Q2":
                Quest2();
                break;
            case "Q3":
                Quest3();
                break;
            case "Q4":
                Quest4();
                break;
            case "Q5":
                Quest5();
                break;
            case "Q6":
                Quest6();
                break;
            case "Q7":
                Quest7();
                break;
            case "E":
                Epilogue();
                break;
        }
    }
    public void Prologue1()
    {
        SceneManager.LoadScene("Prologue1");
    }
    public void Prologue2()
    {
        SceneManager.LoadScene("Prologue2");
    }
    public void Quest1()
    {
        SceneManager.LoadScene("Quest1");
    }
    public void Quest2()
    {
        SceneManager.LoadScene("Quest2");
    }
    public void Quest3()
    {
        SceneManager.LoadScene("Quest3");
    }
    public void Quest4()
    {
        SceneManager.LoadScene("Quest4");
    }
    public void Quest5()
    {
        SceneManager.LoadScene("Quest5");
    }
    public void Quest6()
    {
        SceneManager.LoadScene("Quest6");
    }
    public void Quest7()
    {
        SceneManager.LoadScene("Quest7");
    }
    public void Epilogue()
    {
        SceneManager.LoadScene("Epilogue");
    }
    public void SenarioHome()
    {
        SceneManager.LoadScene("SenarioHome");
    }
    public void SignUp(){
        SceneManager.LoadScene("SignUp");
    }
    public void StoryHome(){
        SceneManager.LoadScene("StoryHome");
    }



    //퀘스트, 미니게임으로 씬 전환 함수
    public void P2_OX()
    {
        SceneManager.LoadScene("P2_OX");
    }
    public void Q1_Card(){
        SceneManager.LoadScene("Q1_Card");
    }
    public void Q2_Castle(){
        SceneManager.LoadScene("Q2_Castle");
    }
    public void Q3_AB(){
        SceneManager.LoadScene("Q3_AB");
    }
    public void Q4_AB(){
        SceneManager.LoadScene("Q4_AB");
    }
    public void Q5_Input(){
        SceneManager.LoadScene("Q5_Input");
    }
    public void Q6_Affection(){
        SceneManager.LoadScene("Q6_Affection");
    }
    public void Q7_Input(){
        SceneManager.LoadScene("Q7_Input");
    }
    public void EP_Arrow(){
        SceneManager.LoadScene("EP_Arrow");
    }
    public void EP_Puzzle(){
        SceneManager.LoadScene("EP_Puzzle");
    }
    public void EP_Battle(){
        SceneManager.LoadScene("EP_Battle");
    }
    public void AvoidArrorGame(){
        SceneManager.LoadScene("AvoidArrowGame");
    }

    public void BattleGame(){
        SceneManager.LoadScene("BattleGame");
    }

}
