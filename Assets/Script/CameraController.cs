using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerposition;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {
            playerposition = new Vector3(playerposition.x + offset, 0, playerposition.y);
        }
        else
        {
            playerposition = new Vector3(playerposition.x - offset, 0, playerposition.y);
        }
        transform.position = Vector3.Lerp(transform.position, playerposition, offsetSmoothing * Time.deltaTime);

    }

}

