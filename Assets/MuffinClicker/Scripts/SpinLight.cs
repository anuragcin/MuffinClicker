using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLight : MonoBehaviour
{
    private float speed;
    public float minSpeed;
    public float maxSpeed;

    public void Start()
    {
        speed = Random.Range(minSpeed,maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
