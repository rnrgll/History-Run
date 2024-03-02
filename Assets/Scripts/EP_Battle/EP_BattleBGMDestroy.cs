using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EP_BattleBGMDestroy : MonoBehaviour
{
    private BackgroundPlay2 backgroundPlay2;
    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        backgroundPlay2 = GameObject.Find("EPGameBGMSystem").GetComponent<BackgroundPlay2>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(backgroundPlay2.DestoryObjet);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
