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
            helper = BluetoothHelper.GetInstance(deviceName);
            helper.OnConnected += Onconnected;
            helper.OnConnectionFailed += OnConnFailed;

            helper.setTerminatorBasedStream(";"); //verificar se isso é necessário

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
        Debug.Log("connected");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (helper != null)
        {
            if (helper.Available)
            {
                float msg = float.Parse(helper.Read());

                if (msg != 0)
                {
                    volArray.Add(msg);
                }

                msg *= 0.001f;
                Debug.Log(Math.Abs(msg));
                FindObjectOfType<PlayerController>().strength = Math.Abs(msg);
            }
        }
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
