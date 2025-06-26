using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfWorldBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            ConsoleLogger.Instance.MakeLog("Player fell out of defined bounds, press 'R' to reset.", LogType.Warning);
    }
}
