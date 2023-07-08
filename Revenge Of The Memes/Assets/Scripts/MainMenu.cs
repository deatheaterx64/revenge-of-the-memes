using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject aboutPage;
    public GameObject mainPage;
    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnAboutButton()
    {
        mainPage.SetActive(false);
        aboutPage.SetActive(true);
    }

    public void OnBackButton()
    {
        aboutPage.SetActive(false);
        mainPage.SetActive(true);
    }

}
