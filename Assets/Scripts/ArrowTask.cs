using Photon.Pun;
using UnityEngine;
using UnityEngine.Serialization;

public class ArrowTask : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject arrowUp;
    [SerializeField] private GameObject arrowDown;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    [SerializeField] private GameObject charUp;
    [SerializeField] private GameObject charDown;
    [SerializeField] private GameObject charLeft;
    [SerializeField] private GameObject charRight;
    
    public void ShowArrowCall()
    {
        photonView.RPC(nameof(ShowArrow), RpcTarget.Others);
    }
    
    [PunRPC]
    public string ShowArrow()
    {
        var random = new System.Random();
        var num = random.Next(1, 5);
        string arrow = null;
        string charArrow = null;
        switch (num)
        {
            case 1:
                arrowUp.SetActive(true);
                arrow = "up";
                break;
            case 2:
                arrowDown.SetActive(true);
                arrow = "down";
                break;
            case 3:
                arrowLeft.SetActive(true);
                arrow = "left";
                break;
            case 4:
                arrowRight.SetActive(true);
                arrow = "right";
                break;
        }
        
        num = random.Next(1, 5);
        switch (num)
        {
            case 1:
                charUp.SetActive(true);
                charArrow = "up";
                break;
            case 2:
                charDown.SetActive(true);
                charArrow = "down";
                break;
            case 3:
                charLeft.SetActive(true);
                charArrow = "left";
                break;
            case 4:
                charRight.SetActive(true);
                charArrow = "right";
                break;
        }

        return arrow;
    }
    
    public void HideArrow()
    {
        arrowUp.SetActive(false);
        arrowDown.SetActive(false);
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
        
        charUp.SetActive(false);
        charDown.SetActive(false);
        charLeft.SetActive(false);
        charRight.SetActive(false);
    }
}