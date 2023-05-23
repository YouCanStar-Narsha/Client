using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class BluetoothController : MonoBehaviour
{
    public string deviceName = "MyBluetoothDevice";
    public int baudRate = 9600;
    private SerialPort serialPort;

    void Start()
    {
        string[] ports = SerialPort.GetPortNames();
        foreach (string port in ports)
        {
            if (port.Contains("Bluetooth") && port.Contains(deviceName))
            {
                serialPort = new SerialPort(port, baudRate);
                serialPort.ReadTimeout = 1000;
                serialPort.Open();
                break;
            }
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen && serialPort.BytesToRead > 0)
        {
            string data = serialPort.ReadLine();
            Debug.Log("Received data from Bluetooth device: " + data);
        }
    }

    public void SendData(string data)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Write(data);
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}