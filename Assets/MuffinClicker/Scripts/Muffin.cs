using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Muffin : MonoBehaviour
{
    public int totalMuffins;
    public TMP_Text muffinText;
    public RectTransform[] spinLight;
    public float[] spinLightSpeed;
    public int noOfMuffins;
    public float qualityAward;
    public int noOfClicks;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMuffin();
    }

    // Update is called once per frame
    void Update()
    {
      

        for(int indx = 0; indx < spinLight.Length; indx++)
        {
            spinLight[indx].Rotate(0, 0, spinLightSpeed[indx] * Time.deltaTime);
        }
        
    }

    private void UpdateMuffin()
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

        if (noOfClicks > qualityAward)
        {
            qualityAward = Time.time + 0.01f;

            totalMuffins += 10 * noOfMuffins;
        }

        muffinText.text = totalMuffins + txtMuffin;
    }

    public void OnMuffinClicked()
    {
        noOfClicks++;
        totalMuffins += noOfMuffins;
        UpdateMuffin();
    }
}
