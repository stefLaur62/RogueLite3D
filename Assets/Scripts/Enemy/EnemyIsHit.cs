using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyIsHit : MonoBehaviour
{
    protected int playerDamage;
    public static int health;
    [SerializeField]
    protected GameData gameData;
    
    public void loseLife()
    {
        health -= playerDamage;
    }
    public void isAlive()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
