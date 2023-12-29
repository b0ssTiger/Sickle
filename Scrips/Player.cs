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
        // ���� ȭ��ǥ�� ������ �ִ� ���
        if (Input.GetKey(KeyCode.LeftArrow) && ctrlable)
        {
            // Animator ���� �÷��̾� �ִϸ��̼��� ��Ȳ ���� �־� �� ��� ���
            animator.SetBool("isWalk", true);
            // ��ü�� ���� �������� ������ ���� �����ݴϴ�. ��, �������� �̵� ��ŵ�ϴ�.
            rig.AddForce(Vector2.left * moveSpeed, ForceMode2D.Impulse);

            // velocity �� ��ü�� �ӵ��Դϴ�. ���� �ӵ��� �����ϸ� �� �̻� �������� �ʰ��մϴ�.
            rig.velocity = new Vector2(Mathf.Max(rig.velocity.x, -maxSpeed), rig.velocity.y);

            // scale ���� �̿��� ĳ���Ͱ� �̵� ������ �ٶ󺸰� �մϴ�.
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && ctrlable) // ������ ȭ��ǥ�� ������ �ִ� ���
        {
            animator.SetBool("isWalk", true);
            rig.AddForce(Vector2.right * moveSpeed, ForceMode2D.Impulse);
            rig.velocity = new Vector2(Mathf.Min(rig.velocity.x, maxSpeed), rig.velocity.y);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) // �̵� Ű�� �� ���
        {
            animator.SetBool("isWalk", false);
            // x �ӵ��� �ٿ� �̵� �������� ���� ��¦�� �����̰� ���� �ٷ� ���߰� �մϴ�.
            rig.velocity = new Vector3(rig.velocity.normalized.x, rig.velocity.y);
        }

        // �����̽��ٸ� ������ �����մϴ�.
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (IsGrounded()  && ctrlable) 
            {
                animator.SetTrigger("Jump");
                rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
              
        }

        if (Input.GetKeyDown(KeyCode.Z)) // z ������ 
        {
            if (ctrlable) //���������� �������� Ȯ��
            {
                animator.SetTrigger("Attack"); //���� �ִϸ��̼� ���� 
                StartCoroutine(Attackdelay()); //���õ����� �ڷ�ƾ ���� 
            }

            //�����ϰ� �ִ� ���߿� ���� x , �����ϰ� �ִ� ���߿��� ������ �ȵ� �ڷ�ƾ!!!!!!

        }
    }
    IEnumerator Attackdelay() //Ư�� �ð� ���� ��0�� ���߰� �Ͱų� �����̸� �ְ���� �� 
    {
        attackRange.gameObject.SetActive(true);
        ctrlable = false; //�����Ұ����� ���°� �ȴ�.
        yield return new WaitForSeconds(1f); //���� ����� �ߵ� �Ͽ��� �� �ð� ��ŭ ���� �ִ´�. 
        ctrlable = true; //����� ���� �� ���� �ൿ�� ���� �� �ִ�.
        attackRange.gameObject.SetActive(false);
    }

    // ĳ���Ͱ� ���� ��� �ִ��� üũ
    bool IsGrounded()
    {
        // ĳ���͸� �߽����� �Ʒ� �������� ray �� ��� �� ���� Layer Ÿ���� Ground �� ��ü�� �ִ��� �˻��մϴ�.
        var ray = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << LayerMask.NameToLayer("Ground"));
        return ray.collider != null;
    }
}
