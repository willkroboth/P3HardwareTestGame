using System;
using System.Collections.Generic;
using Multimorphic.NetProcMachine.Machine;
using Multimorphic.P3;
using Multimorphic.P3App.Modes.Selector;

namespace PinballClub.WeirdAlTestGame.Modes.Menu
{

    public class WeirdAlTestGameNameEditorMode : SelectorMode
	{
		public WeirdAlTestGameNameEditorMode (P3Controller controller, int priority)
			: base(controller, priority)
		{
			selectorId = "NameEditor";

			buttonLegend["LeftWhiteButton"] = "Shift";
			buttonLegend["RightWhiteButton"] = "Shift";
			buttonLegend["LeftRedButton"] = "Left";
			buttonLegend["RightRedButton"] = "Right";
			buttonLegend["LeftYellowButton"] = "Backspace";
			buttonLegend["RightYellowButton"] = "Enter";
			buttonLegend["StartButton"] = "Backspace";
			buttonLegend["LaunchButton"] = "Enter";
		}
	} 

}

