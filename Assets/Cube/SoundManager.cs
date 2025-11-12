using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // MARK: Cashe
    private AudioSource[] audioSources;
    // MARK: Memeber
    [SerializeField] private AudioClip[] audioClips;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSources = new AudioSource[audioClips.Length];

        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(int index, bool isSkip)
    {
        if (audioSources[index].isPlaying && !isSkip) { return; }

        if (audioClips.Length > index)
        {
            audioSources[index].clip = audioClips[index];
            audioSources[index].Play();

        }
    }

    public void FadeOut(int index)
    {
        StartCoroutine(C_FadeOut(index));
    }

    private IEnumerator C_FadeOut(int index)
    {
        float time = 0;

        while (true)
        {
            time += Time.deltaTime;
            if (time > 0) { break; }

            audioSources[index].volume -= 0.005f;

            yield return null;
        }
    }
}
