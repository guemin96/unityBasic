using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 target = new Vector3(8, 1.5f, 0);

    // Update is called once per frame
    void Update()
    {
        //1. MoveTowards
        //transform.position =
        //    Vector3.MoveTowards(transform.position,
        //                        target, 2f);//매개변수(현재위치, 목표위치, 속도)
        //2. SmoothDamp
        //Vector3 velo = Vector3.zero;


        //transform.position =
        //    Vector3.SmoothDamp(transform.position
        //                        , target, ref velo, 0.1f);

        //3. Lerp(선형 보간 이동)

        transform.position =
            Vector3.Lerp(transform.position,
                                target, 0.1f* Time.deltaTime);
        //4. SLerp(구면 선형 보간 이동)
        //transform.position =
        //    Vector3.Slerp(transform.position,
        //                        target, 0.005f);
    }
}
