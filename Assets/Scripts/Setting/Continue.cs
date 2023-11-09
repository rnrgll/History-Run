using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public SceneChange sc;
    public GameObject ResetPanel;
    public GameObject continueBtn;

    private void Awake() {
        if(!HasAccount())
            continueBtn.GetComponent<Button>().interactable = false;
        else
            continueBtn.GetComponent<Button>().interactable = true;

    }




    public bool HasAccount()
    {
        if(PlayerPrefs.HasKey("SignUp"))
            return true;
        else
            return false;
            
    }

    public void ClickToContinue(){
        if(HasAccount())
            sc.ChangeToMainScene();
        else
            return;

    }

    public void ClickToStart(){
        if(HasAccount())
            ResetPanel.SetActive(true);
        else
            sc.SignUp();
            
    }


}
