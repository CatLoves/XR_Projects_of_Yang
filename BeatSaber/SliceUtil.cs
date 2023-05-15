using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine;

public class SliceUtil : MonoBehaviour
{
    public static GameObject[] slice(GameObject sourceGo, Vector3 slicePos, Vector3 sliceDirect, Material sectionMat)
    {
        var result = new GameObject[2];
        SlicedHull hull = sourceGo.Slice(slicePos, sliceDirect);
        result[0] = hull.CreateUpperHull(sourceGo, sectionMat);
        result[1] = hull.CreateLowerHull(sourceGo, sectionMat);

        return result;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
