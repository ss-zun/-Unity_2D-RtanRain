using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    float size = 1.0f; // 빗방울 크기
    int score = 1; // 빗방울 점수값

    SpriteRenderer renderer; // 빗방울 색상변경을 위한 SpriteRenderer타입 변수

    // Start is called before the first frame update 
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>(); // 빗방울 색상변경을 위한 SpriteRenderer 컴포넌트 정보 저장

        // Range(최소값, 최대값)
        float x = Random.Range(-2.4f, 2.4f); // x의 값 (-2.4f ~ 2.4f) 사이
        float y = Random.Range(3.0f, 5.0f); // y의 값 (3.0f ~ 5.0f) 사이

        // 랜덤한 x, y값으로 위치 설정(빗방울 랜덤 생성)
        transform.position = new Vector3(x, y, 0);

        // 빗방울 타입 랜덤 지정
        int type = Random.Range(1, 4); // 1, 2, 3 중에 랜덤 생성

        // 각각의 조건문들이 연관되어 있으니 else if로 적어주기
        // 빗방울 타입별 설정
        if(type == 1)
        {
            size = 0.8f;
            score = 1;
            renderer.color = new Color(100 / 255f, 100 / 255f, 1f, 1f);
        }
        else if(type == 2)
        {
            size = 1.0f;
            score = 2;
            renderer.color = new Color(130 / 255f, 130 / 255f, 1f, 1f);
        }
        else if(type == 3)
        {
            size = 1.2f;
            score = 3;
            renderer.color = new Color(150 / 255f, 150 / 255f, 1f, 1f);
        }
        
        // 랜덤 크기값으로 빗방울 크기 지정
        transform.localScale = new Vector3(size, size, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 충돌이 일어났을 때 호출되는 이벤트 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌된 게임 오브젝트의 태그가 "Ground"일 때
        if(collision.gameObject.CompareTag("Ground"))
        {
            // 충돌된 게임 오브젝트 파괴(빗방울 파괴)
            Destroy(this.gameObject); // this == 현재 이 스크립트가 부착된 게임 오브젝트
        }
    }
}
