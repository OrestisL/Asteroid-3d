using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class ScoreManager : GenericSingleton<ScoreManager>
{
    public float Score;
    public TextMeshProUGUI ScoreText;

    private List<Highscore> _highscores = new();
    public override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += SceneLoaded;

        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        Save();
        if (scene.buildIndex != 1)
            return;

        ScoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        Score = 0;
    }

    public void AddScore(float score)
    {
        Score += score;
        ScoreText.text = string.Format("Score: {0}", Score.ToString("f0"));
    }

    public void ShowFinalScore() 
    {
        ScoreText.gameObject.SetActive(false);
        var ui = Resources.FindObjectsOfTypeAll<MainUI>();
        ui[0].gameObject.SetActive(true);
        ui[0].SetText(Score);

        _highscores.Add(new(Score));
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    void Save() 
    {
        List<Highscore> oldH = Utilities.LoadData<List<Highscore>>("Highscores.json");
        if (oldH == null)
            oldH = new();

        List<Highscore> newH = oldH;
        newH.Add(new(Score));
        newH = newH.OrderBy(x => x.Score).ToList();

        Utilities.SaveData(newH, "Highscores.json");
    }
}
