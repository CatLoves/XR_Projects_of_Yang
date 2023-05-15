using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartMove(float param_speed)
    {
        speed = param_speed;
    }

    // Update is called once per frame
    public float speed = 1;
    public int frame_index = 0;
    void Update()
    {
        // 终止条件：如果方块跑到人后方了，自动消失
        if (transform.position.z < -3)
        {
            Destroy(gameObject);
        }
        float delta_time = Time.deltaTime;

        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z - delta_time * speed
        );
        
    }
}
