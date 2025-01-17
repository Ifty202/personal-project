using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float _repeatWidth;
    private Vector3 _startPos;

    // Start is called before the first frame update
    private void Start()
    {
        _startPos = transform.position;
        _repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.x < _startPos.x - _repeatWidth) transform.position = _startPos;
    }
}