using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class PlayerAController2 : MonoBehaviour
{
    //[SerializeField] EnemyManager enemyManager;
    // 링크 연결이 어려울때
    EnemyManager enemanager;

    [SerializeField] private float speed = 10f;
    Rigidbody rb; // Cache

    private bool isGround = false;

    //InputAction moveAction; // 새로운 방식 

    private float yRotation = 0;
    private float xRotation = 0;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        enemanager = FindAnyObjectByType<EnemyManager>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        //enemyManager.AttackAll();
        //enemanager = FindAnyObjectByType<EnemyManager>();
        //enemanager.AttackAll()
    }

    // Update is called once per frame
    void Update()
    {
        moveLogic();

        // 1. 방법
        //foreach (var item in enemanager.Enemies)
        // {
        //     float distance = Vector3.Distance(transform.position, item.transform.position);

        //     if (distance <= 3f)
        //     {
        //         item.Attack();
        //     }
        // }

        // 2.
        Collider[] colliders = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                collider.GetComponent<EnemyController2>().Attack();
            }
        }
    }

    private void moveLogic()
    {
        //transform.position += new Vector3(0.1f, 0, 0.1f);
        //Debug.Log(Time.deltaTime);

        //transform.position += new Vector3(0.2f, 0, 0.2f) * Time.deltaTime * speed;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Debug.Log($"{horizontal}, {vertical}");

        //Vector3 mov = new Vector3(horizontal, 0, vertical);
        //// normalized -> 누름강도 X 
        //Vector3 moveNormalized = mov.normalized * Time.deltaTime * speed;
        ////transform.position += moveNormalized;
        //transform.Translate(moveNormalized);


        Vector3 mov = new Vector3(horizontal, 0, vertical); // 로컬 좌표

        Vector3 worldPos = transform.TransformDirection(mov); // to World
        transform.Translate(worldPos * speed * Time.deltaTime, Space.World);

        //Vector3 movNormalized = mov * speed;
        //Vector3 withJump = new Vector3(movNormalized.x, rb.linearVelocity.y, movNormalized.z);
        //rb.linearVelocity = withJump;

        if (Input.GetButtonDown("Jump") && isGround)
        {
            Debug.Log("Jump");
            Jump();
        }


        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * 100;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * 100;
        yRotation += mouseX;
        xRotation -= mouseY;
        float c_X = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(c_X, yRotation, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController2 enemyController = collision.gameObject.GetComponent<EnemyController2>();
            enemyController.Attack();
        }

        if (collision.gameObject.name == "Plane")
        {
            isGround = true;
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 4f, rb.linearVelocity.z);
        isGround = false;
    }

    // MARK: - Move
    void MOVE(float _x, float _y)
    {
        this.transform.position = new Vector2(this.transform.position.x + _x, this.transform.position.y + _y);
    }



    public void Warning()
    {
        Debug.Log("Player Warning");
    }
}
