using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RequestPermissions : MonoBehaviour
{
    [SerializeField] private GameObject sceneParentObject;

    private void Start()
    {
        StartCoroutine(RequestWebCamPermission());
    }

    private IEnumerator RequestWebCamPermission()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.Log("webcam found");
            EnableScene();
        }
        else
        {
            Debug.Log("webcam not found");
            Application.Quit();
        }
    }

    private void EnableScene()
    {
        sceneParentObject.SetActive(true);
    }
}