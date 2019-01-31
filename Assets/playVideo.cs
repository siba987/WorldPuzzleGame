using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class playVideo : MonoBehaviour {


	public VideoClip videoToPlay;
	public VideoPlayer videoPlayer;
	private VideoSource videoSource;

	// Use this for initialization
	void Start () {
		videoPlayer = gameObject.AddComponent<VideoPlayer>();
		videoPlayer.playOnAwake =false;

		//initialise video clip
        //videoToPlay = (VideoSource)gameObject.AddComponent<VideoSource>();
        videoPlayer.source = VideoSource.VideoClip;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void play(){
		//videoPlayer.SetActive(true);
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();

		//play video
		videoPlayer.Play();
	}
}
