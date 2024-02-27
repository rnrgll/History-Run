using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClearBtnEvent : MonoBehaviour
{
    public AudioSource buttonClickSound; // 버튼 클릭 소리를 재생할 AudioSource
    private Button btn;
    public string sceneName;

    private void Start()
    {
        // 버튼에 OnClick 이벤트 추가
        btn = GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(ButtonClickEventHandler);

    }

    private void ButtonClickEventHandler()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.PlayOneShot(buttonClickSound.clip);
        }
        else
        {
            Debug.Log("buttonClickSound is null");
        }

        Invoke("DelayedSceneChange", 0.4f);
    }

    private void DelayedSceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }


}
