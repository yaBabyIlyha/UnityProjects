using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject hudCanvas;
    private bool isPaused = false;
    private FirstPersonController fpsController;

    void Start()
    {
        // Находим контроллер в сцене
        fpsController = FindObjectOfType<FirstPersonController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        if (hudCanvas != null) hudCanvas.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        
        // Разблокируем и показываем курсор
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        // Отключаем управление персонажем
        if (fpsController != null)
        {
            fpsController.enabled = false;
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        if (hudCanvas != null) hudCanvas.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        
        // Блокируем и скрываем курсор
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
        // Включаем управление персонажем
        if (fpsController != null)
        {
            fpsController.enabled = true;
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        // Восстанавливаем курсор перед загрузкой меню
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenuScene");
    }
}