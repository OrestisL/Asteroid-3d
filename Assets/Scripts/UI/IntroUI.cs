using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroUI : MonoBehaviour
{
    public Button StartButton, HighscoresButton, QuitButton;

    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        HighscoresButton.onClick.AddListener(ShowHighscores);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void StartGame() 
    {
        SceneManager.LoadScene(1);
    }

    private void ShowHighscores() { }

    private void QuitGame() 
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
