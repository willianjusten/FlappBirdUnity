using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;

    [SerializeField] private float GRAVITY = -9.8f;
    [SerializeField] private float FLAP_AMOUNT = 5f;

    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private Sprite[] sprites;
    private int spriteIndex;

    [SerializeField] private AudioSource flapSound;
    [SerializeField] private AudioSource scoreSound;
    [SerializeField] private AudioSource hitSound;
    

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable() {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update() {
        Flap();
    }

    private void Flap() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * FLAP_AMOUNT;
            flapSound.Play();
        }

        direction.y += GRAVITY * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite() {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void ShowGameOver() {
        hitSound.Play();
        gameManager.GameOver();
    }

    private void Score() {
        scoreSound.Play();
        gameManager.IncreaseScore();
    }

    private void OnTriggerEnter2D(Collider2D element) {
        if (element.gameObject.tag == "Obstacle") {
            ShowGameOver();
        } else if (element.gameObject.tag == "Scoring") {
            Score();
        }
    }
}
