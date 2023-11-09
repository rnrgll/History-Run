using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimit : MonoBehaviour
{
    float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {
        minY = -Camera.main.orthographicSize;
        maxY = Camera.main.orthographicSize+10;
        minX = -Camera.main.orthographicSize*Camera.main.aspect;
        maxX = Camera.main.orthographicSize*Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate() {
        LimitToMove();
    }


    void LimitToMove(){
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),
            Mathf.Clamp(transform.position.y, minY,maxY));
    }
}
