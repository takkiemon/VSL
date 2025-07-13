using NDream.AirConsole;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class MessageReceiver : MonoBehaviour
{
    void Start()
    {
        AirConsole.instance.onMessage += OnMessage;
    }

    void OnMessage(int from, JToken data)
    {
        AirConsole.instance.Message(from, "Full of pixels!");
        Debug.Log("Message received from device " + from + ": " + data);
    }
}
