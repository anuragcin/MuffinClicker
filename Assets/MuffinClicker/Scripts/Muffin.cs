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
        muffinText.text = totalMuffins + " muffins";
    }

    public void OnMuffinClicked()
    {
        totalMuffins += 1;
        UpdateMuffin();
    }
}
