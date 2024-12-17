using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LimitPlanes : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    private List<ARPlane> planes = new List<ARPlane>();
    public TextMeshProUGUI debugMessage;

    private void OnEnable()
    {
        // 게임 오브젝트나 스크립트가 활성화될 때마다
        // 이벤트 핸들러 등록 
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    private void OnDisable()
    {
        // 게임 오브젝트나 스크립트가 비활성화될 때마다
        // 이벤트 핸들러 등록 해제
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }


    private void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // args.added : 추가된 평면들
        foreach (ARPlane plane in args.added)
        {
            planes.Add(plane);
        }
        if (planes.Count > 0)
        {
            arPlaneManager.enabled = false;
        }
        debugMessage.text = $"plane count: {planes.Count}";
    }

}
