using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material[] skyboxes = new Material[3];

    void Start()
    {
        PickRandomSkybox();
    }

    void PickRandomSkybox()
    {
        int index = Random.Range(0, skyboxes.Length);
        RenderSettings.skybox = skyboxes[index];
        DynamicGI.UpdateEnvironment();
    }
}
