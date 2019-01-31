using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachGif : MonoBehaviour {

	[SerializeField] private Texture2D[] frames;
    [SerializeField] private float fps = 10.0f;
    public Renderer Lock;

    private Material mat;

    void Start () {
        mat = GetComponent<Renderer> ().material;
    }

    void UpdateFrame (int index) {
		//if(unlock_africa){
			//int index = (int)(Time.time * fps);
			index = index % frames.Length;
			mat.mainTexture = frames[index]; // usar en planeObjects
			//GetComponent<RawImage> ().texture = frames [index];
		//}
    }
}
