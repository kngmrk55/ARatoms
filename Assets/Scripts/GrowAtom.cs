using UnityEngine;
using Vuforia;

public class GrowAtom : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] disappear;
    public GameObject[] appear;
    private Animator anim;
    public TargetManager currentTarget;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void SeeAtom()
    {

        if(currentTarget.GetTarget() == transform.parent.gameObject){
            
            for(int i=0;i<disappear.Length;i++){
                disappear[i].SetActive(false);
            }
            for(int i=0;i<appear.Length;i++){
                appear[i].SetActive(true);
            }
            anim.SetBool("Translate",true);
            anim.SetBool("Return", false);
        }

    }

    public void NoSeeAtom()
    {
        if(currentTarget.GetTarget() == transform.parent.gameObject){
            for(int i=0;i<disappear.Length;i++){
                disappear[i].SetActive(true);
            }
            for(int i=0;i<appear.Length;i++){
                appear[i].SetActive(false);
            }
            anim.SetBool("Translate",false);
            anim.SetBool("Return", true);
        }
    }

    /*IEnumerator TranslateAtom()
    {
        
        while(transform.position.x < 0 && transform.position.z > 0){

            transform.Translate(new Vector3(0.1f,0,-0.1f)*Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }

    }*/
}
