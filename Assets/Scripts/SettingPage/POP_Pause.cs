
using UnityEngine;

public class POP_Pause : MonoBehaviour
{
    public Canvas gameCanvas;
    public GameObject playObject;
    
     public void PauseGame()
    {
        Time.timeScale = 0;
        playObject.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        playObject.SetActive(true);
    }
}
