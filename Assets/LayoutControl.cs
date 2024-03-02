using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)transform.GetChild(0).transform);
    }
}
