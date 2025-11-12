using UnityEngine;

public class CubeSoundPlay : MonoBehaviour
{
    // MARK: Memeber
    [SerializeField] private AudioClip[] audioClips;
    // MARK: Cashe
    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int index, bool isSkip)
    {
        if (audioSource.isPlaying && !isSkip ) { return; }

        if (audioClips.Length > index)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
