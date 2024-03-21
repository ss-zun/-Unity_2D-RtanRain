using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject rain;

    void Start()
    {
        // 함수를 반복적으로 수행해주는 기능
        InvokeRepeating("MakeRain", 0f, 1f); // 함수명, 몇 초 이후에 생성할건지, 생성주기
                                             // MakeRain이라는 함수를 바로 1초마다 반복해서 호출
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 빗방울 게임 오브젝트 생성
    void MakeRain()
    {
        // Hierarchy창에 게임 오브젝트(rain) 하나 생성
        Instantiate(rain);
    }
}
