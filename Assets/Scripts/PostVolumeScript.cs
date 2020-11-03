using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostVolumeScript : MonoBehaviour
{
    ChromaticAberration effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<PostProcessVolume>().profile.TryGetSettings<ChromaticAberration>(out effect);
        if (Input.GetButton("Jump"))
        {
            effect.intensity.value = Mathf.Lerp(effect.intensity.value, 3, 10 * Time.deltaTime);
        }

        else
        {
            effect.intensity.value = Mathf.Lerp(effect.intensity.value, 0, 5 * Time.deltaTime);
        }
        
        Debug.Log(effect.intensity.value );
    }
}
