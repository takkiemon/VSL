#if !DISABLE_AIRCONSOLE
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using System;

public class VSLGameController : MonoBehaviour
{
    public GameObject playerPrefab;
    public CameraController mainCamera;
    public Dictionary<int, VSLPlayerController> players = new Dictionary<int, VSLPlayerController>();

    private List<GameObject> _playerObjectList = new List<GameObject>();

    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onReady += OnReady;
        AirConsole.instance.onConnect += OnConnect;
    }

    void OnReady(string code)
    {
        //Since people might be coming to the game from the AirConsole store once the game is live,
        //I have to check for already connected devices here and cannot rely only on the OnConnect event
        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
        foreach (int deviceID in connectedDevices)
        {
            AddNewPlayer(deviceID);
        }
    }

    void OnConnect(int device)
    {
        AddNewPlayer(device);
    }

    private void AddNewPlayer(int deviceID)
    {
        if (players.ContainsKey(deviceID))
        {
            return;
        }

        //Instantiate player prefab, store device id + player script in a dictionary
        GameObject newPlayer = Instantiate(playerPrefab, transform.position, transform.rotation) as GameObject;
        players.Add(deviceID, newPlayer.GetComponent<VSLPlayerController>());
        _playerObjectList.Add(newPlayer);
        var newPlayerList = new List<GameObject>(_playerObjectList);
        mainCamera.SetPlayerList(newPlayerList);
    }

    void OnMessage(int from, JToken data)
    {
        //When I get a message, I check if it's from any of the devices stored in my device Id dictionary
        if (players.ContainsKey(from) && data["action"] != null)
        {
            //I forward the command to the relevant player script, assigned by device ID
            players[from].ButtonInput(data["action"].ToString());
        }
    }

    void OnDestroy()
    {
        if (AirConsole.instance != null)
        {
            AirConsole.instance.onMessage -= OnMessage;
            AirConsole.instance.onReady -= OnReady;
            AirConsole.instance.onConnect -= OnConnect;
        }
    }

    private void OnDrawGizmos()
    {
        // This Gizmo draws a cube at the spawn position of the players
        Gizmos.DrawCube(transform.position, new Vector3(.5f, .5f, .5f));
    }
}
#endif