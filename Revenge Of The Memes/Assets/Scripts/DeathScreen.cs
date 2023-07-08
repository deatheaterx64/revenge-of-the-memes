using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI totalKills;
    private void Start()
    {
        totalKills.SetText(GameManager.enemiesKilled.ToString());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
