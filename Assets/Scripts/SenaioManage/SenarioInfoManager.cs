using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class SenarioInfoManager : MonoBehaviour
{
    [Header("PopUpPanel")]
    public GameObject InfoPanel;
    [Header("Information Text")]
    [SerializeField]
    [TextArea] 
    string SenarioInformation;
    [SerializeField]
    string UnlockRewardTxt;
    [SerializeField]
    string ItemRewardTxt;
    [SerializeField]
    string PlaceNameTxt;
    [Header("Setting Options")]
    [SerializeField]
    bool hasUnlockReward;
    [SerializeField]
    bool hasItemReward;
    [SerializeField]
    bool hasPlace;
    
    [Header("Game Objects")]
    public TextMeshProUGUI SenarioTitle;
    public TextMeshProUGUI SenarioInfo;
    public GameObject RewardSection;
    public GameObject UnlockSlot;
    public GameObject ItemSlot;
    public GameObject PlaceSection;
    public TextMeshProUGUI PlaceTMP;

    static string SlotName;


    public void Click() {

        TitleSetting();
        InfoSetting();
        RewardSetting();
        PlaceSetting();
        InfoPanel.SetActive(true);
        PlayerPrefs.SetString("SelectSlot",this.gameObject.name);
    }

    void TitleSetting(){
        SenarioTitle.text = gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
    }
    void InfoSetting(){
        SenarioInfo.text = SenarioInformation;
        
    }
    void RewardSetting(){
        if(hasUnlockReward||hasItemReward){
            RewardSection.SetActive(true);
            if(hasUnlockReward){
            UnlockSlot.SetActive(true);
            UnlockSlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = UnlockRewardTxt;
            }
            else{
                UnlockSlot.SetActive(false);
            }

            if(hasItemReward){
                ItemSlot.SetActive(true);
                ItemSlot.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ItemRewardTxt;

            }
            else{
                ItemSlot.SetActive(false);
            }

        }
        else
            RewardSection.SetActive(false);

        
    }
    void PlaceSetting(){
        if(hasPlace){
            PlaceSection.SetActive(true);
            PlaceTMP.text = PlaceNameTxt;
        }
        else{
            PlaceSection.SetActive(false);
        }
    }


}
