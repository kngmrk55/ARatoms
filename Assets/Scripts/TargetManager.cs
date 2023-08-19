using UnityEngine;

public class TargetManager : MonoBehaviour
{
    /*private bool carbonTarget, goldTarget, ironTarget;
    // Start is called before the first frame update
    void Start()
    {
        carbonTarget = false;
        goldTarget = false;
        ironTarget = false;
    }

    public void EnableCarbonTarget(bool active){
        carbonTarget = active;
    }

    public void EnableGoldTarget(bool active){
        goldTarget = active;
    }

    public void EnableIronTarget(bool active){
        ironTarget = active;
    }

    public bool isCarbonTarget(){
        return carbonTarget;
    }

    public bool isGoldTarget(){
        return goldTarget;
    }

    public bool isIronTarget(){
        return ironTarget;
    }*/

    private GameObject activeTarget;

    public void SetActiveTarget(GameObject active){
        activeTarget = active;
    }

    public GameObject GetTarget(){
        return activeTarget;
    }

}
