using UnityEngine;

namespace Challenge_3.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        private const float GravityModifier = 1.5f;
        public bool gameOver;
        public float floatForce;

        public ParticleSystem explosionParticle;
        public ParticleSystem fireworksParticle;
        public AudioClip moneySound;
        public AudioClip explodeSound;
        public AudioClip boingSound;

        private AudioSource _playerAudio;
        private Rigidbody _playerRb;

        private float _screenMaxY;

        // Start is called before the first frame update
        private void Start()
        {
            Physics.gravity *= GravityModifier;
            _playerAudio = GetComponent<AudioSource>();
            _playerRb = GetComponent<Rigidbody>();
            _screenMaxY = Camera.main != null ? Camera.main.ScreenToWorldPoint(Vector3.zero).y : 0;

            // Apply a small upward force at the start of the game
            _playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

        // Update is called once per frame
        private void Update()
        {
            Debug.Log(Input.touchCount);
            Debug.Log(Input.touches);
            // While space is pressed and player is low enough, float up
            // if ((Input.GetKey(KeyCode.Space) || Input.GetTouch(0).phase == TouchPhase.Began) && !gameOver &&
            if (Input.GetKey(KeyCode.Space) && !gameOver &&
                gameObject.transform.position.y < _screenMaxY)
                _playerRb.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);

            // when balloon reaches twice the amount of max height, add force to push down 
            if (gameObject.transform.position.y > 2 * _screenMaxY)
                _playerRb.AddForce(Vector3.down * (floatForce * 0.3f));
        }

        private void OnCollisionEnter(Collision other)
        {
            // if player collides with bomb, explode and set gameOver to true
            if (other.gameObject.CompareTag("Bomb"))
            {
                explosionParticle.Play();
                _playerAudio.PlayOneShot(explodeSound, 1.0f);
                gameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
            }

            // if player collides with money, fireworks
            else if (other.gameObject.CompareTag("Money"))
            {
                fireworksParticle.Play();
                _playerAudio.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                // _playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
                _playerAudio.PlayOneShot(boingSound, 1.0f);
            }
        }
    }
}