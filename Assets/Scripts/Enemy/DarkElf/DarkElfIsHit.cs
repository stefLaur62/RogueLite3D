using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkElfIsHit : EnemyIsHit
{
    // Start is called before the first frame update
    void Start()
    {
        health = 100; 
        Debug.Log(gameData.attack);
        playerDamage = gameData.attack * 5;
    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag=="Weapon")
            loseLife();
    }
}
