using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;
    
    [SerializeField] private Button backButton;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (startButton != null)
            startButton.onClick.AddListener(StartGame);
        
        if (optionsButton != null)
            optionsButton.onClick.AddListener(OpenOptions);
        
        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
            
       if (backButton != null)
            backButton.onClick.AddListener(Zurück);
    }

    // Diese Methode wird aufgerufen, wenn der "Start"-Button gedrückt wird
    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("SampleScene"); // Ersetze "GameScene" mit dem Namen deiner Spielfeld-Szene
    }

    // Diese Methode wird aufgerufen, wenn der "Options"-Button gedrückt wird
    public void OpenOptions()
    {
        Debug.Log("Optionen");
        SceneManager.LoadScene("OptionsMenu"); // Ersetze "OptionsScene" mit dem Namen deiner Options-Szene
    }

    // Diese Methode wird aufgerufen, wenn der "Quit"-Button gedrückt wird
    public void QuitGame()
    {
        Debug.Log("Spiel wird beendet...");
        Application.Quit();
    }
    public void Zurück()
    {
        Debug.Log("Zurück");
        SceneManager.LoadScene("Main");

    }
}

//public class OptionsMenu : MonoBehaviour
//{
  //  [SerializeField] private Button backButton;
//
  //  private void Start()
    //{
      //  if (backButton != null)
        //    backButton.onClick.AddListener(GoBack);
    //}

    // Diese Methode wird aufgerufen, wenn der "Zurück"-Button gedrückt wird
//    public void GoBack()
  //  {
    //    SceneManager.LoadScene("Main"); // Ersetze "MainMenuScene" mit dem Namen deiner Hauptmenü-Szene
    //}
//}
