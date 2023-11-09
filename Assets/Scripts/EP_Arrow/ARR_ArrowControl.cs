using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARR_ArrowControl : MonoBehaviour
{
    GameObject player; // GameObject는 적용하고자 하는 프로젝트의 오브젝트 이름을 사용하는 것이 정석!
    GameObject hpControl;
    //public AudioSource attack;

    void Start()
    {
        // 게임 내의 오브젝트와 연결을 짓기 위한 부분! 꼭 필요하다
        player = GameObject.Find("ARR_Player");
        hpControl=GameObject.Find("ARR_HpControl");
    }

    void Update()
    {
        // 프레임마다 등속으로 하락시킨다.
        transform.Translate(0, -0.5f, 0);

        // 화면 밖으로 나오면 오브젝트를 소멸시킨다.
        if (transform.position.y < -5.0f) Destroy(gameObject);

        // 충돌판정
        Vector2 p1 = transform.position; // 화살의 중심 좌표값을 담는 Vector
        Vector2 p2 = this.player.transform.position; // GameObject를 통해 찾은 player의 중심 좌표값을 담은 Vector

        // p1 과 p2의 충돌여부를 위한 계산
        Vector2 dir = p1 - p2; // p2에서 p1으로 향하는 dir 벡터를 추출
        float d = dir.magnitude; // dir 벡터를 통해 d를 계산

        float r1 = 0.5f; // 화살의 반경
        float r2 = 1.0f; // player의 반경

        if (d < r1 + r2) {
            
            Destroy(gameObject);
            hpControl.GetComponent<ARR_HpControl>().HpDecrease();
            
            
        }

        

    }
}