using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class buttonManager : MonoBehaviour
{
    public static buttonManager Instance {get; private set;}

    void Awake() {
        Instance = this;
        DontDestroyOnLoad(Instance);    
    }

    [SerializeField] bool isGimStart = false;

    public bool isStarted() {return isGimStart;}


    public Button startButton;
    public List<Animator> animators = new List<Animator>();
    [SerializeField] readonly string AnimParamText = "isStarted";

    public void gimStart()
    {
        StartCoroutine(playAnim());        
    }

    IEnumerator playAnim()
    {

        animators[0].SetBool(AnimParamText, true);
        animators[1].SetBool(AnimParamText, true);

        yield return new WaitForSeconds(3.0f);

        animators[2].SetBool(AnimParamText, true);

        isGimStart = true;

        Destroy(startButton.gameObject, 3.0f);

    }
}
