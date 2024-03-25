using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤을 위한 변수생성
    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreTxt;
    public Text timeTxt;

    int totalScore; // 전체 점수

    float totalTime = 30.0f; // 전체 시간

    private void Awake()
    {
        Instance = this; // Instance 변수에 this(내 자신의 데이터)를 넣어준다.
        Time.timeScale = 1.0f; // 게임 재시작시 다시 게임이 흐르기 위해
    }
    void Start()
    {
        // 함수를 반복적으로 수행해주는 기능
        InvokeRepeating("MakeRain", 0f, 1f); // 함수명, 몇 초 이후에 생성할건지, 생성주기
                                             // MakeRain이라는 함수를 바로 1초마다 반복해서 호출
    }

    void Update()
    {
        // 시간 감소는 totalTime이 0보다 클 때만 이루어져야함
        if(totalTime > 0f)
        {
            // 흘러간 시간만큼 게임 시간 감소
            totalTime -= Time.deltaTime; // 모든 기기들이 같은 시간값을 가질 수 있도록 프레임값에 대비하여 조정해준다.
        }
        else // 게임 종료
        {
            totalTime = 0f;
            endPanel.SetActive(true); // EndPanel(게임종료 화면) 활성화, false == 비활성화
            Time.timeScale = 0f; // Time의 크기를 0으로 만들어준다
                                 // 이 의미는 첫 번째 프레임과 그 다음 프레임까지의 시간의 차이가 없어진다는 것.
                                 // 그럼 결국 게임의 시간이 멈추게 되는 효과를 연출할 수가 있다.
                                 // 그리고 미세한 오차가 발생할 수 있다.
                                 // 0 보다 큰 상태에서 어떤 값을 뺄 때 마이너스가 발생할 수 있기 때문이다.
                                 // 그래서 이를 방지하기 위해 totalTime = 0f; 라는 코드를 작성한다.
        }

        timeTxt.text = totalTime.ToString("N2"); // 감소한 시간을 화면의 남은 시간 텍스트에 출력
    }

    // 빗방울 게임 오브젝트 생성
    void MakeRain()
    {
        // Hierarchy창에 게임 오브젝트(rain) 하나 생성
        Instantiate(rain);
    }

    // 점수를 올려주는 기능
    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString(); // totalScore(int형)을 string형으로 변환 필요
    }
}
