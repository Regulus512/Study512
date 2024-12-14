using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullettest : MonoBehaviour
{

    Vector3 goVec, firstVec;
    
    [SerializeField] float speed = 0.1f;
    // 날아가기위해 회전할 각도
    [SerializeField] float angle = 1f;
    [SerializeField] float angle_itv = 0.1f;

    [SerializeField] float change_itv = 0.1f;
    [SerializeField] float change_dir_itv = 1f;

    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        //간다 내가 회전된방향으로
        //goVec = AngleToDirZ(angle);
        firstVec = goVec;
        Invoke("ChangeAngleDir", change_dir_itv);
        Invoke("ChangeAngle", change_itv);
    }
    void ChangeAngle() // 진행벡터를 변경
    {
        //goVec = AngleToDirZ(angle+angle_itv);
        angle =(angle < 0)? 0-angle_itv : angle + angle_itv;
        Invoke("ChangeAngle", change_itv);
        
    }

    void ChangeAngleDir() // 진행 각도를 반대로 변경
    {
        Debug.Log("ChangeDir");
        //angle_itv *= 2;
        angle *= -1;
        Invoke("ChangeAngleDir", change_dir_itv);
    }

    

    private void FixedUpdate()
    {
        transform.Translate(goVec.normalized * speed*Time.deltaTime);
    }

}
