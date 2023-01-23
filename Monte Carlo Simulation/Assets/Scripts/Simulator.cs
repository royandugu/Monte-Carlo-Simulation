using UnityEngine;
using TMPro;
public class Simulator : MonoBehaviour
{
    public GameObject[] allClones;
    public GameObject point;
    private int testPoints,cloneNo=0;
    public TextMeshProUGUI result;
    public TMP_InputField field;
    private float inside;
    private bool simulated=false;

    private void Start(){
        allClones=new GameObject[10000];
    }
    // Start is called before the first frame update
    public void GeneratePoints(){
        inside=0;
        testPoints=int.Parse(field.text);
        for(int i=0;i<cloneNo;i++){
            Destroy(allClones[i]);
        }
        cloneNo=0;
        for(int i=0;i<testPoints;i++){
            GameObject clone=Instantiate(point, new Vector3(Random.Range(-100f,100f),Random.Range(-100f,100f),0f),Quaternion.identity);
            if(!(Mathf.Pow(clone.transform.position.x,2f)+Mathf.Pow(clone.transform.position.y,2f)< Mathf.Pow(100f,2))){
                Destroy(clone);
            }
            else {
                allClones[cloneNo]=clone;
                inside++;
                cloneNo++;
            }
        }
        CalculatePi();
    }

    public void CalculatePi(){
        float value=inside/testPoints*4;
        result.text=value.ToString();
    }
}
