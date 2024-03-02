using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EP_BattleBGMControl : MonoBehaviour
{
    private BackgroundPlay2 backgroundPlay2;
    // Start is called before the first frame update
    void Start()
    {
        backgroundPlay2 = GameObject.Find("EPGameBGMSystem").GetComponent<BackgroundPlay2>();
        if (backgroundPlay2.bgm.mute == true)
        {
            Debug.Log("mute 해제");
            backgroundPlay2.bgm.mute = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
