using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PUZ_BackButton : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("PuzzleGameScene");
    }
}
