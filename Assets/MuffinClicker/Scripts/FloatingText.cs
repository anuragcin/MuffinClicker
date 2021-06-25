using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloatingText : MonoBehaviour
{
    public float speed;
    public float fadeDuration = 5f;

    private float age = 0;
    private Color initialColour;

    public float minSpeed = 10;
    public float maxSpeed = 60;

    public void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
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

    public void SetMessage(string message, bool isImportant)
    {
        TMP_Text label = GetComponent<TMP_Text>();
        // Set the floating text's text to the passing in message
        label.text = message;

        if (isImportant)
        {
            label.color = Color.yellow;
            label.fontSize = 75f;
        }
    }
}
