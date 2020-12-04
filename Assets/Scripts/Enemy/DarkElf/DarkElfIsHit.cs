using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkElfIsHit : EnemyIsHit
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 100;
        playerDamage = 34;
    }

    // Update is called once per frame
    void Update()
    {
        isAlive();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Weapon")
            loseLife();
    }
}
