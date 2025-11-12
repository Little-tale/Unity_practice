using System.Collections;
using UnityEngine;

// 카메라에만 달 수 있도록 제한을 둔다.
[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    // MARK: Cashe
    Camera camera;
    Vector3 originPos;

    private void Awake()
    {
        camera = camera.GetComponent<Camera>();
        originPos = camera.transform.localPosition;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shake(float second, float magnitude)
    {
        StopCoroutine("C_Shake");
        ResetPos();
        StartCoroutine(C_Shake(second, magnitude));
    }

    private IEnumerator C_Shake(float second, float magnitude)
    {
        float time = 0;
        while(true)
        {
            if (time >= second)
                break;

            Vector3 offset = Random.insideUnitCircle * magnitude;
            transform.localPosition += new Vector3(offset.x, offset.y, 0f);

            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originPos;
    }

    private void ResetPos()
    {
        transform.localPosition = originPos;
    }
}
