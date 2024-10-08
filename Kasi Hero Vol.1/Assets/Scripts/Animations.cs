using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject CD;

    // Rotate speed
    public float rotationSpeed;

    private void Update()
    {
        CD.transform.Rotate(new Vector3(0, 0, -rotationSpeed) * Time.deltaTime);
    }
}
