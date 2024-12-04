using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MainUI : MonoBehaviour
{
    public Button Button;
    public TextMeshProUGUI Text;
    private void Start()
    {
        Button.onClick.AddListener(() => UnityEngine.SceneManagement.SceneManager.LoadScene(0));
    }

    public void SetText(float score)
    {
        Text.text = string.Format("Game over! Your score is: {0}", score.ToString("f0"));
    }
}
