using Multimorphic.NetProcMachine.Machine;
using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.P3App.Modes.Data;
using PinballClub.WeirdAlTestGame.Modes.Data;
using System;
using System.Collections.Generic;

namespace PinballClub.WeirdAlTestGame.Modes.Data
{
    public class WeirdAlTestGameGameAttributeManagerMode : GameAttributeManagerMode
	{
		List<HighScoreCategory> highScoreCats;
		public WeirdAlTestGameGameAttributeManagerMode (P3Controller controller, int priority)
			: base(controller, priority)
		{
		}

		protected override void InstantiateAndAddModes()
		{
			base.InstantiateAndAddModes();

			settingsMode = new WeirdAlTestGameSettingsMode (p3, Priority);
			// Use PRIORITY_HIGH_SCORES mode for the high score logic so the score boards work properly in Attract Mode.
			highScoresMode = new WeirdAlTestGameHighScoresMode (p3, Priorities.PRIORITY_HIGH_SCORES);
			statisticsMode = new WeirdAlTestGameStatisticsMode (p3, Priority);

			eventProfileManagerMode = new WeirdAlTestGameEventProfileManagerMode(p3, Priority+1);
		}

		public override void mode_started ()
		{
			base.mode_started ();
			highScoreCats = WeirdAlTestGameHighScoreCategories.GetCategories();
			SendHSCatsToHSModes();
		}


		private void SendHSCatsToHSModes()
		{
			foreach (HighScoreCategory cat in highScoreCats)
			{
				PostModeEventToModes ("Evt_AddHighScoreCategory", cat);
			}
		}

		protected override bool NewEventProfileAddedEventHandler (string evtName, object evtData)
		{
			SendHSCatsToHSModes();
			return base.NewEventProfileAddedEventHandler (evtName, evtData);
		}

		protected override void CreateStockProfiles()
		{
			base.CreateStockProfiles();
            /*
			profileManagerMode.AddStockProfile ("Default");
			profileManagerMode.AddStockProfile ("Easy");
			profileManagerMode.AddStockProfile ("Medium");
			profileManagerMode.AddStockProfile ("Hard");
			profileManagerMode.AddStockProfile ("Custom");
            */

            /*
			settingsMode.UpdateStockProfileAttributes ("Default");
			settingsMode.UpdateStockProfileAttributes ("Easy");
			settingsMode.UpdateStockProfileAttributes ("Medium");
			settingsMode.UpdateStockProfileAttributes ("Hard");
			settingsMode.UpdateStockProfileAttributes ("Custom");
            */
		}

	} 

}

