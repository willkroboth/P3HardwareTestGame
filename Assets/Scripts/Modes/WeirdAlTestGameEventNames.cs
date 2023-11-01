using Multimorphic.P3App.Modes;

namespace PinballClub.WeirdAlTestGame.Modes
{
	public static class WeirdAlTestGameEventNames
    {
        // Framework events
        public const string EnableFlippers = "Evt_EnableFlippers";
        public const string EnableBumpers = "Evt_EnableBumpers";
        public const string BallStarted = "Evt_BallStarted";
        public const string BallEnded = "Evt_BallEnded";
        public const string ChangeGameState = "Evt_ChangeGameStates";
        public const string EnableBallSearch = "Evt_EnableBallSearch";
        public const string SideTargetHit = "Evt_SideTargetHit";
        public const string LeftSlingHit = "Evt_LeftSlingHit";
        public const string RightSlingHit = "Evt_RightSlingHit";

        // App events
        public const string InitialLaunch = "Evt_InitialLaunch";
        public const string BallDrained = "Evt_BallDrained";
        public const string ButtonHit = "Evt_ButtonHit";
    }
}
