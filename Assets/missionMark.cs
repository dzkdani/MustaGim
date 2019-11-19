using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class missionMark : MonoBehaviour
{
    [TextArea] [SerializeField] string textMisiDummy; 
    [SerializeField] float missionReadTime;
    GameObject panelMisi;
    public List<Animator> animators = new List<Animator>();
    void Awake()
    {
        panelMisi = GameObject.FindGameObjectWithTag("panelMisi");
        panelMisi.SetActive(false);
    }

    IEnumerator missionPanel()
    {
        panelMisi.SetActive(true);
        panelMisi.GetComponentInChildren<TextMeshProUGUI>().SetText(textMisiDummy);
        
        animators[0].SetBool("isTouched", true);

        yield return new WaitForSeconds(missionReadTime);
        
        panelMisi.SetActive(false);

        animators[1].SetBool("isMission", true);

        this.gameObject.SetActive(false);
    }

    private void OnMouseDown() {
        StartCoroutine(missionPanel());
    }
}
