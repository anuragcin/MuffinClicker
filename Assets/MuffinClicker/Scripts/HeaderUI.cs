using DG.Tweening;
using TMPro;
using UnityEngine;

public class HeaderUI : MonoBehaviour
{
    public TMP_Text muffinText;
    private Game game;

    public void Awake()
    {
        game = FindObjectOfType<Game>();
    }
    /// <summary>
    /// Update UI
    /// </summary>
    public void Update()
    {
        //Extra Challenge
        var txtMuffin = string.Empty;

        if (game.totalMuffins == 1)
        {
            txtMuffin = "muffin";
        }
        else
        {
            txtMuffin = "muffins";
        }

        muffinText.text = game.totalMuffins + txtMuffin;
    }

    /// <summary>
    /// Flashing the Muffin Text 
    /// </summary>
    public void FlashMuffinText()
    {
        muffinText.color = Color.yellow;
        muffinText.DOColor(Color.white, 1f);
    }
}
