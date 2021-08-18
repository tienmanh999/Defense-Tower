using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MasterVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _mutiplier = 30f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderChange);
    }
    void HandleSliderChange(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _mutiplier);
    }
}
