using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed;
    Vector3 offSet;

    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - target.position;//플레이어와 수류탄 사이 거리의 차이가 나옴
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offSet;
        transform.RotateAround(target.position, // 위에 offSet을 설정해주지 않고 target.position을 썼을때는 수류탄이 플레이어를 따라가지 못함
                                                // offset을 따로 설정해줌으로써 수류탄이 플레이어를 계속 따라가게 만들어줌
                                Vector3.up,
                                orbitSpeed * Time.deltaTime);
        offSet = transform.position - target.position;
    }
}
