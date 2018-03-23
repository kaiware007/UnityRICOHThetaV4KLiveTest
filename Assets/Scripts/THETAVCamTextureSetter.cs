using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THETAVCamTextureSetter : MonoBehaviour {

    #region define
    static readonly string theta_v_FullHD = "RICOH THETA V FullHD";
    static readonly string theta_v_4K = "RICOH THETA V 4K";

    static readonly string[] thetaCameraModeList =
    {
        theta_v_FullHD,
        theta_v_4K,
    };

    public enum THETA_V_CAMERA_MODE
    {
        THETA_V_FullHD,
        THETA_V_4K,
    }
    #endregion

    public THETA_V_CAMERA_MODE cameraMode = THETA_V_CAMERA_MODE.THETA_V_FullHD;

    // Use this for initialization
    void Start () {

        int cameraIndex = -1;

        WebCamDevice[] devices = WebCamTexture.devices;
        Debug.Log("DevicesLength:" + devices.Length.ToString());
        for (var i = 0; i < devices.Length; i++)
        {
            for (int j = 0; j < thetaCameraModeList.Length; j++)
            {
                if (devices[i].name == thetaCameraModeList[j])
                {
                    Debug.Log("[" + i + "] " + devices[i].name + " detected");
                    cameraIndex = i;
                    break;
                }
            }
            if (cameraIndex >= 0) break;
        }

        if(cameraIndex < 0)
        {
            Debug.LogError("THETA V Not found");
            return;
        }

        WebCamTexture webCamTexture = new WebCamTexture(devices[cameraIndex].name);
        GetComponent<Renderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }
	
}
