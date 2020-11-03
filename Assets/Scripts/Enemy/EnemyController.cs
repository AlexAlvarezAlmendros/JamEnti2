
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsPlayer;

    public float health;

    public Vector3 flyPoint;
    bool flyPointSet;
    public float flyPointRange;


    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("PlayerObj").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
    }

    private void Patroling()
    {
        if (!flyPointSet) SearchFlyPoint();

        if (flyPointSet)
            agent.SetDestination(flyPoint);

        Vector3 distanceToFlyPoint = transform.position - flyPoint;

        if (distanceToFlyPoint.magnitude < 1f)
            flyPointSet = false;
    }
    private void SearchFlyPoint()
    {
        float randomZ = Random.Range(-flyPointRange, flyPointRange);
        float randomX = Random.Range(-flyPointRange, flyPointRange);

        flyPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

            flyPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
