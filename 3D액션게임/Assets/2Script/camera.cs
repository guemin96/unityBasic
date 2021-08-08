using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;//현재 카메라 위치에서 player위치값을 빼주면 그 사이의 거리가 나오게 된다. 그리고 그 값을 playerTransform.position에 더해준다.
    }
    void LateUpdate() //카메라 이동같은 경우에는 LateUpdate에서 많이 사용한다.
    {
        transform.position = playerTransform.position + Offset;
    }
}
