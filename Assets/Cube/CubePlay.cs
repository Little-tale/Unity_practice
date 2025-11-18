using System.Collections;
using UnityEngine;

public class CubePlay : MonoBehaviour
{
    // Cashes
    private Animator animatior;
    private SoundManager cubeSoundManager;
    private EffectManager effectManager;
     
    //[SerializeField] private GameObject effectPrefab;
    [SerializeField] private Transform effectPos;

    // MARK: Members
    private bool isAttack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatior = GetComponent<Animator>();
        cubeSoundManager = FindAnyObjectByType<SoundManager>();

        //cubeSoundManager.PlaySound(2, false);

        //Invoke("FadeOutSound", 3f);

        //Instantiate(effectPrefab, effectPos); // 부모를 지정할 수 있음

        effectManager = FindAnyObjectByType<EffectManager>();

        effectManager.PlayEffect(0, effectPos);
    }

    private void FadeOutSound()
    {
        cubeSoundManager.FadeOut(2);
    }

    // Update is called once per frame
    void Update()
    {
        MoveState();
        IdleState();
        animateAttack();
    }

    private void MoveState()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) > Mathf.Epsilon && !isAttack)
        {
            //animatior.SetBool("IsMove", true);
            animatior.Play("Move");
            cubeSoundManager.PlaySound(0, false);
        }
    }

    private void IdleState()
    {
        if (!isAttack)
        {
            //animatior.SetBool("IsMove", false);
            animatior.Play("CubeIdle");
            //cubeSoundManager.PlaySound(0);

        }
    }
    
    private void animateAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //animatior.SetTrigger("Attack");
            isAttack = true;
            animatior.Play("Atack");
            StartCoroutine(C_AttackStateFinish());
            cubeSoundManager.PlaySound(1, true);
        }
    }

    private IEnumerator C_AttackStateFinish()
    {
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }
}
