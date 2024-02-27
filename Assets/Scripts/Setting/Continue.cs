using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Continue : MonoBehaviour
{
    public SceneChange sc;
    public GameObject ResetPanel;
    public GameObject continueBtn;
    public AudioSource clicksound;

    private void Awake()
    {
        if (!HasAccount())
            continueBtn.GetComponent<Button>().interactable = false;
        else
            continueBtn.GetComponent<Button>().interactable = true;

    }




    public bool HasAccount()
    {
        if (PlayerPrefs.HasKey("SignUp"))
            return true;
        else
            return false;

    }

    public void ClickToContinue()
    {
        clicksound.Play();
        if (HasAccount())
            Invoke("ChangeToManinScene", 0.5f);
        else
            return;

    }

    public void ClickToStart()
    {
        clicksound.Play();
        if (HasAccount())
            ResetPanel.SetActive(true);
        else
            Invoke("ChangeToSignUp", 0.5f);

    }

    void ChangeToSignUp()
    {
        sc.SignUp();
    }

    void ChangeToManinScene()
    {
        sc.ChangeToMainScene();
    }


}
