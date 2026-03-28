using UnityEngine;
using System.Collections;

public class EarthOptionsGUISimple : MonoBehaviour
{
    private bool clouds = true;
    private float earthRotationSpeed = 2.0f;
    private float cloudRotationSpeed = 3.0f;
    private CloudRotation cloudRotationScript;
    private GameObject cloudsTransform;
    private float cloudType = 0.0f; // start at 0
    private float currentSelectedCloud = 0.0f;
    private GeneralUI generalUIScript;
    public float labelWidth = 160;

    void Start()
    {
        // Find clouds object
        cloudsTransform = GameObject.FindGameObjectWithTag("Earth Clouds");
        if (cloudsTransform != null)
            cloudRotationScript = cloudsTransform.GetComponent<CloudRotation>();
        else
            Debug.LogWarning("No GameObject found with tag 'Earth Clouds'");

        // Find GeneralUI on MainCamera
        GameObject mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        if (mainCam != null)
            generalUIScript = mainCam.GetComponent<GeneralUI>();
        else
            Debug.LogWarning("No MainCamera found or GeneralUI missing on it");
    }

    void Update()
    {
        // Rotate Earth
        transform.Rotate(new Vector3(0, Time.deltaTime * earthRotationSpeed, 0));

        // Update cloud material if changed
        if (generalUIScript != null &&
            generalUIScript.cloudMaterials != null &&
            generalUIScript.cloudShadowMaterials != null &&
            generalUIScript.cloudMaterials.Count > 0 &&
            generalUIScript.cloudShadowMaterials.Count > 0)
        {
            int cloudIndex = Mathf.Clamp((int)cloudType, 0, generalUIScript.cloudMaterials.Count - 1);

            if ((int)currentSelectedCloud != cloudIndex)
            {
                var selectedCloudMaterial = generalUIScript.cloudMaterials[cloudIndex];
                var selectedCloudShadowMaterial = generalUIScript.cloudShadowMaterials[cloudIndex];

                GameObject cloudsObj = GameObject.Find("Clouds/Clouds");
                if (cloudsObj != null)
                    cloudsObj.GetComponent<Renderer>().material = selectedCloudMaterial;

                GameObject cloudsOuterObj = GameObject.Find("Clouds/CloudsOuter");
                if (cloudsOuterObj != null)
                    cloudsOuterObj.GetComponent<Renderer>().material = selectedCloudShadowMaterial;

                currentSelectedCloud = cloudIndex;
            }
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width - 300, Screen.height - 25, 250, 120), "Left click & drag to rotate around Earth.");

        clouds = GUI.Toggle(new Rect(25, 30, 100, 30), clouds, "Clouds");

        GUI.Label(new Rect(25, 60, labelWidth, 30), "Earth rotation speed");
        earthRotationSpeed = GUI.HorizontalScrollbar(new Rect(25, 90, labelWidth, 30), earthRotationSpeed, 1.0f, 0.0f, 10.0f);

        if (clouds)
        {
            ToggleChildrenMeshRendered(clouds, cloudsTransform);

            GUI.Label(new Rect(25, 120, labelWidth, 30), "Cloud rotation speed");
            cloudRotationSpeed = GUI.HorizontalScrollbar(new Rect(25, 150, labelWidth, 30), cloudRotationSpeed, 1.0f, 0.0f, 15.0f);

            if (generalUIScript != null &&
                generalUIScript.cloudMaterials != null &&
                generalUIScript.cloudMaterials.Count > 0)
            {
                GUI.Label(new Rect(25, 180, labelWidth, 30), "Cloud type");
                cloudType = GUI.HorizontalScrollbar(
                    new Rect(25, 210, labelWidth, 30),
                    cloudType,
                    0.0f,
                    0.0f,
                    generalUIScript.cloudMaterials.Count - 1
                );
            }
        }
        else
        {
            ToggleChildrenMeshRendered(clouds, cloudsTransform);
        }

        // Update cloud rotation speed safely
        if (cloudRotationScript != null)
            cloudRotationScript.planetSpeedRotation = cloudRotationSpeed;
    }

    void ToggleChildrenMeshRendered(bool on, GameObject target)
    {
        if (target == null) return;

        foreach (var item in target.GetComponentsInChildren<MeshRenderer>())
        {
            item.enabled = on;
        }
    }
}