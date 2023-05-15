using System;
using Unity.VisualScripting;
using UnityEngine;


public class SubCube: MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }
}
