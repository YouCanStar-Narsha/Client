using UnityEngine;

public class GyroManager : MonoBehaviour
{
    private void Update()
    {
        if (SystemInfo.supportsGyroscope)
        {
            Gyroscope gyro = Input.gyro;
            gyro.enabled = true;

            transform.rotation = gyro.attitude;
        }
    }
}
