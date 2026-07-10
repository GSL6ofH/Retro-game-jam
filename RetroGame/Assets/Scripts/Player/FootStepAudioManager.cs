using UnityEngine;

public class FootStepAudioManager: MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody rb;
    public AudioClip grassStep;
    public AudioClip stoneStep;
    public float timeBetweenSteps = 0.3f;
    private float timer;
    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                PlayStep();
                timer = timeBetweenSteps;
            }
        }
        else
        {
            timer = 0;
        }
    }
    void PlayStep()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
        {
            if (hit.collider.CompareTag("Grass"))
            {
                audioSource.PlayOneShot(grassStep);
            }
            else if (hit.collider.CompareTag("Stone"))
            {
                audioSource.PlayOneShot(stoneStep);
            }
        }
    }
}