using UnityEngine;
using ArduinoBluetoothAPI;
using System;
using System.Collections.Generic;

public class BTManagerRespirometer : MonoBehaviour
{
    public BluetoothHelper helper;
    private string deviceName;
    public List<float> volArray = new();

    void Start()
    {
        deviceName = "HC-05";

        try
        {
            BluetoothHelper.BLE = false;
            helper = BluetoothHelper.GetInstance(deviceName);
            helper.OnConnected += Onconnected;
            helper.OnConnectionFailed += OnConnFailed;
            helper.OnDataReceived += OnMessageReceived;

            helper.setTerminatorBasedStream(";");

            if (helper.isDevicePaired())
            {
                helper.Connect();
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    private void OnConnFailed(BluetoothHelper helper)
    {
        Debug.Log("failed");
        throw new Exception("Conexão falhou");
    }

    private void Onconnected(BluetoothHelper helper)
    {
        helper.StartListening();
        FindObjectOfType<Toast>().ShowToast();
        Debug.Log("connected");
    }

    void OnMessageReceived(BluetoothHelper helper)
    {
        float msg = float.Parse(helper.Read());


        if (msg > 0)
        {
            msg /= 20;
            volArray.Add(msg);
        }

        msg *= 20;
        msg *= 0.001f;
        FindObjectOfType<PlayerController>().strength = Math.Abs(msg);
    }

    private void OnDestroy()
    {
        if (helper != null)
        {
            Debug.Log("disconnected");
            helper.Disconnect();
        }
    }
}
