using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEffect : MonoBehaviour
{
     [Header("Rotation Setting")]
    [SerializeField] [Range(1f,100f)] float rotateSpeed = 50f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        if(gameObject.activeSelf==true)
            transform.Rotate(0,0,-Time.deltaTime*rotateSpeed, Space.Self); 
    }
}
