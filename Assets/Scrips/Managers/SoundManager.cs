using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("AudioSource")]
    [SerializeField]
    private AudioSource _soundEffectSource;

    [Header("AudioClips")]
    public AudioClip disperoPlayer;
    public AudioClip recarga;
    public AudioClip pocaVida;
    public AudioClip golpearEnemigo;
    public AudioClip golpearObjeto;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this; 
    }

    public void PlaySFX(AudioClip clip)
    {
        _soundEffectSource.PlayOneShot(clip);
    }

}
