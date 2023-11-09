using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARR_PlayerMove : MonoBehaviour
{
    public void MoveLeft(){
        if(transform.position.x>-6){
        transform.Translate(-1,0,0);
        }
        
    }

    public void MoveRight(){
        if(transform.position.x<6){
        transform.Translate(1,0,0);
        }
    }
}
