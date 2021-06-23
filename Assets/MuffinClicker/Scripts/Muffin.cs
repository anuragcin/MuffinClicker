using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;


public class Muffin : MonoBehaviour
{
    public int totalMuffins;
    public TMP_Text muffinText;
    public RectTransform[] spinLight;
    public float[] spinLightSpeed;
    public int noOfMuffins;
    public RectTransform muffinButton;
    public int muffinsPerClick = 1;
    public GameObject floatingTextPrefab;


    // Start is called before the first frame update
    void Start()
    {
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
      

        for(int indx = 0; indx < spinLight.Length; indx++)
        {
            spinLight[indx].Rotate(0, 0, spinLightSpeed[indx] * Time.deltaTime);
        }
        
    }

    /// <summary>
    /// Update UI
    /// </summary>
    private void UpdateUI()
    {
        //Extra Challenge
        var txtMuffin = string.Empty;

        if (totalMuffins == 1)
        {
            txtMuffin = "muffin";
        }
        else
        {
            txtMuffin = "muffins";
        }

        muffinText.text = totalMuffins + txtMuffin;
    }

    /// <summary>
    /// Muffin Clicked Method
    /// </summary>
    public void OnMuffinClicked()
    {
        totalMuffins += noOfMuffins;

        muffinText.color = Color.yellow;
        muffinText.DOColor(Color.white, 1f);

        //Grow the muffin slightly..
        muffinButton.DOPunchScale(Vector3.one * Random.Range(0.0f,0.5f), 0.5f);

        // Create a floating text displaying the number of muffins collected
        CreateFloatingText("+" + muffinsPerClick);

        UpdateUI();
    }

    private void CreateFloatingText(string message)
    {
        // Calculate a random position for the floating text
        Vector2 randomPosition = GetRandomFloatingTextPosition();

        // Spawn a new floating text
        GameObject floatingText = Instantiate(floatingTextPrefab, transform);

        // Position the new floating text at the random position
        floatingText.transform.localPosition = randomPosition;

        // Set the floating text's text to the passing in message
        floatingText.GetComponent<TMP_Text>().text = message;
    }

    private Vector2 GetRandomFloatingTextPosition()
    {
        // Generate a random X and Y position
        float x = Random.Range(-200f, 200f);
        float y = Random.Range(75f, 225f);

        // Create and return a new Vector2 using those X and Y positions
        return new Vector2(x, y);
    }


    /// <summary>
    /// Critical Clicked Method
    /// </summary>
    public void OnCriticalClick()
    {

        //Extra Spicy Challenge
        float OnePercentOfClicks = Random.value;
         if (OnePercentOfClicks >= 0.99) //1%
        {
            totalMuffins += 10 * noOfMuffins;
            // Create a floating text displaying Critical Clicked
            CreateFloatingText("Critical Clicked");
            UpdateUI();
        }
        
    }
}
