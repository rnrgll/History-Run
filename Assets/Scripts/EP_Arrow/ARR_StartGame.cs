using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ARR_StartGame : MonoBehaviour
{
    public void StartBtn(){
        SceneManager.LoadScene("AvoidArrowGame");
    }
}
