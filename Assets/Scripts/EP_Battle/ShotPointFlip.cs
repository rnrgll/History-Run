using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPointFlip : MonoBehaviour
{
    public GameObject Player;
    Vector2 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = gameObject.transform.localPosition;
        Debug.Log(originalPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFilp())
        {
            Vector2 shotPointPos = new Vector2(-originalPos.x, originalPos.y);
            gameObject.transform.localPosition = shotPointPos;
        }
        else
        {
            gameObject.transform.localPosition = originalPos;
        }

    }
    public bool isFilp()
    {
        Player = GameObject.Find("Player");
        if (Player.GetComponent<SpriteRenderer>().flipX)
            return true;
        else return false;
    }





}
