//To Enable the camera in unity Netcode (The camera must be disbled)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkCamera : NetworkBehaviour
{
    public GameObject Camera;
    void Start()
    {
        if (IsLocalPlayer)
        {
            StartCoroutine(Delay(0.1f));
        }
    }

    IEnumerator Delay(float time)
    {
        yield return new WaitForSeconds(time);

        Camera.SetActive(true);
    }
}
