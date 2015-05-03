using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public Transform m_player;
    public float dampTime = 0.15f;

    float mapX = 1280.0f;
    float mapY = 720.0f;
     
    float minX, maxX, minY, maxY;

    private Transform edgeCheck;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        float vertExtent = Camera.main.camera.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;
    }


    void FixedUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector2 v3 = transform.position;
        v3.x = Mathf.Clamp(v3.x, minX, maxX);
        v3.y = Mathf.Clamp(v3.y, minY, maxY);
        transform.position = v3;

        if (m_player)
        {
            Vector3 point = camera.WorldToViewportPoint(m_player.position);
            Vector3 delta = m_player.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
