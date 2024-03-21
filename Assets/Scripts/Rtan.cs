using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rtan : MonoBehaviour
{
    float direction = 0.05f;

    SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60; // 어떤 기기든지 1초에 60번만 계산될 수 있게끔 설정
        renderer = GetComponent<SpriteRenderer>(); // renderer라는 변수에 SpriteRenderer 컴포넌트에 대한 정보들이 담겨짐
        // 주의! 이 스크립트가 붙여진 오브젝트에 같이 있는 컴포넌트만 GetComponent로 불러올 수 있음!
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 왼쪽 버튼(0)이 눌러졌을 때
        if (Input.GetMouseButtonDown(0))
        {
            direction *= -1;
            renderer.flipX = !renderer.flipX; // renderer.flipX가 true면 false, false면 true
        }

        // 오른쪽 벽에 부딪혔을 때 왼쪽으로 방향 전환
        if(transform.position.x > 2.6f)
        {
            renderer.flipX = true; // 체크되었을 때 왼쪽 방향으로 전환
            direction = -0.05f;
        }

        // 왼쪽 벽에 부딪혔을 때 오른쪽으로 방향 전환
        if (transform.position.x < -2.6f)
        {
            renderer.flipX = false; // 체크되지 않았을 때 오른쪽 방향으로 전환
            direction = 0.05f;
        }

        transform.position += Vector3.right * direction; // Vector3.right == new Vector3(1f, 0, 0);
        // 1 * 0.05, 0 * 0.05, 0 * 0.05 == 0.05, 0, 0
    }
}
