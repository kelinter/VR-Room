using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform hourHand;
    public Transform minuteHand;
    public Transform secondHand;
    [Tooltip("Use actual system time (ignores Time.timeScale)")]
    public bool useRealTime = true;

    [Header("Simulated")]
    public float simulatedTimeScale = 1.0f;
    private float simulatedSeconds = 0f;

    void Update()
    {
        if (useRealTime) UpdateRealTime();
        else UpdateSimulatedTime();
    }

    void UpdateRealTime()
    {
        if (!HandsAssigned()) return;

        DateTime t = DateTime.Now;
        // include milliseconds for smoothness
        double seconds = t.Second + t.Millisecond / 1000.0;
        double minutes = t.Minute + seconds / 60.0;
        double hours   = (t.Hour % 12) + minutes / 60.0;

        float secondAngle = (float)(seconds / 60.0 * 360.0);
        float minuteAngle = (float)(minutes / 60.0 * 360.0);
        float hourAngle   = (float)(hours   / 12.0 * 360.0);

        ApplyRotations(hourAngle, minuteAngle, secondAngle);
    }

    void UpdateSimulatedTime()
    {
        if (!HandsAssigned()) return;

        simulatedSeconds += Time.deltaTime * simulatedTimeScale;

        float seconds = simulatedSeconds % 60f;
        float minutes = (simulatedSeconds / 60f) % 60f;
        float hours   = (simulatedSeconds / 3600f) % 12f;

        float secondAngle = seconds / 60f * 360f;
        float minuteAngle = minutes / 60f * 360f;
        float hourAngle   = hours   / 12f * 360f;

        ApplyRotations(hourAngle, minuteAngle, secondAngle);
    }

    bool HandsAssigned()
    {
        if (hourHand && minuteHand && secondHand) return true;
        Debug.LogWarning("Clock hands not assigned in Inspector.");
        return false;
    }

    void ApplyRotations(float hourAngle, float minuteAngle, float secondAngle)
    {
        // Rotate around the Z-axis for a wall clock.
        // Use negative angles for clockwise motion.
        if (secondHand) secondHand.localRotation = Quaternion.Euler(0f, 0f, -secondAngle);
        if (minuteHand) minuteHand.localRotation = Quaternion.Euler(0f, 0f, -minuteAngle);
        if (hourHand)   hourHand.localRotation   = Quaternion.Euler(0f, 0f, -hourAngle);
    }
}
