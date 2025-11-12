using System.Collections;
using UnityEngine;

public class CubePlay : MonoBehaviour
{
    // Cashe
    private Animator animatior;
    private bool isAttack = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatior = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0f && !isAttack)
        {
            //animatior.SetBool("IsMove", true);
            animatior.Play("Move");
        } 
        else if (!isAttack)
        {
            //animatior.SetBool("IsMove", false);
            animatior.Play("CubeIdle");
        }

        animateAttack();
    }

    private void animateAttack()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //animatior.SetTrigger("Attack");
            isAttack = true;
            animatior.Play("Atack");
            StartCoroutine(C_AttackStateFinish());
        }
    }

    private IEnumerator C_AttackStateFinish()
    {
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
    }
}
