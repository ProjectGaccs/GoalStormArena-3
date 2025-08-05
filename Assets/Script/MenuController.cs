using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public static MainMenuController Instance { get; private set; }

    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Button playButton;
    [SerializeField] private Button recordButton;
    [SerializeField] private int visibleCanvasOrder = 5;
    [SerializeField] private int hiddenCanvasOrder = -1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        InitializeButtons();
        Time.timeScale = 0f;
    }

    private void InitializeButtons()
    {
        playButton.onClick.AddListener(() =>
        {
            HideMenu();
            GameManager.Instance.StartGame();
        });

        recordButton.onClick.AddListener(() =>
        {
            HighscoreDisplay.Instance.Show();
        });
    }

    public void ShowMenu()
    {
        menuCanvas.sortingOrder = visibleCanvasOrder;
    }

    public void HideMenu()
    {
        menuCanvas.sortingOrder = hiddenCanvasOrder;
    }
}
