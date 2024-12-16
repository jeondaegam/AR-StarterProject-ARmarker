using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPopup : MonoBehaviour
{

    // 팝업 버튼
    public Button buttonPopup;
    private Canvas canvasPopup;

    private Camera mainCamera;

    private void Start()
    {
        buttonPopup.onClick.AddListener(TogglePopup);
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (canvasPopup == null)
        {
            // ModelObject가 존재할 때만 찾기 (한 번, != null)
            if (GameObject.FindWithTag("ModelObject")) 
            {
                canvasPopup = GameObject.FindWithTag("ModelObject")
                    .GetComponentInChildren<Canvas>(true);
            }
        }

        if (canvasPopup)
        {
            // TODO 빌드해서 둘이 다른지 비교해보기 
            //canvasPopup.transform.LookAt(mainCamera.transform);


            // canvasPopup을 카메라를 바라보게 설정
            //Vector3 direction = mainCamera.transform.position - canvasPopup.transform.position;
            //direction.y = 0;  // y축 회전을 방지하려면 y값을 0으로 설정
            //canvasPopup.transform.rotation = Quaternion.LookRotation(direction);


            //좌우 반전 되어서 direction 벡터의 부호를 반대로 해주기 : 좌우반전은 해결되지만 상하가 반전됨 
            Vector3 direction = canvasPopup.transform.position - mainCamera.transform.position; // 카메라에서 Popup을 바라보는 방향으로 변경
            direction.y = 0;  // y축 회전을 방지하려면 y값을 0으로 설정
            canvasPopup.transform.rotation = Quaternion.LookRotation(direction);

            //Vector3 direction = mainCamera.transform.position - canvasPopup.transform.position;
            //direction.y = 0;
            //canvasPopup.transform.LookAt(mainCamera.transform); // 카메라를 향하게 설정
            //canvasPopup.transform.rotation = Quaternion.Euler(0, canvasPopup.transform.rotation.eulerAngles.y, 0); // x, z축 회전은 0으로 설정

        }
    }

    private void TogglePopup()
    {
        // 현재 상태의 반대값으로 설정한다. On => Off , Off => On
        if (canvasPopup != null)
        {
            canvasPopup.gameObject.SetActive(!canvasPopup.gameObject.activeSelf);
        }
    }

}
