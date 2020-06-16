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

    public CinemachineVirtualCamera VirtualCamera1;
    public CinemachineVirtualCamera VirtualCamera2;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise1;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise2;

    private int virtualCameraNum;

    void Start()
    {
        if (VirtualCamera1 != null)
            virtualCameraNoise1 = VirtualCamera1.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        if (VirtualCamera2 != null)
            virtualCameraNoise2 = VirtualCamera2.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

        virtualCameraNoise1.m_AmplitudeGain = 0f;
        virtualCameraNoise2.m_AmplitudeGain = 0f;

        ShakeElapsedTime = 0f;
    }
	
	void FixedUpdate()
    {
		if (cameraShakeUpdate == true)
		{
			if (VirtualCamera1 != null && virtualCameraNoise1 != null && VirtualCamera2 != null && virtualCameraNoise2 != null)
			{
                if (virtualCameraNum == 1)
                {
                    if (ShakeElapsedTime > 0)
                    {
                        virtualCameraNoise1.m_AmplitudeGain = ShakeAmplitude;
                        virtualCameraNoise1.m_FrequencyGain = ShakeFrequency;
                        ShakeElapsedTime -= Time.deltaTime;
                    }
                    else
                    {
                        virtualCameraNoise1.m_AmplitudeGain = 0f;
                        ShakeElapsedTime = 0f;
                        cameraShakeUpdate = false;
                    }
                }
                if (virtualCameraNum == 2)
                {
                    if (ShakeElapsedTime > 0)
                    {
                        virtualCameraNoise2.m_AmplitudeGain = ShakeAmplitude;
                        virtualCameraNoise2.m_FrequencyGain = ShakeFrequency;
                        ShakeElapsedTime -= Time.deltaTime;
                    }
                    else
                    {
                        virtualCameraNoise2.m_AmplitudeGain = 0f;
                        ShakeElapsedTime = 0f;
                        cameraShakeUpdate = false;
                    }
                }
			}
		}
    }
	
	public void cameraShake(int CamNum)
	{
        virtualCameraNum = CamNum;
        cameraShakeUpdate = true;
		ShakeElapsedTime = ShakeDuration;
	}
}