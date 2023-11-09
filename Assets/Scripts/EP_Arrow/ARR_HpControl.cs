using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ARR_HpControl : MonoBehaviour
{
    GameObject hpImage;
    // Start is called before the first frame update
    public float GameHp=100;
    public AudioSource attack;

    public ARR_GameManager gameManager;
    void Start()
    {
        hpImage=GameObject.Find("ARR_HpBar");
    }

    public void HpDecrease(){
        if(!gameManager.isEnd)
        {
            attack.Play();
            hpImage.GetComponent<Image>().fillAmount-=0.25f;  
            GameHp-=25f;

        }
    }

}
