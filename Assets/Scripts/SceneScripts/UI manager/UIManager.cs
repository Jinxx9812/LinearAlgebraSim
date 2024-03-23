using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Import the namespace for TextMeshPro

public class UIManager : MonoBehaviour
{
    public GameObject welcomeUI; // Reference to the welcome UI
    public GameObject levelSelectionUI; // Reference to the level selection UI

    public Image levelImage; // Reference to the central level image
    public TextMeshProUGUI levelDescriptionText; // Reference to the level description text with TextMeshPro

    public Sprite[] levelSprites; // Assign the level sprites in the Inspector
    public string[] levelNames; // Assign the level names in the Inspector

    private int currentIndex = 0; // Index to navigate through levels

    void Start()
    {
        // Initially, only show the welcome screen and hide the level selection
        welcomeUI.SetActive(true);
        levelSelectionUI.SetActive(false);
    }

    void Update()
    {
        // Check keyboard input to change levels
        if (levelSelectionUI.activeSelf) // Only if the level selector is active
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                SelectNextLevel();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                SelectPreviousLevel();
            }
        }
    }

    // Method to start the game and show the level selector
    public void StartGame()
    {
        welcomeUI.SetActive(false);
        levelSelectionUI.SetActive(true);
        levelImage.gameObject.SetActive(true); // Activar el GameObject de ImageLevel
        UpdateLevelSelectionUI();
    }


    // Update the level selector UI with the corresponding image and name for the current level
    // Update the level selector UI with the corresponding image and name for the current level
    private void UpdateLevelSelectionUI()
    {
        levelImage.sprite = levelSprites[currentIndex];
        levelDescriptionText.text = "Level: " + levelNames[currentIndex]; // Concatenate "Level: " with the level name
    }


    // Method to select the next level
    public void SelectNextLevel()
    {
        currentIndex = (currentIndex + 1) % levelSprites.Length;
        UpdateLevelSelectionUI();
    }

    // Method to select the previous level
    public void SelectPreviousLevel()
    {
        currentIndex = (currentIndex - 1 + levelSprites.Length) % levelSprites.Length;
        UpdateLevelSelectionUI();
    }

    // Method to load the selected level
    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene(currentIndex + 1); // Assumes index 0 is the Main Scene
    }
}
