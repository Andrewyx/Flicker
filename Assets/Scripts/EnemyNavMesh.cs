using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform movePositionTransform;

    private NavMeshAgent navMeshAgent;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;
    }
}
