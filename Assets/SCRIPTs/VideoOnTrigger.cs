using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Vuforia{

public class VideoOnTrigger : MonoBehaviour {

	public GameObject videoSphere;
	private VideoPlayer vp;
	//public VideoSource videoSource;
//	public VideoClip videoToPlay;

	public int timeToStop = 5;

	// Use this for initialization
	void Start () {

		videoSphere.SetActive(false);
		//vp = gameObject.GetComponent<VideoPlayer>();

	}
	
	// show descr playVideo
	public void playVideo () {
		//vp.SetActive(true);
		
		videoSphere.SetActive(true);

		//set time
		//Destroy(videoSphere, timeToStop);
		
		//videoPlayer.source = VideoSource.VideoClip;

		string name = gameObject.name;
		Debug.Log("gameObj::: " + name);

			if(name=="giraffe"){
				//videoToPlay =Resources.Load<VideoClip>(DidgeridooMusic.mp4);
				
			}

			if (name =="didgeridoo"){
				//videoToPlay =Resources.Load<VideoClip>(DidgeridooMusic.mp4);
				//vp.clip = videoToPlay;
				
			}

			if (name=="Koala"){
				
			}
		
		
		/*vp.Prepare();

		//play video
		vp.Play();*/
	}

	/*public void PlayVideo(string videoName)
     {
         VideoClip clip = Resources.Load<VideoClip>(videoName) as VideoClip;
         vp.clip = videoToPlay;
         vp.Play();
     }*/
}



}
