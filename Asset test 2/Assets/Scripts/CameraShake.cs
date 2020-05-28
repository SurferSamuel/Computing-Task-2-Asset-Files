using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{

    public float ShakeDuration = 0.3f;         
    public float ShakeAmplitude = 1.2f;   
    public float ShakeFrequency = 2.0f;     

    private float ShakeElapsedTime = 0f;
	private bool cameraShakeUpdate = false;

    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    void Start()
    {
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
		
		virtualCameraNoise.m_AmplitudeGain = 0f;
        ShakeElapsedTime = 0f;
    }
	
	void FixedUpdate()
    {
		if (cameraShakeUpdate == true)
		{
			if (VirtualCamera != null && virtualCameraNoise != null)
			{
				if (ShakeElapsedTime > 0)
				{
					virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
					virtualCameraNoise.m_FrequencyGain = ShakeFrequency;
					ShakeElapsedTime -= Time.deltaTime;
				}
				else
				{
					virtualCameraNoise.m_AmplitudeGain = 0f;
					ShakeElapsedTime = 0f;
					cameraShakeUpdate = false;
				}
			}
		}
    }
	
	public void cameraShake()
	{
		cameraShakeUpdate = true;
		ShakeElapsedTime = ShakeDuration;
	}
}