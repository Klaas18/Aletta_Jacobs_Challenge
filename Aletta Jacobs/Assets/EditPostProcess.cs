using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine;

public class EditPostProcess : MonoBehaviour
{
    [SerializeField] PostProcessVolume postProcessVolume;
    [Header("Glasses")]
    [SerializeField] Toggle glassesToggle;
    [SerializeField] bool isGlassesON = false;
    [Header("Gelukkig")]
    [SerializeField] Toggle gelukToggle;
    [SerializeField] bool isGelukkigON = false;
    [Header("Slaap Kwaliteit")]
    [SerializeField] Toggle slaapKwal;
    [SerializeField] bool isSlaapKwalON = false;
    // Start is called before the first frame update
    void Start()
    {
       postProcessVolume = GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(isGlassesON)
        {
            postProcessVolume.sharedProfile.GetSetting<DepthOfField>().active = true;
        } 
        else if(!isGlassesON)
        {
            postProcessVolume.sharedProfile.GetSetting<DepthOfField>().active = false;
        }

        if(isGelukkigON)
        {
            postProcessVolume.sharedProfile.GetSetting<Bloom>().active = true;
        } 
        else if(!isGelukkigON)
        {
            postProcessVolume.sharedProfile.GetSetting<Bloom>().active = false;
        }

        if(isSlaapKwalON)
        {
            postProcessVolume.sharedProfile.GetSetting<Vignette>().active = true;
        } 
        else if(!isSlaapKwalON)
        {
            postProcessVolume.sharedProfile.GetSetting<Vignette>().active = false;
        }

    }

    public void ChangeVignette()
    {
        if(slaapKwal.isOn)
        {
            isSlaapKwalON = true;
        } 
        else if(!slaapKwal.isOn)
        {
            isSlaapKwalON = false;
        }
    }

    public void ChangeDepthOfField()
    {
        if(glassesToggle.isOn)
        {
            isGlassesON = true;
        } 
        else if(!glassesToggle.isOn)
        {
            isGlassesON = false;
        }
    }

    public void ChangeBloom()
    {
        if(gelukToggle.isOn)
        {
            isGelukkigON = true;
        } 
        else if(!gelukToggle.isOn)
        {
            isGelukkigON = false;
        }
    }
}
