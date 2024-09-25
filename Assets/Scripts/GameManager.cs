using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject characterPrefab;
    public Cinemachine.CinemachineVirtualCamera cinemachineVirtualCamera;

    void Start()
    {
        GameObject character = Instantiate(characterPrefab);
        cinemachineVirtualCamera.Follow = character.transform;
    }

}
