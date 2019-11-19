using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterDragControl : MonoBehaviour
{
    Animator anim;
    float startPosX;
    float startPosY;
    [SerializeField] bool isDrag = false;

    public GameObject dropbox;
    SpriteRenderer dropArea;

    void Awake() {
        anim = GetComponent<Animator>();
        dropArea = dropbox.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (isDrag)
        {
            Vector3 mousePos = getMousePos();

            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX,
                                                mousePos.y - startPosY, this.transform.localPosition.z);
        }
    }

    private static Vector3 getMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }

    private void OnMouseDown() {
        if (buttonManager.Instance.isStarted())
        {
            Destroy(anim);    //destroy animator
            
            Vector3 mousePos = getMousePos();

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isDrag = true;
        }
    }

    private void OnMouseUp() {
        isDrag = false;
        Debug.Log(dropArea.bounds);
        if (dropArea.bounds.Contains(this.transform.position))
        {
            SceneManager.LoadScene("Level 2");
        }        
    }
}
