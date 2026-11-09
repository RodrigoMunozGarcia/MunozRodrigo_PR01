using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform playerTransform;

    // Desplazamiento
    [SerializeField] float offsetZ;
    [SerializeField] float offsetY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offsetZ = -2.5f;
        offsetY = 2.4f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector de desplazamiento
        Vector3 offset = new Vector3(0f, offsetY, offsetZ);

        transform.position = playerTransform.position + offset;
    }
}
