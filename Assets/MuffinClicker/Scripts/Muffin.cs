using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Muffin : MonoBehaviour
{
    public int totalMuffins;
    public TMP_Text muffinText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMuffin();
    }

    // Update is called once per frame
    void Update()
    {
        
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
