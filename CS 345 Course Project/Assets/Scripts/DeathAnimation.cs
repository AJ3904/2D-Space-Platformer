using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite deadSprite;
    public GameObject GameOverUI;
    public AudioClip deathSound;  // Reference to the death sound
    private AudioSource audioSource; // Reference to AudioSource

    private void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        UpdateSprite();
        DisablePhysics();
        StartCoroutine(Animate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void UpdateSprite()
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sortingOrder = 10;

        if (deadSprite != null) {
            spriteRenderer.sprite = deadSprite;
        }
    }

    private void DisablePhysics()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();

        for (int i = 0; i < colliders.Length; i++) {
            colliders[i].enabled = false;
        }

        if (TryGetComponent(out Rigidbody2D rigidbody)) {
            rigidbody.isKinematic = true;
        }

        if (TryGetComponent(out PlayerController playerMovement)) {
            playerMovement.enabled = false;
        }
    }

    private IEnumerator Animate()
    {
        // Play the death sound once
        if (deathSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        float elapsed = 0f;
        float duration = 2f;  // Increased duration for the animation (adjust to your needs)

        float jumpVelocity = 10f;
        float gravity = -36f;

        Vector3 velocity = Vector3.up * jumpVelocity;

        // Perform the animation while the duration is not reached
        while (elapsed < duration)
        {
            transform.position += velocity * Time.deltaTime;
            velocity.y += gravity * Time.deltaTime;
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure the audio finishes playing before moving on (optional)
        while (audioSource.isPlaying)
        {
            yield return null; // Wait until the audio is done
        }

        Destroy(this.gameObject);
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}

