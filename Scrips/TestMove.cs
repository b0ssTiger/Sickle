using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMove : CharacterController
{
    void OnMove(InputValue value) 
    {
        Debug.Log("���Ͷ��Ӹ�");
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}
