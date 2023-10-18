using Wave.Native;
using Photon.Pun;
using UnityEngine;

public class VivePassThrough : MonoBehaviourPunCallbacks
{
    [SerializeField] private Camera vrCamera;

    public void EnableSeeThrough()
    {
        photonView.RPC(nameof(RPCEnableSeeThrough), RpcTarget.Others);
    }
    
    public void DisableSeeThrough()
    {
        photonView.RPC(nameof(RPCDisableSeeThrough), RpcTarget.Others);
    }

    [PunRPC]
    private void RPCEnableSeeThrough()
    {
        vrCamera.clearFlags = CameraClearFlags.SolidColor;
        vrCamera.backgroundColor = Color.clear;
        Interop.WVR_ShowPassthroughUnderlay(true);
    }
 
    [PunRPC]
    private void RPCDisableSeeThrough()
    {
        Interop.WVR_ShowPassthroughUnderlay(false);
        vrCamera.clearFlags = CameraClearFlags.Skybox;
        Debug.Log("DisableSeeThrough");
    }
}
