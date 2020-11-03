
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public meshTester navmeshupdown;

    public Transform player;
    public Transform player1;

    public LayerMask whatIsPlayer;

    public float health;

    public Vector3 flyPoint;
    bool flyPointSet;
    public float flyPointRange;


    public float sightRange;
    public bool player1InSightRange, playerInSightRange;


    private void Update()
    {
        //Check for sight and attack range
        player1InSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);

        if (!playerInSightRange && !player1InSightRange) Patroling();
        if (playerInSightRange)
        {
            ChasePlayer(true);
        }
        else { 
            if (player1InSightRange) ChasePlayer(false);
        }
    }

    private void Patroling()
    {
       
        if (!flyPointSet) SearchFlyPoint();

        if (flyPointSet) {
            agent.SetDestination(flyPoint);
            transform.LookAt(flyPoint);
        }

        Vector3 distanceToFlyPoint = new Vector3 (transform.position.x - flyPoint.x, 0, transform.position.z - flyPoint.z);

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

    private void ChasePlayer(bool _whatplayer)
    {
        if (_whatplayer)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player.position);
        }
        else {
            agent.SetDestination(player1.position);
            transform.LookAt(player1.position);

        }
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
