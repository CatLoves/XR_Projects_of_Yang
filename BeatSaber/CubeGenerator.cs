using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public float cubeSpeed = 2;
    public List<Transform> cubePoints;

    public List<Cube> cubePrefabs;

    public List<float> timePoints;

    private int pointIndex = 0;

    private float timer = 0;

    private bool isStart = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart == false) return;
        timer += Time.deltaTime;
        if (timer >= timePoints[pointIndex])
        {
            GenerateCube();
            pointIndex++;
        }

        if (pointIndex > timePoints.Count - 1)
        {
            timer = 0;
            isStart = false;
        }
    }

    private void GenerateCube()
    {
        Cube cube = Instantiate(
            cubePrefabs[Random.Range(0, cubePrefabs.Count)],
            cubePoints[Random.Range(0, cubePoints.Count)].position,
            Quaternion.Euler(0, 0, 90*Random.Range(0,3))
        );
        cube.StartMove(param_speed: cubeSpeed);
    }
}
