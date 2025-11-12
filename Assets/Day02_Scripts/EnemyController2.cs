using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{
    PlayerAController2 playerAController; // Cache
                                          // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] LayerMask layerMask;

    private Vector3 originPos;
    [SerializeField] Transform targetPos;

    private int dgree = 0;

    private float factor;

    private int indexMove;

    private bool isFinished = false;

    IEnumerator C_MoveRight()
    {
        yield return new WaitForSeconds(0.5f);
        transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(0.5f);

        transform.Translate(1, 0, 0);
        yield return new WaitForSeconds(0.5f);

        transform.Translate(1, 0, 0);
    }

    IEnumerator C_MoveDown()
    {
        yield return new WaitForSeconds(0.5f);

        transform.Translate(0, 0, -1);
        yield return new WaitForSeconds(0.5f);

        transform.Translate(0, 0, -1);
        yield return new WaitForSeconds(0.5f);

        transform.Translate(0, 0, -1);
    }

    IEnumerator CorutineStart()
    {
        yield return StartCoroutine(C_MoveRight());
        yield return StartCoroutine(C_MoveDown());
    }

    private void Awake()
    {
        playerAController = FindAnyObjectByType<PlayerAController2>();
        // 레이어 마스크 코드로 지정
        layerMask = 1 << LayerMask.NameToLayer("Player");

      
    }

    void Start()
    {
        //originPos = transform.position;

        // yield return CorutineStart();

        transform.position = transform.TransformPoint(5, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // 1,번째 방법
        //float distance = Vector3.Distance(transform.position, playerAController.transform.position);

        //if (distance <= 5f )
        //{
        //    transform.transform.LookAt(playerAController.transform.position);
        //    playerAController.Warning();
        //}

        // 2 번째 방법
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);

        //foreach (Collider collider in colliders)
        //{
        //    if (collider.gameObject.tag == "Player")
        //    {
        //        transform.LookAt(collider.transform.position);
        //        //playerAController.Warning();

        //        collider.GetComponent<PlayerAController2>().Warning();
        //    }
        //}

        ////transform.rotation *= Quaternion.Euler(new Vector3(0, 5, 0));
        //transform.Rotate(0,5,0);

        //if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo,
        //    Mathf.Infinity, layerMask))
        //{
        //    Debug.Log("hit" + hitInfo.collider.gameObject.name);
        //    Debug.DrawLine(transform.position, hitInfo.point, color: Color.red);
        //    //hitInfo.collider.GetComponent<PlayerController>().Warning();
        //}

        //Debug.Log(Mathf.Cos(Mathf.Rad2Deg * 60));
        //transform.position = new Vector3(Mathf.Cos(Mathf.Deg2Rad * dgree), transform.position.y, 0);
        //dgree += 1;

        //var rad = dgree * Mathf.Deg2Rad;
        //transform.position = new Vector3(Mathf.Cos(rad), transform.position.y, Mathf.Sin(rad));
        //dgree += 1;

        //factor += Time.deltaTime;
        //var value = Vector3.Lerp(originPos, targetPos.position, factor);
        //transform.position = value;

        //if (indexMove <= 3)
        //{
        //    transform.Translate(1, 0, 0);
        //    indexMove = 0;
        //} else
        //{
        //    isFinished = true;
        //}

        //if (isFinished)
        //{
        //    transform.Translate(0, 0, 1);
        //}

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Plater")
            {
                collider.GetComponent<PlayerAController2>().Attack();
            }
        }
    }

    public void Attack()
    {
        Debug.Log("ATTACK");
    }
}
