using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LifeCycle : MonoBehaviour
{

    void Update()
    {
        if(Input.anyKeyDown)
        {
            Debug.Log("플레이어가 아무 키를 눌렀습니다.");
        }
        //if(Input.anyKey)
        //{
        //    Debug.Log("플레이어가 아무 키를 누르고 있습니다.");
        //}
        //if(Input.GetKeyDown(KeyCode.Return))//return = "enter키"라 생각하면 된다.
        //{
        //    Debug.Log("아이템을 구입하였습니다.");
        //}
        //if(Input.GetKey(KeyCode.LeftArrow))//방향키(Arrow)
        //{
        //    Debug.Log("왼쪽으로 이동중");
        //}
        //if(Input.GetKeyUp(KeyCode.RightArrow))
        //{
        //    Debug.Log("오른쪽 이동을 멈추었습니다.");
        //}

        //if (Input.GetMouseButtonUp(0))
        //{
        //    Debug.Log("미사일 발사!");
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    Debug.Log("미사일 모으는 중");
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("슈퍼미사일 발사!");
        //}
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    Debug.Log("!");
        //}
        //if (Input.GetButton("Fire1"))
        //{
        //    Debug.Log("점프 모으는 중...!");
        //}
        //if (Input.GetButtonUp("Fire1"))
        //{
        //    Debug.Log("슈퍼 점프");
        //}
        if(Input.GetButton("Horizontal"))
        {
            Debug.Log("횡 이동 중.." + Input.GetAxisRaw("Horizontal"));//
        }
        if (Input.GetButton("Vertical"))
        {
            Debug.Log("종 이동 중.." + Input.GetAxisRaw("Vertical"));//
        }
    }

}


// 유니티 LIFE CYCLE 설명
// Awake와 Start는 초기화의 영역
//void Awake()
//{
//    Debug.Log("플레이어 데이터가 준비되었습니다.");
//}
//void Start()
//{
//    Debug.Log("사냥 장비를 챙겼습니다.");

//}
////활성화 영역
//void OnEnable()// 게임 오브젝트가 활성화 되었을 때
//{
//    Debug.Log("플레이어 로그인");
//}

////물리 연산 영역-> 고정된 실행 주기로 CPU를 많이 사용
//void FixedUpdate()
//{
//    Debug.Log("이동~");
//}
//// 게임 로직 영역-> 환경에 따라 실행 주기가 떨어질 수 있음
//void Update()
//{
//    Debug.Log("몬스터 사냥!!");
//}
//void LateUpdate()// 로직의 후처리를 담당
//{
//    Debug.Log("경험치 획득");   
//}
////비활성화 영역
//void OnDisable()
//{
//    Debug.Log("플레이어 로그아웃");
//}
////해제 영역
//void OnDestroy()// 게임 오브젝트가 삭제될때
//{
//    Debug.Log("플레이어 데이터가 해제하였습니다.");
//}