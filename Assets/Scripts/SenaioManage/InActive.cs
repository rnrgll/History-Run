using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InActive : MonoBehaviour
{

    public GameObject InActiveObject;
    // Start is called before the first frame update
    void Start()
    {
        SetInActive();
    }

    public void SetInActive(){
        InActiveObject.SetActive(false);
    }


}
