using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Vuforia{

public class TextOnTrigger : MonoBehaviour {
	public Transform textDesc;
	public Transform textTarget;
	public Transform PanelDescription;
	//public Transform ButtonAction;

	/*public GameObject videoSphere;
	VideoSource videoSource;
	public int timeToStop = 5;*/

	// Use this for initialization
	void Start () {

		textDesc.gameObject.SetActive(false);
		textTarget.gameObject.SetActive(false);
		PanelDescription.gameObject.SetActive(false);
		//videoSphere.SetActive(false);

	}
	
	// show descr onTriggerEnter
	public void onTriggerEnter () {
	//	videoPlayer.SetActive(true);
		

		//PanelDescription.transform.position = gameObject.transform.position;
		PanelDescription.gameObject.SetActive(true);
		textDesc.gameObject.SetActive(true);
		textTarget.gameObject.SetActive(true);
		//videoSphere.SetActive(true);

		//set time
		//Destroy(videoSphere, timeToStop);
			//ButtonAction.gameObject.SetActive(true);
		//videoPlayer.source = VideoSource.VideoClip;

		string name = gameObject.name;
		Debug.Log("gameObj::: " + name);

			if(name=="giraffe"){
				textTarget.GetComponent<Text>().text =  "Australian giraffe";
				textDesc.GetComponent<Text>().text =  "Do you know why giraffes have long necks? Because their heads are far away :D";


			}

			if (name =="didgeridoo"){
				textTarget.GetComponent<Text>().text =  "Didgeridoo";
				textDesc.GetComponent<Text>().text =  "Didgeridoos are musical instruments native to the Aboriginals in Australia. Have you ever heard it be played?"; 
				
				
				//PlayVideo();
			}

			if (name=="Koala"){
				textTarget.GetComponent<Text>().text =  "Koala";
				textDesc.GetComponent<Text>().text =  "Koalas are gentle animals native to Australia who love to cuddle. Did you know they can sleep for up to 18 hours a day?!";
			}
		/*videoPlayer.transform.position = gameObject.transform.position;
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();

		//play video
		videoPlayer.Play();*/
	}

	/*public void PlayVideo(string videoName)
     {
         VideoClip clip = Resources.Load<VideoClip>(videoName) as VideoClip;
         vp_VideoPlayerRef.clip = videoToPlay;
         vp_VideoPlayerRef.Play();
     }*/
}



}
