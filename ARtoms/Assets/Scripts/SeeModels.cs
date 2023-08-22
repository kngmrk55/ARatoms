using UnityEngine;
using Vuforia;

public class SeeModels : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] disappear;
    //public GameObject[] appear;
    public Animator anim1,anim2;
    public TargetManager currentTarget;

    void Start()
    {
        
    }
    public void SeeModel()
    {

        if(currentTarget.GetTarget() == transform.parent.gameObject){
            
            for(int i=0;i<disappear.Length;i++){
                disappear[i].SetActive(false);
            }
            /*for(int i=0;i<appear.Length;i++){
                appear[i].SetActive(true);
            }*/
            anim1.SetBool("Translate",true);
            anim1.SetBool("Return", false);
            anim2.SetBool("Translate",true);
            anim2.SetBool("Return", false);
        }

    }

    public void NoSeeModel()
    {
        if(currentTarget.GetTarget() == transform.parent.gameObject){
            for(int i=0;i<disappear.Length;i++){
                disappear[i].SetActive(true);
            }
            /*for(int i=0;i<appear.Length;i++){
                appear[i].SetActive(false);
            }*/
            anim1.SetBool("Translate",false);
            anim1.SetBool("Return", true);
            anim2.SetBool("Translate",false);
            anim2.SetBool("Return", true);
        }
    }
}
