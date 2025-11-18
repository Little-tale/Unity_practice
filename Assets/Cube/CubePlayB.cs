using UnityEngine;

public class CubePlayB : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other) // 파티클 충돌 감지
    {
        Debug.Log("CubePlayB - OnParticleCollision with " + other.name);
    }
}
