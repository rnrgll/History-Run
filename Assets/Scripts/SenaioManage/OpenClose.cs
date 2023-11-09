using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public GameObject Object;

    public void ClicktoClose()
    {
        Debug.Log("close click");
        Object.SetActive(false);
    }

    public void ClicktoOpen(){
        Object.SetActive(true);

    }
}
