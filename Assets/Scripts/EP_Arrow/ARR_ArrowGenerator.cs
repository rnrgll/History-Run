using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARR_ArrowGenerator : MonoBehaviour
{
    public GameObject ARR_ArrowPrefab;
    float span = 0.5f;
    float delta = 0;
    public AudioSource sound;

    void Update()
    {
        /* 이 부분에서 화살이 1개씩 생성되는 로직을 구현
         * 1. 1초가 흐르는 것을 어떻게 구현했는가.
         * => Time.deltaTime;은 프레임과 프레임 사이의 시간 차이를 delta변수에 모아서
         *    'delta > span 값보다 큰 -> 1 보다 크다면' 이라는 작업을 통해 시간의 개념을 만들었다.
         *    
         * 2. 화살표는 어떻게 구현했는가.
         * => GameObject를 생성하는데 이 GameObject는 Instantiate(Prefab);이라는 함수로 만들어진다.
         *    'Instantiate느 인자값으로 Prefab을 넣으면 Instance로 반환해주는 함수'
         *    이렇게 생성된 GameObject를 Random(범위)를 통해 X축 좌표를 생성하여
         *    Vector3(x, y, z)로 만들어 위치하게 한다.
         */
        delta += Time.deltaTime;
        if (delta > span)
        {
     
            GameObject go = Instantiate(ARR_ArrowPrefab) as GameObject;
            sound.Play();

            
            go.transform.position = new Vector3(Random.Range(-7,7), 7, 0);
            delta = 0;
        }
    }
}