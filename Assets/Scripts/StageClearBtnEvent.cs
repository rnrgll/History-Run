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
        btn.onClick.AddListener(() =>
        {
            ChangeScene(sceneName);
        });

    }

    // 씬 전환 함수
    public void ChangeScene(string sceneName)
    {
        // 버튼 클릭 소리 재생
        if (buttonClickSound != null)
        {
            buttonClickSound.PlayOneShot(buttonClickSound.clip);
        }
        else
        {
            Debug.Log("buttonClickSound is null");
        }

        // 메인 씬으로 전환
        SceneManager.LoadScene(sceneName);
    }

}
