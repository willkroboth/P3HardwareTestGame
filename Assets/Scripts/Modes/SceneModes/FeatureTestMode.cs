using System;
using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.NetProcMachine.Machine;
using System.Collections.Generic;

namespace PinballClub.WeirdAlTestGame.Modes
{

	public class FeatureTestMode : SceneMode
	{
		private bool _ballStarted;
		// private SomeRelatedMode someRelatedMode;

		public FeatureTestMode (P3Controller controller, int priority, string SceneName)
			: base(controller, priority, SceneName)
		{
			// AddModeEventHandler("Evt_SomeModeEventName", SomeHandlerFunction, priority);
			_ballStarted = false;
			AddModeEventHandler(WeirdAlTestGameEventNames.InitialLaunch, InitialLaunchEventHandler, Priority);

			AddGUIEventHandler(WeirdAlTestGameEventNames.ButtonHit + "Walls", WallsButtonHitHandler);
			AddGUIEventHandler("Evt_Wall", WallHitHandler);

			AddGUIEventHandler(WeirdAlTestGameEventNames.ButtonHit + "Scoops", ScoopsButtonHitHandler);
			AddModeEventHandler("Evt_ScoopHit", ScoopHitEventHandler, Priority);

			//AddGUIEventHandler(WeirdAlTestGameEventNames.ButtonHit + "LEDs", LEDsButtonHitHandler);
		}

		private bool wallsUp = false;
		private void WallsButtonHitHandler(string name, object data)
        {
			if (wallsUp) return;
			Multimorphic.P3App.Logging.Logger.Log("Processing Wall Button Event");

			p3.wallScoopMode.RaiseWalls(Multimorphic.P3.Mechs.WallScoopSequence.FromLeft);
			wallsUp = true;
		}
		private void WallHitHandler(string name, object data)
		{
			if (!wallsUp) return;
			Multimorphic.P3App.Logging.Logger.Log("Processing Wall Hit Event");

			p3.wallScoopMode.LowerWalls(Multimorphic.P3.Mechs.WallScoopSequence.FromLeft);
			wallsUp = false;
		}

		private void ScoopsButtonHitHandler(string name, object data)
        {
			int index = UnityEngine.Random.Range(0, 5);
			p3.wallScoopMode.RaiseScoop(index);
        }
		private bool ScoopHitEventHandler(string name, object data)
        {
			int doorNum = (int)data;
			p3.wallScoopMode.LowerScoop(doorNum);

			return SWITCH_STOP;
        }

		//private List<LEDScript> ledScripts;

		//private void setupLEDs()
  //      {
		//	double sweepDuration = 1.0;
		//	double onTime = sweepDuration / sweepLEDs.Count;
		//	double onFadeTime = onTime / 2.0;
		//	ledScripts = new List<LEDScript>();

		//	for (int i = 0; i < sweepLEDs.Count; i++)
		//	{
		//		LEDScript script = new LEDScript(sweepLEDs[i], priority);
		//		ledScripts.Add(script);
		//		script.AddCommand(Multimorphic.P3.Colors.Color.white, onFadeTime, onTime);
		//		script.autoRemove = true;
		//	}
		//}

		//private void LEDsButtonHitHandler(string name, object data)
  //      {
		//	// Instantiate a new LED Script
		//	LEDScript wall0Script = new LEDScript(p3.LEDs["wall0"], priority);

		//	// Define the LED effects the script should make happen
		//	wall0Script.Clear();   // Not needed the first time, but you can clear a script at anyt ime to set up a new pattern.  Be sure to stop the LEDController from running the script before clearing it.

		//	wall0Script.AddCommand(Multimorphic.P3.Colors.Color.blue, 0, 0.5);  // Turn the LED blue instantly, and leave it blue for 0.5s.  

		//	wall0Script.AddCommand(Multimorphic.P3.Colors.Color.red, 0.1, 0.5);  // Turn the LED red for 0.5s.  During the first 0.1s of that 0.5s, it should fade from the previous color

		//	wall0Script.AddCommand(Multimorphic.P3.Colors.Color.white, 1.0, 1.0);  // Fade the LED to white over the course of 1s. 

		//	wall0Script.autoRemove = false; // Do not auto-remove the script when it finishes running the commands (ie. leave the LED the color of the last command)

		//	wall0Script.scriptName = "wall0Script_sequenceA";  // Setting the name isn't required, but it can sometimes be useful when managing multiple scripts. 


		//	// Add the script to the LEDController to start it.
		//	p3.LEDController.AddScript(wall0Script, -1, 0);  // RunTime == -1 will repeat the script until it is removed.  Delay == 0 means start running it immediately

		//	// RunTime of 0 will run the script fully once.  RunTime > 0 will only run the script until it finishes or until the time expires, whichever is shorter.
		//}

