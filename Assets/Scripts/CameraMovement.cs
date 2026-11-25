using UnityEngine;

public class CameraMovement:MonoBehaviour
{
    public Transform playerTransform;
    private Transform _cameraTransforml;
    void Start ()
    {
        _cameraTransforml = GetComponent<Transform>();
    }
    void Update ()
    {
        _cameraTransforml.position = new Vector3(
            playerTransform.position.x > 0f ? playerTransform.position.x : 0f,
            playerTransform.position.y > 0f ? playerTransform.position.y : 0f,
            -10f
            );
    }
}
