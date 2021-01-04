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
    protected GameObject moneyPrefab;
    [SerializeField]
    protected DataManager dataManager;

    private PlayerAttack playerAttack;
    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
    }

    void Update()
    {
        isAlive();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
            loseLife();
    }
    public void loseLife()
    {
        health -= playerAttack.GetDamage();
        Debug.Log(-playerAttack.GetDamage() + ":" +health);
    }
    public void isAlive()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(enemyDeathPrefab, transform.position+Vector3.up, Quaternion.identity);
            Instantiate(moneyPrefab, transform.position + Vector3.up, Quaternion.identity);
            dataManager.AddXp(GiveXp());
        }
    }

    private int GiveXp()
    {
        return Random.Range((gameData.level - 1) * 50, gameData.level * 50);
    }
}
