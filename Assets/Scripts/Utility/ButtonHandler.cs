using UnityEngine;
using Multimorphic.P3App.GUI;
using PinballClub.WeirdAlTestGame.Modes;

namespace PinballClub.WeirdAlTestGame.Utility
{
	public class ButtonHandler : P3Aware
	{
		public string eventName;

		public void OnTriggerEnter(Collider other)
        {
			// Respond to ball hits
			if (other.name == "BallAvatarTrail")
			{
				Multimorphic.P3App.Logging.Logger.Log("Sending button event: " + eventName);
				PostGUIEventToModes(WeirdAlTestGameEventNames.ButtonHit + eventName, null);
			}
		}

		// Use this for initialization
		public override void Start()
		{

		}

		protected override void CreateEventHandlers()
		{
			base.CreateEventHandlers();
		}

		// Update is called once per frame
		public override void Update()
		{

		}
	}
}
