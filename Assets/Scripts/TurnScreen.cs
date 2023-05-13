using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnScreen : MonoBehaviour
{
    public void Portrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void LandscapeLeft()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
}
