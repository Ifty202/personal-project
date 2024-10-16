using UnityEngine;

namespace Challenge_3.Scripts
{
    public class RepeatBackgroundX : MonoBehaviour
    {
        private PlayerControllerX _playerController;
        private float _repeatWidth;
        private Vector3 _startPos;

        private void Start()
        {
            _startPos = transform.position; // Establish the default starting position 
            _repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set repeat width to half of the background
            _playerController = GameObject.Find("Player").GetComponent<PlayerControllerX>();
        }

        private void Update()
        {
            // If background moves left by its repeat width, move it back to start position
            if (transform.position.x < _startPos.x - _repeatWidth) transform.position = _startPos;
        }
    }
}