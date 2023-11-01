// Copyright � 2019 Multimorphic, Inc. All Rights Reserved

using Multimorphic.P3;
using Multimorphic.P3App.Modes.Data;

namespace PinballClub.WeirdAlTestGame.Modes.Data {

	public class WeirdAlTestGameEventProfileManagerMode : EventProfileManagerMode {

		public WeirdAlTestGameEventProfileManagerMode(P3Controller controller, int priority)
			: base(controller, priority) {
		}

		protected override void AddEventProfileMode(string eventProfileName) {
			eventProfiles[eventProfileName] = new WeirdAlTestGameEventProfileMode(p3, Priority, eventProfileName, GetEventProfileDirectory(eventProfileName));
		}
	}
}