using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoxController : MonoBehaviour
{
    public Material highlight_material;
    public GameObject cube;
    public void OnHoverEnter(XRBaseInteractor interactor)
    {
        Debug.Log("==> Box OnHoverEnter() invoked.");
        cube.GetComponent<MeshRenderer>().material = highlight_material;
    }
}