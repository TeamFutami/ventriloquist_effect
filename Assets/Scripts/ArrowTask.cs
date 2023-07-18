using UnityEngine;

public class ArrowTask : MonoBehaviour
{
    [SerializeField] private GameObject arrowUp;
    [SerializeField] private GameObject arrowDown;
    [SerializeField] private GameObject arrowLeft;
    [SerializeField] private GameObject arrowRight;
    
    public string ShowArrow()
    {
        var random = new System.Random();
        var num = random.Next(1, 5);
        string arrow = null;
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
                arrow = "right";
                break;
            case 4:
                arrowRight.SetActive(true);
                arrow = "left";
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
    }
}