using UnityEngine;

public class cameraResponsiveResolution : MonoBehaviour {
    public SpriteRenderer mainBG;

	// Use this for initialization
	void Start () {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = mainBG.bounds.size.x / mainBG.bounds.size.y;

        if(screenRatio > targetRatio){
            Camera.main.orthographicSize = mainBG.bounds.size.y / 2;
        }else{
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = mainBG.bounds.size.y / 2 * differenceInSize;
        }
	}
}