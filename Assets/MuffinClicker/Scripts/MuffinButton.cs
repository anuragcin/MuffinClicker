using DG.Tweening;
using UnityEngine;


public class MuffinButton : MonoBehaviour
{
    public RectTransform muffinButton;

    private Tweener muffinButtonTween;
    private Game game;

    public void Awake()
    {
        game = FindObjectOfType<Game>();
    }

    /// <summary>
    /// Muffin Clicked Method
    /// </summary>
    public void OnMuffinClicked()
    {
        //Let a game know a muffin was clicked
        game.OnMuffinCollected();

        muffinButtonTween.Rewind();
        //Grow the muffin slightly..
        muffinButtonTween = muffinButton.DOPunchScale(Vector3.one * Random.Range(0.0f,0.5f), 0.5f);
    }
}
