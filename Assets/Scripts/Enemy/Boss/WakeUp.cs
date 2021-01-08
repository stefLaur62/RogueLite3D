using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WakeUp : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField]
    private Transform playerTransform;

    private void OnEnable()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Wake up!");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(playerTransform.position);
    }
}
