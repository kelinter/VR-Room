using UnityEngine;

public class AnimatedRectile : MonoBehaviour
{
    // the speed of rotation in degrees per second
    public float rotationSpeed = 180f;

    // the scale pulsation speed
    public float scaleSpeed = 2f;

    // the minimum and maximum scale values
    public float minScale = 0.8f;
    public float maxScale = 1.2f;

    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // rotate the reticle around the Z-axis
        // Time.deltaTime ensures the rotation is frame-rate independent
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        // animate the scale using a sine wave for a smooth pulse effect
        time = (Mathf.Sin(Time.time * scaleSpeed) + 1) / 2f;
        float currentScale = Mathf.Lerp(minScale, maxScale, time);
        transform.localScale = new Vector3(currentScale, currentScale, currentScale);
    }
}
