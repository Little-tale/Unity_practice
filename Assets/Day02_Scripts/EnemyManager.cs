using System.Collections.Generic;
using Unity.AI.Navigation.Editor;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{

    //[SerializeField] private EnemyController2[] enemyControllers;
    //private List<EnemyController2> enemyControllers = new();

    // prefab을 이용한
    [SerializeField] GameObject enemyPrefab;
    private List<EnemyController2> enemyControllers = new List<EnemyController2>();

    PlayerAController2 playerAController;
    NavMeshAgent agent;

    public List<EnemyController2> Enemies
    {
        get
        {
            return enemyControllers;
        }
    }

    private void Awake()
    {
        playerAController = FindAnyObjectByType<PlayerAController2>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(gameObject.name);

        for (int i = 0; i < 4; i++)
        {
            GameObject gameObject = Instantiate(enemyPrefab, this.gameObject.transform);// 프리펩을 통해 생성

            EnemyController2 enemyController = gameObject.GetComponent<EnemyController2>();
            //enemyControllers.Add()
            this.enemyControllers.Add(enemyController);
        }
        //transform.position;
        //transform.rotation;
        //transform.localScale;

        // 컴포넌트 가져오기
        //BoxCollider boxCollider = GetComponent<BoxCollider>();

        // 여러 자식들 가져오기
        // 비용은 좀 낮음 
        //var enemyControllers = gameObject.GetComponentsInChildren<EnemyController2>();

        // 시리얼라이즈 필드로 가져오기


        // Find
        // 숨겨진 파일 찾을 수 없음
        //enemyControllers = FindObjectsOfType<EnemyController2>();

        //foreach (EnemyController2 controller in enemyControllers)
        //{
        //    Debug.Log(controller.gameObject.name);
        //}

        // Find2 object Name
        // 비용이 높고, 숨겨진 파일을 찾을수 없음
        // 다만 (true); 값을 주면 찾음
        //GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        //foreach (GameObject gameObject in gameObjects)
        //{
        //    enemyControllers.Add(gameObject.GetComponent<EnemyController2>());
        //}
        //Debug.Log(enemyControllers);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerAController.transform.position);
    }

    //public void AttackAll() 
    //{
    //    foreach (var controller in enemyControllers)
    //    {
    //        controller.Attack();
    //    }
    //}
}
