using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

[Serializable]
public class Primary2DAxisEvent : UnityEngine.Events.UnityEvent<Vector2> { }

public class PrimaryAxisWatcher : MonoBehaviour
{
    public Primary2DAxisEvent primary2DAxisEvent;
    
    private Vector2 _lastPrimary2DAxisValue;
    private List<InputDevice> _deviceWithPrimary2DAxis;
    
    private void Awake()
    {
        if (primary2DAxisEvent == null)
        {
            primary2DAxisEvent = new Primary2DAxisEvent();
        }
        _deviceWithPrimary2DAxis = new List<InputDevice>();
    }

    private void OnEnable()
    {
        var allDevices = new List<InputDevice>();
        // 右手デバイスのみ取得
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, allDevices);
        
        InputDevices.GetDevices(allDevices);
        foreach(var device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        _deviceWithPrimary2DAxis.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out var discardedValue))
        {
            _deviceWithPrimary2DAxis.Add(device);
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (_deviceWithPrimary2DAxis.Contains(device))
            _deviceWithPrimary2DAxis.Remove(device);
    }
    
    private void Update()
    {
        foreach (var device in _deviceWithPrimary2DAxis)
        {
            // deviceのprimary2DAxisの値を取得
            if (!device.TryGetFeatureValue(CommonUsages.primary2DAxis, out var tempState)) continue;
            // 値が変化していたらイベントを発行
            if(tempState == _lastPrimary2DAxisValue) continue;
            if (tempState.magnitude is not (0 or 1)) continue;
            primary2DAxisEvent.Invoke(tempState);
            _lastPrimary2DAxisValue = tempState;
        }
    }
}
