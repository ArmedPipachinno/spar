using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] float cameraSpeed;

    private Vector2 posMax;

    // Start is called before the first frame update
    void Start()
    {
        posMax = GetComponent<MapGenerator>().GetMapSize();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        /*
        if (Input.GetKey(KeyCode.W))
        {
            mainCamera.transform.Translate(Vector3.up * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            mainCamera.transform.Translate(Vector3.down* cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            mainCamera.transform.Translate(Vector3.left * cameraSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mainCamera.transform.Translate(Vector3.right * cameraSpeed * Time.deltaTime);
        }
        */

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mainCamera.transform.localRotation = Quaternion.Euler(0, 0, mainCamera.transform.localRotation.z - 90);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            mainCamera.transform.localRotation = Quaternion.Euler(0, 0, mainCamera.transform.localRotation.z + 90);
        }
    }

}
