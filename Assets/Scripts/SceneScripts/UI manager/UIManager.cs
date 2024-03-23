using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject welcomeUI; 
    public GameObject levelSelectionUI; 

    public Image levelImage; 
    public TextMeshProUGUI levelDescriptionText; 

    public Sprite[] levelSprites; 
    public string[] levelNames; 

    private int currentIndex = 0; 

    void Start()
    {
        welcomeUI.SetActive(true);
        levelSelectionUI.SetActive(false);
    }

    void Update()
    {
        if (levelSelectionUI.activeSelf)
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

    public void StartGame()
    {
        welcomeUI.SetActive(false);
        levelSelectionUI.SetActive(true);
        levelImage.gameObject.SetActive(true);
        UpdateLevelSelectionUI();
    }


    private void UpdateLevelSelectionUI()
    {
        levelImage.sprite = levelSprites[currentIndex];
        levelDescriptionText.text = "Level: " + levelNames[currentIndex];
    }


    public void SelectNextLevel()
    {
        currentIndex = (currentIndex + 1) % levelSprites.Length;
        UpdateLevelSelectionUI();
    }

    public void SelectPreviousLevel()
    {
        currentIndex = (currentIndex - 1 + levelSprites.Length) % levelSprites.Length;
        UpdateLevelSelectionUI();
    }

    public void LoadSelectedLevel()
    {
        SceneManager.LoadScene(currentIndex + 1); //Main Scene
    }
}
