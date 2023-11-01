// Copyright � 2019 Multimorphic, Inc. All Rights Reserved

using Multimorphic.P3;
using Multimorphic.P3App.Modes;
using Multimorphic.P3App.Modes.Data;

namespace PinballClub.WeirdAlTestGame.Modes.Data {

	public class WeirdAlTestGameEventProfileMode : EventProfileMode {

		public WeirdAlTestGameEventProfileMode(P3Controller controller, int priority, string eventProfileName, string eventProfileDir)
			: base(controller, priority, eventProfileName, eventProfileDir) {
			highScoresMode = new WeirdAlTestGameHighScoresMode(p3, Priorities.PRIORITY_HIGH_SCORES, eventProfileName, eventProfileDir);
			statisticsMode = new WeirdAlTestGameStatisticsMode(p3, Priority, eventProfileName, eventProfileDir);
		}
	}
}