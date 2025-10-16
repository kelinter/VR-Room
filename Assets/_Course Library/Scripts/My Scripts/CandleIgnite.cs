using UnityEngine;

public class CandleIgnite : MonoBehaviour
{
    public GameObject flameParticles; 
    public Light candleLight;        
    bool isLit = false;

    void Awake() {
        if (flameParticles) flameParticles.SetActive(false);
        if (candleLight) candleLight.enabled = false;
    }

    public void Light() {
        if (isLit) return;
        isLit = true;
        if (flameParticles) flameParticles.SetActive(true);
        if (candleLight) candleLight.enabled = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Flame")) Light();
    }
}
