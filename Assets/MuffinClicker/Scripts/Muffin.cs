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
    public int noOfClicks;
    public RectTransform muffinButton;
    
 
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
        noOfClicks++;
        totalMuffins += noOfMuffins;

        muffinText.color = Color.yellow;
        muffinText.DOColor(Color.white, 1f);

        //Grow the muffin slightly..
        muffinButton.DOPunchScale(Vector3.one * Random.Range(0.0f,0.5f), 0.5f);

        
        UpdateUI();
    }

    /// <summary>
    /// Critical Clicked Method
    /// </summary>
    public void OnCriticalClick()
    {

        //Extra Spicy Challenge
        //float OnePercentOfClicks = 1.0f / noOfClicks;
        float OnePercentOfClicks = (float)System.Math.Round(Random.value, 2);
         if (OnePercentOfClicks == 0.01f)
        {
            totalMuffins += 10 * noOfMuffins;
            UpdateUI();
        }
        
    }
}
