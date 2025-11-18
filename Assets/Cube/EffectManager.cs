using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject[] effectPrefabs;
    [SerializeField] private float[] destoryTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(int index, Transform parent)
    {
        if (effectPrefabs.Length > index)
        {
           GameObject obj = Instantiate(effectPrefabs[index], parent);
            obj.transform.localPosition = Vector3.zero;
            StartCoroutine(C_DestroyEffect(obj, destoryTime[index]));
        }
    }


    private IEnumerator C_DestroyEffect(GameObject obj, float destroyTime)
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(obj);
    }
}
