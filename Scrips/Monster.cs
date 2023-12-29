using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //10�� ������ �װ� �� �� �� ���ᰡ �ȴ�.
    [SerializeField]
    int Hp = 10;
    public void GetDmg(int demige) 
    {
        Hp -= demige;
        if (Hp < 0) 
        {
            Death();
        
        }
    }

    public void Death() 
    {   // ���Ͱ� ���� �� ���ᰡ �Ǵµ� ������ ���� �ȶپ�����? 
        transform.localScale = new Vector3 (-1, 1, 1);
        transform.parent = GameObject.FindWithTag("Player").transform;
        transform.localPosition = new Vector3(-0.7f, 0.35f, 0); 
    }
}
