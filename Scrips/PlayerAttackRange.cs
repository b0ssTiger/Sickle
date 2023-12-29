using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRange : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Monster") 
        {
            //Debug.Log("ฒÜนใ");
            collision.gameObject.GetComponent<Monster>().GetDmg(1); 
        
        }
    }
}
