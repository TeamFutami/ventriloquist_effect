using System;
using Unity.XR.PXR;
using UnityEngine;
using Photon.Pun;

public class PassThroughSetter : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera vrCamera;

    public void EnableSeeThrough()
    {
        photonView.RPC("RPCEnableSeeThrough", RpcTarget.Others);
    }
    
    public void DisableSeeThrough()
    {
        photonView.RPC("RPCDisableSeeThrough", RpcTarget.Others);
    }

    [PunRPC]    
    private async void RPCEnableSeeThrough()
    {
        vrCamera.clearFlags = CameraClearFlags.SolidColor;
        vrCamera.backgroundColor = Color.clear;
        PXR_Boundary.EnableSeeThroughManual(true);   
    }
    
    [PunRPC]
    private void RPCDisableSeeThrough()
    {
        PXR_Boundary.EnableSeeThroughManual(false);
        vrCamera.clearFlags = CameraClearFlags.Skybox;
    }
}
