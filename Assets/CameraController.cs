using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> _playerList;

    public float averageXPosition;
    public float averageYPosition;
    public float averageZPosition;

    private Vector3 _cameraBasePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cameraBasePosition = transform.position;
    }

    public void SetPlayerList(List<GameObject> playerList)
    {
        _playerList = playerList;
    }

    // Update is called once per frame
    void Update()
    {
        SetCameraPosition();
    }

    private void SetCameraPosition()
    {
        averageXPosition = 0f;
        averageYPosition = 0f;
        averageZPosition = 0f;

        foreach (GameObject player in _playerList)
        {
            averageXPosition += player.transform.position.x;
            averageYPosition += player.transform.position.y;
            averageZPosition += player.transform.position.z;
        }

        if (_playerList.Count != 0)
        {
            averageXPosition /= _playerList.Count;
            averageYPosition /= _playerList.Count;
            averageZPosition /= _playerList.Count;
        }

        transform.position = new Vector3(averageXPosition, averageYPosition, averageZPosition) + _cameraBasePosition;
    }
}
