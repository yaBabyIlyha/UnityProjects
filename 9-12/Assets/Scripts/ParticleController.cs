using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem fireEffect;
    public AudioSource fire;
    //2
    private bool isPlaying = false;

    public void ToggleFire()
    {
        if (isPlaying)
        {
            fireEffect.Stop();
            fire.Stop(); // Явная остановка звука
            isPlaying = false;
        }
        else
        {
            fireEffect.Play();
            fire.Play();
            isPlaying = true;
        }
    }

    void Update()
    {
        // Дополнительная проверка, если звук почему-то продолжается
        if (!fireEffect.isPlaying && fire.isPlaying)
        {
            fire.Stop();
        }
    }
}