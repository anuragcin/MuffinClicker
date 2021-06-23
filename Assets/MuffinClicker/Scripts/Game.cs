using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{

    public int totalMuffins;
    public int muffinsPerClick = 1;
    public AudioClip muffinClickSound;
    public FloatingText floatingTextPrefab;
    public Transform floatingTextContainer;
    public float criticalClickChance = 0.01f;
    public int criticalClickMultiplier = 10;

    private AudioSource audioSource;
    private HeaderUI headerUI;
    

    private void Awake()
    {
        headerUI = FindObjectOfType<HeaderUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void OnMuffinCollected()
    {
        //Critical Clicks

        bool isCritical = false;
        int numMuffinCollected = muffinsPerClick;

        if (Random.value < criticalClickChance)
        {
            isCritical = true;
            numMuffinCollected = muffinsPerClick * criticalClickMultiplier;
           
        }

        totalMuffins += numMuffinCollected;


        CreateFloatingText("+" + numMuffinCollected, isCritical);
        headerUI.FlashMuffinText();

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

        floatingText.GetComponent<FloatingText>().SetMessage(message,isImportant);

        
    }

    private Vector2 GetRandomFloatingTextPosition()
    {
        // Generate a random X and Y position
        float x = Random.Range(-200f, 200f);
        float y = Random.Range(75f, 225f);

        // Create and return a new Vector2 using those X and Y positions
        return new Vector2(x, y);
    }

    
}

