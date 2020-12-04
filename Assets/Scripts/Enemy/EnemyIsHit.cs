using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyIsHit : MonoBehaviour
{
    protected int playerDamage;
    public static int Health;
    public void loseLife()
    {
        Debug.Log("Lose life");
        Health -= playerDamage;
    }
    public void isAlive()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
