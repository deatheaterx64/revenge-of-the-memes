using UnityEngine;

public class ChickenRingsAttack : MonoBehaviour
{
    public GameObject ring;

    public void OnAttack()
    {
        Instantiate(ring, transform.position, transform.rotation);
    }
    public void Nothing()
    {

    }
}
