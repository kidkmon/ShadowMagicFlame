using UnityEngine;

public class FlameManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireParticles;
    [SerializeField] private Animator fireAnimator;

    public void ToggleFire(bool isActive)
    {
        fireAnimator.SetBool("FireUp", isActive);
    }
}
