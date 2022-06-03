using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;
    public static AudioManager instance;

    private void Awake()  {

        // Avoids multiple presistent AudioManagers ;
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        // Makes the AudioManager presistent across scenes ;
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.outputAudioMixerGroup =s.group;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    private void Start() {
        
        Scene mainMenu = SceneManager.GetSceneByBuildIndex(0);
        Scene game = SceneManager.GetSceneByBuildIndex(1);

        if (mainMenu.isLoaded) { Play("mainMenuMusic"); }
        
    }

    public void Play(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Could not find specified sound name !!");
        }
        s.source.Play();

    }

    public void Stop(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Could not find specified sound name !!");
        }
        s.source.Stop();

    }

}
