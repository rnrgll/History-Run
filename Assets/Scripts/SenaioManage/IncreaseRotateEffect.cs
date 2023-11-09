using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseRotateEffect : MonoBehaviour
{
    [Header("Rotation Setting")]
    [SerializeField] [Range(1f,200f)] float rotateSpeed = 100f;
    [SerializeField] [Range(1f,200f)] float max_rotateSpeed = 200f;
    float spin_acc = 10f;


    CanvasGroup canvasGroup;
    float fadeSpeed = 0.5f;


    public GameObject Door;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()

    {
        if(gameObject.activeSelf==true)
        {
            if (rotateSpeed < max_rotateSpeed)
            {
                rotateSpeed = rotateSpeed + spin_acc;
            }
            transform.Rotate(0,0,-Time.deltaTime*rotateSpeed, Space.Self);
            Invoke("DoorOpen",1);

        }

        

             
    }

    public void DoorOpen()  {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
        }
        gameObject.SetActive(false);
        Door.SetActive(true);
                
    
    
    }



}
