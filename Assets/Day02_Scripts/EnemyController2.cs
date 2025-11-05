using System.Linq;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
    PlayerAController2 playerAController; // Cache
                                          // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        playerAController = FindAnyObjectByType<PlayerAController2>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1,锅掳 规过
        //float distance = Vector3.Distance(transform.position, playerAController.transform.position);

        //if (distance <= 5f )
        //{
        //    transform.transform.LookAt(playerAController.transform.position);
        //    playerAController.Warning();
        //}

        // 2 锅掳 规过
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Player")
            {
                transform.LookAt(collider.transform.position);
                //playerAController.Warning();

                collider.GetComponent<PlayerAController2>().Warning();
            }
        }
    }

    public void Attack()
    {
        Debug.Log("ATTACK");
    }
}
