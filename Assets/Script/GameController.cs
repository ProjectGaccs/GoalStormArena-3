using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    [SerializeField] private Button backButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private TMP_Text finishText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject finishPopup;

    [Header("Player")]
    [SerializeField] private SpriteRenderer playerRenderer;

    private int currentScore;
    private int savedHighscore;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        InitializeButtons();
        LoadHighscore();
        PauseGame();
    }

    private void Update()
    {
        if (currentScore <= savedHighscore) return;

        savedHighscore = currentScore;
        PlayerPrefs.SetInt("RecordPoint", savedHighscore);
        PlayerPrefs.Save();
    }

    private void InitializeButtons()
    {
        backButton.onClick.AddListener(ShowMenu);
        homeButton.onClick.AddListener(ShowMenu);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void LoadHighscore()
    {
        savedHighscore = PlayerPrefs.GetInt("RecordPoint", 0);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        ResumeGame();
        finishPopup.SetActive(false);
        currentScore = 0;
        UpdateScoreDisplay();

        playerRenderer.sortingOrder = 0;
        ObjectSpawner.Instance.StartSpawning();
        LoadHighscore();
    }

    public void GameOver()
    {
        PauseGame();
        ObjectSpawner.Instance.StopSpawning();
        finishPopup.SetActive(true);
        playerRenderer.sortingOrder = -1;
    }

    public void AddPoint()
    {
        currentScore++;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = $"Point: {currentScore}";
        finishText.text = $"Result: {currentScore} point";
    }

    private void RestartGame()
    {
        StartGame();
    }

    private void ShowMenu()
    {
        PauseGame();
        MainMenuController.Instance.ShowMenu();
    }
}
