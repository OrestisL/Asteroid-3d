using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;

public class IntroUI : MonoBehaviour
{
    public Button StartButton, HighscoresButton, QuitButton;
    public GameObject HighscoreEntryPrefab;
    public Transform HighscoreParent;

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

    private void ShowHighscores()
    {
        HighscoreParent.gameObject.SetActive(!HighscoreParent.gameObject.activeSelf);
        // clear
        foreach (Transform child in HighscoreParent.GetComponentInChildren<Transform>()) 
        {
            if (child.name == "Label" || child.name == "Vert") continue;

            Destroy(child.gameObject);
        }

        List<Highscore> data = Utilities.LoadData<List<Highscore>>("Highscores.json");
        if (data == null || data.Count == 0) return;
        foreach (Highscore highscore in data) 
        {
            var entry = Instantiate(HighscoreEntryPrefab, HighscoreParent);
            entry.GetComponent<TextMeshProUGUI>().text = highscore.Score.ToString("f0");
        }

       
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }

}
