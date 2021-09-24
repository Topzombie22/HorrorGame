using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{

    public float lookRadius = 50f;

    Transform target;
    NavMeshAgent agent;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            agent.speed = 25.0f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        speed = 4f;
    }
}
