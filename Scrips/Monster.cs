using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    //10번 때리면 죽고 난 뒤 내 동료가 된다.
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
    {   // 몬스터가 죽은 후 동료가 되는데 점프가 높게 안뛰어지네? 
        transform.localScale = new Vector3 (-1, 1, 1);
        transform.parent = GameObject.FindWithTag("Player").transform;
        transform.localPosition = new Vector3(-0.7f, 0.35f, 0); 
    }
}
