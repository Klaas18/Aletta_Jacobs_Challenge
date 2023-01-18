using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class EditPostProcess : MonoBehaviour
{
    [SerializeField] PostProcessVolume postProcessVolume;
    // Start is called before the first frame update
    void Start()
    {
       postProcessVolume = GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            postProcessVolume.sharedProfile.GetSetting<Bloom>().active = true;
           
            postProcessVolume.sharedProfile.GetSetting<Vignette>().active = true;
            postProcessVolume.sharedProfile.GetSetting<DepthOfField>().active = true;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            postProcessVolume.sharedProfile.GetSetting<Bloom>().active = false;
            postProcessVolume.sharedProfile.GetSetting<Vignette>().active = false;
            postProcessVolume.sharedProfile.GetSetting<DepthOfField>().active = false;
        }
    }
}
