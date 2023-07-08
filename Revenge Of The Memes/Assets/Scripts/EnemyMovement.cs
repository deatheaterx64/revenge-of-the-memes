using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody rb;
    GameObject player;
    public float movementSpeed = 5f;
    Animator animationController;
    public float attackAnimationDuration;
    public float attackDamage;
    public float rotationYOffset = 0f;
    public float attackRange = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        animationController = GetComponent<Animator>();
        StartCoroutine(nameof(Move));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }

    IEnumerator Move()
    {
        while(true)
        {
            float distanceToPlayer = (transform.position - player.transform.position).magnitude;
            if (distanceToPlayer > attackRange)
            {
                rb.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.fixedDeltaTime);
                yield return null;
            }
            else
            {
                animationController.SetBool("isClose", true);
                yield return new WaitForSeconds(2 * attackAnimationDuration/3f);
                player.GetComponent<Player>().OnAttacked(attackDamage);
                yield return new WaitForSeconds(attackAnimationDuration / 3f);
                animationController.SetBool("isClose", false);
            }
        }
    }
}
