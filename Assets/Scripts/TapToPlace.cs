using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class TapToPlace : MonoBehaviour
{
    /**
     * Detects touch on an AR plane and places a portal object.
     */
    [Tooltip("터치 된 위치를 표시하는 텍스트")]
    public TextMeshProUGUI debugText;
    [Tooltip("터치된 영역에 나타낼 손가락 모양 UI")]
    public Image touchPoint;

    public ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

    // 포털 인스턴싱 하기
    private ARPlane arPlane; // get position, rotation
    public GameObject portalPrefab;
    [Tooltip("포털이 나타났는지 체크하는 변수")]
    private bool isPortalSpawned;

    // 8. 포털 생성 후 모든 평면 비활성화하기
    public ARPlaneManager arPlaneManager; // 일단 직접 레퍼런싱 해보자

     

    void Start()
    {
        debugText.text = "👉 Move the camera slowly to detect a horizontal surface! 😊";
    }

    void Update()
    {

        //if (arPlane == null)
        //{
        //    arPlane = FindObjectOfType<ARPlane>();
        //    Instantiate(portalPrefab, arPlane.transform.position, arPlane.transform.rotation);
        //}

        if (!isPortalSpawned)
        {

            // 터치가 감지 되었을 때만 실행
            if (Input.touchCount > 0)
            {
                // 터치포인트 오브젝트 활성화
                if (!touchPoint.gameObject.activeSelf)
                {
                    touchPoint.gameObject.SetActive(true);
                }

                // 첫 번째 터치 정보를 가져옴 
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = touch.position;

                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    // Ray를 쏜다 
                    bool hitDetected = arRaycastManager.Raycast(touchPosition, hitResults,
                        UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);

                    if (hitDetected)
                    {
                        // Raycast 결과에서 첫 번째 감지된 평면 정보 가져오기
                        Pose hitPose = hitResults[0].pose;

                        // 포털 생성
                        Instantiate(portalPrefab, hitPose.position, hitPose.rotation);
                        isPortalSpawned = true;

                        // 기존에 감지된 다른 평면을 비활성화 
                        arPlaneManager.SetTrackablesActive(false);

                        // AR Plane Manager 컴포넌트를 비활성화 
                        arPlaneManager.enabled = false;

                        debugText.text = "Spawn Portal!";
                    }
                    else
                    {
                        debugText.text = "No hit.";
                    }

                }


                // 터치 정보 UI 표시
                // 터치된 위치 좌표를 가져옴
                //Vector2 touchPosition = touch.position;
                // 터치된 좌표를 텍스트 UI에 표시
                //debugText.text = $"touch position X:{touchPosition.x}, Y:{touchPosition.y}";
                // 이미지 표시
                // 터치 포인트를 표시하려면 스크린 좌표(픽셀단위)를 가져와야 하기 때문에 Input.GetTouch()의 position값을 사용한다 . 
                touchPoint.transform.position = touch.position;

            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                arPlane = FindObjectOfType<ARPlane>();
                Instantiate(portalPrefab, arPlane.transform.position, arPlane.transform.rotation);
                arPlaneManager.SetTrackablesActive(false);
                // AR Plane Manager 컴포넌트를 비활성화 
                arPlaneManager.enabled = false;
                debugText.text = "Portal Spawned!";
            }

        }
    }

    //private void DisplayTouchPoint()
    //{
    //    // 첫 번째 터치 정보를 가져옴 
    //    Touch touch = Input.GetTouch(0);
    //    // 터치된 위치 좌표를 가져옴
    //    Vector2 touchPosition = touch.position;
    //    // 터치된 좌표를 텍스트 UI에 표시
    //    debugText.text = $"touch position X:{touchPosition.x}, Y:{touchPosition.y}";

    //    // 이미지 표시
    //    touchPoint.transform.position = touch.position;
    //}
}
