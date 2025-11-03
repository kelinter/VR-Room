using UnityEngine;

public class RotateTarget : MonoBehaviour
{
    [SerializeField] private Transform target; // assign PedestalPivot

    // Hook this to Slider.onValueChanged (float)
    public void SetYAngle(float yDegrees)
    {
        if (!target) return;
        var e = target.localEulerAngles;
        e.y = yDegrees;
        target.localEulerAngles = e;
    }
}
