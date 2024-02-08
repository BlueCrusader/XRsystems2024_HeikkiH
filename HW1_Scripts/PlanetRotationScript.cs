using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotationScript : MonoBehaviour
{
    public float planetRotationRate = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, planetRotationRate * Time.deltaTime, 0);
    }
}
