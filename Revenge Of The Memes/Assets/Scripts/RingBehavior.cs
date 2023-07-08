using UnityEngine;

public class RingBehavior : MonoBehaviour
{
    public float speed = 5f;
    public float attackDamage = 8f;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.GetComponent<Player>().OnAttacked(attackDamage);
    }
}
