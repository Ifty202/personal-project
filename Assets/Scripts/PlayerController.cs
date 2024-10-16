using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");
    public float jumpForce = 10;
    public float jump = 300f;
    public float speed = 2500f;
    public float jumpveloctiy = -2500f;

    public float gravityModifier;

    public bool gameOver;
    public GameObject gameoverButton;
    public TMP_Text scoreText;


    float delayBetweenPresses = 0.25f;
    bool pressedFirstTime = false;
    float lastPressedTime;


    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private bool _isOnGround = true;

    private Animator _playerAnim;
    private AudioSource _playerAudio;
    private Rigidbody _playerRb;

    private int playerPoints;

    // Start is called before the first frame update
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAnim = GetComponent<Animator>();
        _playerAudio = GetComponent<AudioSource>();

        // _playerRb.AddForce(Vector3.up * 100);
        Physics.gravity *= gravityModifier;

        // Hide the gameover message at the beginning
        gameoverButton.SetActive(false);

        playerPoints = 0;

    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isOnGround && !gameOver)
        {
            _isOnGround = false;
            _playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            _playerAnim.SetTrigger(JumpTrig);
            dirtParticles.Play();
            _playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    // When player touches another object that has a collider
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            _isOnGround = true;
            dirtParticles.Play();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            explosionParticles.Play();
            _playerAnim.SetBool(DeathB, true);
            _playerAnim.SetInteger(DeathTypeINT, 1);
            dirtParticles.Stop();
            _playerAudio.PlayOneShot(crashSound, 1.0f);

            // Show game over button
            gameoverButton.SetActive(true);

        }
        else
        {
            // TODO: Detect when you collide with `Money`
            // - Make the `Money` gameObject disappear: Destroy(other.gameobject);
            // - Change the score UI calling the function `SetPointsUI()`

            Debug.Log("Colliding with " + other.gameObject.tag);
        }
    }

    private void SetPointsUI()
    {
        playerPoints = playerPoints + 1;
        Debug.Log("Score" + playerPoints);

        // TODO: Add here a line to show the score to the UI `scoreText.text`
    }
}