using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPref;
    void Start()
    {
        Instantiate(playerPref, transform.position, transform.rotation);
    }
}
