using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth;
    public int enemyMaxHealth;
    public GameObject psychoEnemy;
    public GameObject enemySpawn;
    public GameObject player;
    public PlayerBehaviour behave;

    //private float waitAfterDeath;

    // Use this for initialization
    void Start () {
        //waitAfterDeath = 3.0f;
        enemyMaxHealth = 15;
        enemyHealth = enemyMaxHealth;
    }
	
	// Update is called once per frame
	void Update () {

        if (psychoEnemy == null)
        {
            Debug.Log("Enemy is null");
        }

        if (enemyHealth <= 0)
        {

            //Debug.Log("Enemy Died");
            psychoEnemy.SetActive(false);

            //Debug.Log("Enemy respawned");
            psychoEnemy.GetComponent<Transform>().position = enemySpawn.GetComponent<Transform>().position;
            psychoEnemy.GetComponent<Transform>().rotation = enemySpawn.GetComponent<Transform>().rotation;
            psychoEnemy.SetActive(true);
            enemyHealth = enemyMaxHealth;
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void GiveDamage(int damageToGive)
    {

        Debug.Log("Damage: " + damageToGive);
        enemyHealth -= damageToGive;
    }
}
