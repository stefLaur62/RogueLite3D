using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIsHit : MonoBehaviour
{
    protected int playerDamage;
    [SerializeField]
    private int health=50;
    [SerializeField]
    protected GameData gameData;
    [SerializeField]
    protected GameObject enemyDeathPrefab;
    [SerializeField]
    protected DataManager dataManager;

    void Start()
    {
        playerDamage = gameData.attack * 5;
    }

    void Update()
    {
        isAlive();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.tag == "Weapon")
            loseLife();
    }
    public void loseLife()
    {
        health -= playerDamage;
        Debug.Log(-playerDamage + ":" +health);
    }
    public void isAlive()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(enemyDeathPrefab, transform.position+Vector3.up, Quaternion.identity);
            dataManager.AddXp(GiveXp());
        }
    }

    private int GiveXp()
    {
        return Random.Range((gameData.level - 1) * 50, gameData.level * 50);
    }
}
