using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject masterSlider;

    public UIPanelToggles UI;
    private Slider mS;
    // Start is called before the first frame update
    void Start()
    {
        mS = masterSlider.GetComponent<Slider>();
        mS.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
