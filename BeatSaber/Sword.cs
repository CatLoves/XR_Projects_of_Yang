using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class Sword : MonoBehaviour
{
    public Material sliceMaterial;

    public LayerMask layer;

    public float rayDistance = 1.8f; // 光剑的长度，默认是 1.8 m

    public Vector3 previousPos;

    public Vector3 pointPosTemp;

    public RaycastHit hit;

    public XRController xrController;

    public DataBoardController databoardController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // 挥砍的方向
        Vector3 move_direc = transform.position - previousPos;
        // 碰撞的点
        var hitPos = other.bounds.ClosestPoint(transform.position);
        var result = SliceUtil.slice(other.gameObject, hitPos, transform.right, sliceMaterial);
        Destroy(other.gameObject);

        if (result.Length == 2)
        {
            for (int i = 0; i < result.Length; i++)
            {
                result[i].AddComponent<SubCube>();
                result[i].AddComponent<Rigidbody>();
            }
            result[0].GetComponent<Rigidbody>().drag = 10;
            LogController.LogError("result size: " + result.Length);
        }
        else
        {
            LogController.LogError("result size: " + result.Length);
        }

        // bool rs = xrController.inputDevice.SendHapticImpulse(0,1, (float)0.5);
        // if (rs == false)
        // {
        //     LogController.LogWarning("=> SendHapticImpulse failure !");
        // }
        // else
        // {
        //     LogController.LogWarning("=> SendHapticImpulse succeed !");
        // }
        //
        // // 更新数据
        // try
        // {
        //     databoardController.score_add();
        //     databoardController.continue_cnt_add();
        // }
        // catch (Exception e)
        // {
        //     LogController.LogError("databoardController is empty.");
        //     LogController.LogError("Exception: " + e);
        // }
        //
        // // debug
        // LogController.LogWarning("=> Collision detected, slice direction: " + transform.right);
        // LogController.LogWarning("=> move_direc: " + move_direc);
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // pointPosTemp: 光剑顶点的世界坐标系坐标
    //     pointPosTemp = transform.TransformPoint(new Vector3(0, 0, rayDistance));
    //     // 重要函数，检测手柄射线是否与其他物体存在碰撞   https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
    //     if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, layer))
    //     {
    //         Box box = hit.collider.GetComponent<Box>();
    //         // SendHapticImpulse: 让手柄震动 0.5 秒，震动幅度是 1 单位
    //         xrController.SendHapticImpulse(1, (float)0.5);
    //     }
    //
    //     previousPos = transform.position;
    // }
}
