using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float leftLimit;
    [SerializeField] private float rightLimit;
    [SerializeField] private float bottomLimit;
    [SerializeField] private float upLimit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10);
        transform.position = new Vector3
            (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upLimit),
            transform.position.z
            );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, upLimit), new Vector2(rightLimit, upLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, upLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, upLimit), new Vector2(rightLimit, bottomLimit));
    }
}
