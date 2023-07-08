using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int enemiesKilled = 0;
    public GameObject player;
    public GameObject gameUI;
    public GameObject lostUI;
    void Start()
    {
        enemiesKilled = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnDeath()
    {
        gameUI.SetActive(false);
        lostUI.SetActive(true);
    }
}
