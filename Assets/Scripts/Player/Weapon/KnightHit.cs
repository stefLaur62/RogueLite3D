using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightHit : MonoBehaviour
{
    [SerializeField]
    private PlayerAttack playerAttack;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            playerAttack.OnSwordHit(other);
        }
    }
}
