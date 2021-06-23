using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public int totalMuffins;
    public AudioClip muffinClickSound;
    public int muffinsPerClick = 1;
    public FloatingText floatingTextPrefab;
    public Transform floatingTextContainer;
    public float criticalClickChance = 0.01f;
    public int criticalClickMultiplier = 10;

    private HeaderUI headerUI;
    private AudioSource audioSource;

    private void Awake()
    {
        headerUI = FindObjectOfType<HeaderUI>();
        audioSource = GetComponent<AudioSource>();

        // Load the game
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        // Save our game
        SaveGame();
    }

    public void OnMuffinCollected()
    {
        bool isCritical = false;
        int numMuffinsCollected = muffinsPerClick;

        // Handle critical clicks
        if(Random.value < criticalClickChance)
        {
            isCritical = true;
            numMuffinsCollected = muffinsPerClick * criticalClickMultiplier;
        }

        // Award the collected muffins
        totalMuffins += numMuffinsCollected;

        // Create a floating text displaying the number of muffins collected
        // TODO: Maybe this floating text creation can be refactored elsewhere?
        CreateFloatingText("+" + numMuffinsCollected, isCritical);

        // Flash the muffins text
        headerUI.FlashMuffinText();

        // Play the muffin click sound
        audioSource.PlayOneShot(muffinClickSound);
    }

    private void CreateFloatingText(string message, bool isImportant)
    {
        // Calculate a random position for the floating text
        Vector2 randomPosition = GetRandomFloatingTextPosition();

        // Spawn a new floating text
        FloatingText floatingText = Instantiate(floatingTextPrefab, floatingTextContainer);

        // Position the new floating text at the random position
        floatingText.transform.localPosition = randomPosition;

        // Set the floating text's message
        floatingText.SetMessage(message, isImportant);
    }

    private Vector2 GetRandomFloatingTextPosition()
    {
        // Generate a random X and Y position
        float x = Random.Range(-200f, 200f);
        float y = Random.Range(75f, 225f);

        // Create and return a new Vector2 using those X and Y positions
        return new Vector2(x, y);
    }

    private void Update()
    {
        // If F12 is pressed
        if(Input.GetKeyDown(KeyCode.F12))
        {
            ResetGame();
        }
    }

    private void ResetGame()
    {
        totalMuffins = 0;
    }

    private void SaveGame()
    {
        // Create a SaveData object
        SaveData saveData = new SaveData();

        // Populate the save data with the current game's data
        saveData.totalMuffins = totalMuffins;

        // Convert that save data object into JSON
        string saveDataJSON = JsonUtility.ToJson(saveData);
        Debug.Log(saveDataJSON);

        // Save the JSON string to PlayerPrefs (NOTE: this could be saved to anywhere however)
        PlayerPrefs.SetString("savegame", saveDataJSON);
    }

    private void LoadGame()
    {
        // Get the JSON save data string from PlayerPrefs (NOTE: this could be loaded from anywhere however)
        string saveDataJSON = PlayerPrefs.GetString("savegame", "{}");
        Debug.Log(saveDataJSON);

        // Deserialize the JSON into the save data object
        SaveData saveData = JsonUtility.FromJson<SaveData>(saveDataJSON);

        // Set the current game state to use the saved values
        totalMuffins = saveData.totalMuffins;
    }
}

public class SaveData
{
    public int totalMuffins;
}