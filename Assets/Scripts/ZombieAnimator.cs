using UnityEngine;

public class ZombieAnimator : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        GetComponent<Health>().OnTookHit += ZombieAnimator_OnTookHit;
        GetComponent<Health>().OnDied += ZombieAnimator_OnDied;
    }

    private void ZombieAnimator_OnTookHit()
    {
        animator.SetTrigger("Hit");
    }

    private void ZombieAnimator_OnDied()
    {
        animator.SetTrigger("Die");
    }


}
