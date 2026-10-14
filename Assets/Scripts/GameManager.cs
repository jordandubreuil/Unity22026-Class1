using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set;}

    [Header("UI Elements")]
    public TMP_Text pickupCountText;
    public GameObject winPanel;

    [Header("Pickups")]
    public int totalPickups = 5;
    public int collectedCount = 0;

    bool _gameOver = false;

    private void Awake()
    {
        //Checks to see if the Game Manager exists
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //If we want this to persisit between scenes - Use this code
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGoalReached()
    {
        if (_gameOver) { return; }

        _gameOver = true;

        if(winPanel != null)
        {
            winPanel.SetActive(true);
            winPanel.GetComponentInChildren<TMP_Text>().text = "You got all the Items and made it to the goal";
        }
    }


    public void OnPickUpCollected()
    {
        if(_gameOver)return;

        collectedCount++;
        UpdateUI();
    }

    void UpdateUI()
    {
        if(pickupCountText != null)
        {
            pickupCountText.text = $"Items: {collectedCount}/{totalPickups}";
        }
    }
}
