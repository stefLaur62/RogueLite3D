using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    protected GameObject itemPrefab;
    [SerializeField]
    protected DataManager dataManager;

    private PlayerAttack playerAttack;

    private ItemDatabaseObject database;
    void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
        SetDatase();
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
        Debug.Log(playerAttack.GetDamage());
        health -= playerAttack.GetDamage();
    }
    public void isAlive()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(enemyDeathPrefab, transform.position+Vector3.up, Quaternion.identity);
            Instantiate(moneyPrefab, transform.position + Vector3.up, Quaternion.identity);
            dataManager.AddXp(GiveXp());
            DropItem();
        }
    }

    private void DropItem()
    {
        ItemObject itemObject = database.items[Random.Range(0, database.items.Length-1)];
        itemPrefab.GetComponent<GroundItem>().item = itemObject;
        itemPrefab.GetComponentInChildren<FaceCam>()._camera = FindObjectOfType<Camera>();
        var GameObject = Instantiate(itemPrefab, transform.position + Vector3.up / 2, Quaternion.identity);
    }

    private int GiveXp()
    {
        return Random.Range((gameData.level - 1) * 30, gameData.level * 50);
    }
    public void SetDatase()
    {
#if UNITY_EDITOR
        database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
        database = Resources.Load<ItemDatabaseObject>("Database");
#endif
    }
}
