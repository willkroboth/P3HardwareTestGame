using System;
using System.Collections.Generic;
using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.P3App.Data;
using Multimorphic.P3App.Modes.Data;
using Multimorphic.P3App.Logging;

namespace PinballClub.WeirdAlTestGame.Modes.Data
{
	public class WeirdAlTestGameHighScoresMode : HighScoresMode
	{
		private const int DATA_VERSION = 7;
		private const int DB_VERSION = 4;
		private List<HighScoreCategory> categories;

		public WeirdAlTestGameHighScoresMode (P3Controller controller, int priority)
			: base(controller, priority)
		{
			DataVersion = DATA_VERSION;
			DBVersion = DB_VERSION;
		}

		public WeirdAlTestGameHighScoresMode (P3Controller controller, int priority, string eventName, string eventDir)
			: base(controller, priority, eventName, eventDir)
		{
			DataVersion = DATA_VERSION;
			DBVersion = DB_VERSION;
		}

	} 

}

