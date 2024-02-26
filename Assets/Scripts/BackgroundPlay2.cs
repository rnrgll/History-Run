
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundPlay2 : MonoBehaviour
{
    public AudioSource bgm;
    private static BackgroundPlay2 instance;

    private void Awake()
    {
        // var soundManagers = FindObjectsOfType<BackgroundPlay2>();
        // if (soundManagers.Length == 1)
        // {
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start()
    {
        if (!bgm.isPlaying)
            bgm.Play();
        else
            bgm.Stop();

    }
    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (!(scene.name.Equals("BattleGame") || scene.name.Equals("EP_Battle") || scene.name.Equals("EP_Arrow") || scene.name.Equals("AvoidArrowGame")))
            Destroy(gameObject);
    }

}
