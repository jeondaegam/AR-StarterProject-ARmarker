using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateObject : MonoBehaviour
{
    private GameObject modelObject;

    [Header("Rotate")]
    public Button buttonRotatLeft;
    public Button buttonRotateRight;

    [Header("Auto Rotate")]
    public Button buttonAutoRotateLeft;
    public Button buttonAutoRotateRight;

    [Header("Position")]
    public Button buttonPositionUp;
    public Button buttonPositionDown;

    // 회전중 여부를 체크 
    private bool isAutoRotateLeft;
    private bool isAutoRotateRight;

    // Start is called before the first frame update
    void Start()
    {

        buttonRotateRight.onClick.AddListener(RotateRight);
        buttonRotatLeft.onClick.AddListener(RotateLeft);

        buttonPositionUp.onClick.AddListener(PositionUp);
        buttonPositionDown.onClick.AddListener(PositionDown);

        buttonAutoRotateLeft.onClick.AddListener(AutoRotateLeft);
        buttonAutoRotateRight.onClick.AddListener(AutoRotateRight);

    }


    private void Update()
    {
        if (modelObject == null)
        {
            modelObject = GameObject.FindWithTag("ModelObject");
        }

        if (isAutoRotateLeft)
        {
            modelObject.transform.Rotate(0, 1, 0);
        }

        if(isAutoRotateRight)
        {
            modelObject.transform.Rotate(0, -1, 0);
        }

    }


    private void AutoRotateRight()
    {
        isAutoRotateRight = !isAutoRotateRight;
        isAutoRotateLeft = false;
    }

    private void AutoRotateLeft()
    {
        isAutoRotateLeft = !isAutoRotateLeft;
        isAutoRotateRight = false;
    }

    private void PositionUp()
    {
        modelObject.transform.Translate(Vector3.forward * .1f);
    }

    private void PositionDown()
    {
        modelObject.transform.Translate(Vector3.forward * -.1f);
    }


    private void RotateRight()
    {
        modelObject.transform.Rotate(0, -15, 0);
    }

    private void RotateLeft()
    {
        modelObject.transform.Rotate(0, 15, 0);
    }



}
