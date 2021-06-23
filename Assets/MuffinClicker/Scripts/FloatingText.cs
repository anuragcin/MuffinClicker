using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float speed;
    public float fadeDuration = 5f;

    private float age = 0;
    private Color initialColour;

    void Start()
    {
        initialColour = GetComponent<TMP_Text>().color;
    }

    void Update()
    {
        // Float upwards
        transform.Translate(0f, speed * Time.deltaTime, 0);

        // Fade out over time
        age += Time.deltaTime;
        GetComponent<TMP_Text>().color = Color.Lerp(initialColour, Color.clear, age / fadeDuration);

        // When completely faded out
        if(age > fadeDuration)
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }
}
