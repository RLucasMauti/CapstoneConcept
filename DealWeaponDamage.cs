using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWeaponDamage : MonoBehaviour {

    //private EnemyHealthManager enemyManage;
    public GameObject enemyChar;
    public GameObject weapon;
    private bool enemyDamaged;
	// Use this for initialization
	void Start () {

        enemyDamaged = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        
    }

    private void FixedUpdate()
    {

        enemyDamaged = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !enemyDamaged)
        {

            enemyDamaged = true;
            collision.GetComponent<EnemyHealthManager>().GiveDamage(5);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyDamaged = false;
        }
    }
}
