using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    public float moveSpeed;
    public float maxSpeed;
    public float jumpPower;
    private Animator animator;
    private bool ctrlable;
    public Transform attackRange;

    // Start is called before the first frame update
    void Start()
    {
        attackRange.gameObject.SetActive(false);
        ctrlable = true;
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // 왼쪽 화살표를 누르고 있는 경우
        if (Input.GetKey(KeyCode.LeftArrow) && ctrlable)
        {
            // Animator 에서 플레이어 애니메이션을 상황 별로 넣어 줄 경우 사용
            animator.SetBool("isWalk", true);
            // 물체에 왼쪽 방향으로 물리적 힘을 가해줍니다. 즉, 왼쪽으로 이동 시킵니다.
            rig.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);

            // velocity 는 물체의 속도입니다. 일정 속도에 도달하면 더 이상 빨라지지 않게합니다.
            rig.velocity = new Vector2(Mathf.Max(rig.velocity.x, -maxSpeed), rig.velocity.y);

            // scale 값을 이용해 캐릭터가 이동 방향을 바라보게 합니다.
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && ctrlable) // 오른쪽 화살표를 누르고 있는 경우
        {
            animator.SetBool("isWalk", true);
            rig.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
            rig.velocity = new Vector2(Mathf.Min(rig.velocity.x, maxSpeed), rig.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) // 이동 키를 뗀 경우
        {
            animator.SetBool("isWalk", false);
            // x 속도를 줄여 이동 방향으로 아주 살짝만 움직이고 거의 바로 멈추게 합니다.
            rig.velocity = new Vector3(rig.velocity.normalized.x, rig.velocity.y);
        }

        // 스페이스바를 누르면 점프합니다.
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (IsGrounded()  && ctrlable) 
            {
                animator.SetTrigger("Jump");
                rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
              
        }

        if (Input.GetKeyDown(KeyCode.Z)) // z 누르면 
        {
            if (ctrlable) //조종가능한 상태인지 확인
            {
                animator.SetTrigger("Attack"); //어택 애니메이션 실행 
                StartCoroutine(Attackdelay()); //어택딜레이 코루틴 실행 
            }

            //공격하고 있는 도중에 공격 x , 공격하고 있는 도중에는 점프도 안됨 코루틴!!!!!!

        }
    }
    IEnumerator Attackdelay() //특정 시간 동안 ㅇ0ㅇ 멈추고 싶거나 딜레이를 주고싶으 때 
    {
        attackRange.gameObject.SetActive(true);
        ctrlable = false; //조종불가능한 상태가 된다.
        yield return new WaitForSeconds(1f); //공격 모션이 발동 하였을 때 시간 만큼 멈춰 있는다. 
        ctrlable = true; //모션이 끝난 뒤 다음 행동을 취할 수 있다.
        attackRange.gameObject.SetActive(false);
    }

    // 캐릭터가 땅을 밟고 있는지 체크
    bool IsGrounded()
    {
        // 캐릭터를 중심으로 아래 방향으로 ray 를 쏘아 그 곳에 Layer 타입이 Ground 인 객체가 있는지 검사합니다.
        var ray = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << LayerMask.NameToLayer("Ground"));
        return ray.collider != null;
    }
}
