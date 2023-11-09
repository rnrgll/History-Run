
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundPlay1 : MonoBehaviour
{
    public AudioSource bgm;

    private void Awake() {
        var soundManagers = FindObjectsOfType<BackgroundPlay1>();
        if(soundManagers.Length==1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    private void Start() {
        if(!bgm.isPlaying)
            bgm.Play();
        else
            bgm.Stop();

    }
    private void Update() {
        Scene scene = SceneManager.GetActiveScene(); 
        if(!(scene.name.Equals("AccountScene")||(scene.name.Equals("CollectionViewScene")||(scene.name.Equals("MainMenuScene"))||(scene.name.Equals("Mission1Scene")))))
            Destroy(gameObject);
    }

}
