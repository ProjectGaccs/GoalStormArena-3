using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplay : MonoBehaviour
{
    public static HighscoreDisplay Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private Button backButton;

    private const string HighscoreKey = "RecordPoint";

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        InitializeUI();
        Hide();
    }

    private void InitializeUI()
    {
        backButton.onClick.AddListener(Hide);
    }

    public void Show()
    {
        int highscore = PlayerPrefs.GetInt(HighscoreKey, 0);
        highscoreText.text = $"The best record: {highscore}";
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
