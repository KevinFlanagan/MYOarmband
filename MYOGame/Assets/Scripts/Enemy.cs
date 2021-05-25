using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;
    public float health = 3f;
    //public GameObject[] enemies;

    public static int EnemiesLeft = 0; // Enemy counter

    void start ()
    {
        EnemiesLeft++;
    }
    
    void OnCollisionEnter2D (Collision2D colInfo)
    {
       if (colInfo.relativeVelocity.magnitude > health)
       {
           Die();
           Score.scoreValue += 100;
           
       }
    }

    void Die()
    {
        Instantiate(explosion, transform.position, Quaternion.identity); // causes explosion

        EnemiesLeft--;
        if (EnemiesLeft >= 0)

            Debug.Log("Enemy Destroyed!");
            //SceneManager.LoadScene("MainLevel 1");

        Destroy(gameObject);
    }
    
}

