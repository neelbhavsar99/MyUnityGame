using UnityEngine;
//using System.Collections;

[System.Serializable]   
public class Sound
{

    public string name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume = 0.7f;

    [Range(0.5f, 1.5f)]
    public float pitch = 1f;

    [Range(0f, 0.5f)]
    public float randomVolume = 0.1f;
    [Range(0f, 0.5f)]
    public float randomPitch = 0.1f;
    private AudioSource source;
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;

    }


    public void Play()
    {
        source.volume = volume * (1 + Random.Range(-randomVolume /2f, randomVolume / 2f));
        source.pitch = pitch * (1 + Random.Range(-randomPitch / 2f, randomPitch / 2f));
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;

    [SerializeField]
    Sound[] sounds;

    void Awake ()
    {
        /*instance = this;
        if (instance != null)
        {
            Debug.Log("More than one Audiomanager in the scene"); 

        } else
        {
            instance = this;
        }*/
    }

    void Start ()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);    
            sounds[i].SetSource (_go.AddComponent<AudioSource>());
        }

        PlaySound("Background");
    }


            

    public void PlaySound (string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Play();
                return;
            }
        }

        //Debug.LogWarning("Audiomanager: Sound not found on this list" + name);

    }
    //2-Player audio
    public AudioSource audioSource; // camera

    public AudioClip score;
    public AudioClip win;
    public AudioClip pickup;
    public AudioClip pass;
    public AudioClip bounce;

    public void PlayScore()
    {
        audioSource.PlayOneShot(score, 1f);
    }

    public void PlayWin()
    {
        audioSource.PlayOneShot(win, 1f);
    }

    public void PlayPickup()
    {
        audioSource.PlayOneShot(pickup, 0.5f);
    }

    public void PlayPass()
    {
        audioSource.PlayOneShot(pass, 1f);
    }

    public void PlayBounce()
    {
        audioSource.PlayOneShot(bounce, 1f);
    }
}

