using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public AudioClip bounceClip;  // assign in Inspector
    AudioSource audio;
    
     void Awake() => audio = GetComponent<AudioSource>();

    void OnCollisionEnter(Collision collision)
    {
        // Play the clip once whenever we hit something (e.g., the floor)
        if (bounceClip != null)
            audio.PlayOneShot(bounceClip);
    }
}
