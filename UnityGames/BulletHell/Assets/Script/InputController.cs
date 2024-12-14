using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    bool can_move = false; // 이동 가능 여부(게임 중에만 활성화)

    // 8방향 이동 입력값을 사용할 변수
    float move_x = 0, move_y = 0;
    float speed = 3.0f;

    public void InitInputController(float _speed)
    {
        speed = _speed;
    }

    public void GameStart()
    {
        can_move = true;
    }
    public void GameOver()
    {
        can_move = false;
    }

    bool isTouch = false;
    Vector2 startPos = Vector2.zero, endPos=Vector2.zero, dir = Vector2.zero;
    // Update is called once per frame
    private void Update()
    {
        if (isTouch)
        {
            endPos = Input.mousePosition;
            dir = (endPos - startPos).normalized;
            
        }
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            isTouch = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
            startPos = Vector2.zero;
            endPos = Vector2.zero;
            dir = Vector2.zero;
        }
        transform.Translate(new Vector2(dir.x, dir.y) * Time.deltaTime * speed);
    }

    void FixedUpdate()
    {
        if (can_move)
        {
            move_x = Input.GetAxis("Horizontal");
            move_y = Input.GetAxis("Vertical");
            transform.Translate(new Vector2(move_x, move_y) * Time.deltaTime * speed);
            //Debug.Log($"new Vector2({move_x}, {move_y})");
        }
    }


}
