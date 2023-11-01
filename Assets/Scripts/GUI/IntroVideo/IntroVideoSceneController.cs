using UnityEngine;
using System.Collections;
using PinballClub.WeirdAlTestGame.GUI;
using Multimorphic.P3App.GUI;

namespace PinballClub.WeirdAlTestGame.GUI {

	public class IntroVideoSceneController : WeirdAlTestGameSceneController {

		public bool useAlternateAudio;
		private AudioSource alternateAudio;
		private GameObject P3PlayfieldObj;
		private GameObject WeirdAlTestGameAudioObj;

		// Use this for initialization
		public override void Start () {
			base.Start ();

			GameObject obj = GameObject.Find ("AlternateAudio");
			if (obj) {
				alternateAudio = obj.GetComponent<AudioSource>();
				alternateAudio.gameObject.SetActive (useAlternateAudio);
			}

			// Turn off playfield so that video runs smoothly
			P3PlayfieldObj = GameObject.Find ("P3Playfield(Clone)");
			if (P3PlayfieldObj)
				P3PlayfieldObj.SetActive(false);

			WeirdAlTestGameAudioObj = GameObject.Find ("WeirdAlTestGameAudio(Clone)");
			if (WeirdAlTestGameAudioObj) {
				WeirdAlTestGameAudioObj.SetActive(!useAlternateAudio);
				WeirdAlTestGameAudioObj.GetComponent<WeirdAlTestGameAudio>().moveWithCamera = false;
			}

			WeirdAlTestGameAudio.Instance.ChangePlaylistByName("IntroAnimAudio");
		}

		protected override void CreateEventHandlers() {
			base.CreateEventHandlers ();
			AddModeEventHandler("Evt_StopIntroVideo", StopVideo);
		}
		
		// Update is called once per frame
		public override void Update () {
			IntroActive = false;
			base.Update ();
		}

		protected override void SceneLive() {
			base.SceneLive();
		}

		private void StopVideo(string eventName, object eventObject) {
            if (WeirdAlTestGameAudio.Instance)
                WeirdAlTestGameAudio.Instance.StopAllPlaylists();
		}

		protected override void OnDestroy () {
            if (WeirdAlTestGameAudio.Instance)
                WeirdAlTestGameAudio.Instance.StopAllPlaylists();

			// Reneable objects for normal gameplay
			if (P3PlayfieldObj)
				P3PlayfieldObj.SetActive(true);

			if (WeirdAlTestGameAudioObj) {
				WeirdAlTestGameAudioObj.SetActive(true);
				WeirdAlTestGameAudioObj.GetComponent<WeirdAlTestGameAudio>().moveWithCamera = true;
			}

			base.OnDestroy();
		}
	}
}