		protected override void LaunchCallback()
		{
			Multimorphic.P3App.Logging.Logger.Log("Launch Callback. Ball Launched");
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableBallSearch, true);
		}

		public bool sw_launch_active(Switch sw)
		{
			if (!_ballStarted)
			{
				_ballStarted = true;
				PostModeEventToModes(WeirdAlTestGameEventNames.InitialLaunch, null);
			}
			return SWITCH_CONTINUE;
		}

		public bool sw_launch_active_for_2s(Switch sw)
		{
			Multimorphic.P3App.Logging.Logger.Log("Debug Launch.");
			WeirdAlTestGameBallLauncher.launch();
			return SWITCH_CONTINUE;
		}

		public bool InitialLaunchEventHandler(string eventName, object eventData)
		{
			PostModeEventToModes(WeirdAlTestGameEventNames.BallStarted, 0);
			PostModeEventToModes(WeirdAlTestGameEventNames.ChangeGameState, GameState.BallInPlay);
			WeirdAlTestGameBallLauncher.launch(LaunchCallback);
			return EVENT_STOP;
		}

		public override void mode_started ()
		{
			base.mode_started ();

			// p3.AddMode(someRelatedMode);

			// AddGUIEventHandler ("Evt_SomeGUIEventName", SomeHandlerFunction);
			// AddModeEventHandler ("SomeModeEventName", SomeHandlerFunction, priority);
		}

		public override void mode_stopped ()
		{
			// p3.RemoveMode (someRelatedMode);
			// RemoveGUIEventHandler ("Evt_SomeGUIEventName", SomeHandlerFunction);
			// RemoveModeEventHandler ("Evt_SomeModeEventName", SomeHandlerFunction, priority);
			// p3.RemoveMode(someRelatedMode);
			base.mode_stopped();
		}

		public override void LoadPlayerData()
		{
			base.LoadPlayerData();
			// Add any special data loading needed here for this scene and this player
		}

		public override void SavePlayerData()
		{
			base.SavePlayerData();
			// Add any special data loading needed here for this scene and this player
		}

		public override void SceneLiveEventHandler( string evtName, object evtData )
		{
			//base.SceneLiveEventHandler(evtName, evtData);
			// Add any special setup that the scene requires here, including sending messages to the GUI.
			StartPlaying();
		}

		protected override void StartPlaying()
		{
			base.StartPlaying();
			_ballStarted = false;

			// Enable the flippers, slings and pop bumpers.
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableFlippers, true);
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableBumpers, true);
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableBallSearch, false);

			PostModeEventToGUI("Evt_FeatureTestSetup", 0);

			// PostInstructionEvent("Some instructions");
			WeirdAlTestGameBallLauncher.launch ();
		}

		protected override void Completed(long score)
		{
			base.Completed (score);
			PostModeEventToModes ("Evt_FeatureTestCompleted", 0);
		}


		public bool sw_slingL_active(Switch sw)
		{
			// Add code here to let he GUI side know about that a sling has been hit
			//e.g. PostModeEventToGUI("Evt_FeatureTestSlingHit", false);

			return SWITCH_CONTINUE;   // use SWITCH_STOP to prevent other modes from receiving this notification.
		}

		public bool sw_slingR_active(Switch sw)
		{
			// Add code here to let he GUI side know about that a sling has been hit
			// e.g. PostModeEventToGUI("Evt_FeatureTestSlingHit", false);
			return SWITCH_CONTINUE;   // use SWITCH_STOP to prevent other modes from receiving this notification.
		}

		public bool sw_drain_active(Switch sw)
		{
			PostModeEventToModes(WeirdAlTestGameEventNames.BallDrained, 0);
			End();

			return SWITCH_CONTINUE;
		}

		public override void End()
		{
			Pause();
			base.End();
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableFlippers, false);
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableBumpers, false);
			PostModeEventToModes(WeirdAlTestGameEventNames.EnableBallSearch, false);
			PostModeEventToModes(WeirdAlTestGameEventNames.BallEnded, null);
		}

		public void Pause()
		{
			p3.ModesToGUIEventManager.Post("Evt_ScenePause", null);
		}

		public override ModeSummary getModeSummary()
		{
			ModeSummary modeSummary = new ModeSummary();
			modeSummary.Title = sceneName;
			modeSummary.Completed = modeCompleted;
			if (modeCompleted) 
				modeSummary.SetItemAndValue(0, "FeatureTest completed!", "");
			else
				modeSummary.SetItemAndValue(1, "FeatureTest not yet completed!", "");
			modeSummary.SetItemAndValue(2, "", "");
			return modeSummary;
		}
	}
}
