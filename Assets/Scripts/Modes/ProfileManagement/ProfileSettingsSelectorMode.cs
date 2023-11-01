using Multimorphic.P3;

namespace PinballClub.WeirdAlTestGame.Modes.Menu
{

    public class ProfileSettingsSelectorMode : SettingsSelectorMode
	{
		public ProfileSettingsSelectorMode (P3Controller controller, int priority)
			: base(controller, priority)
		{
			selectorId = "ProfileAttributeSelector";
		}

	}
}

