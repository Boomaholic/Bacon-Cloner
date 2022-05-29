This Document lists all changes made to the Starter Assets First Person Controller

//FileChanged:

FirstPersonCOntroller.cs 
	@line 77-78
		private PauseMenuAccess _menuAccess;
		private GameOver _gameOver;
	@line 110-111
		_menuAccess = GetComponent<PauseMenuAccess>();
		_gameOver = GetComponent<GameOver>();
	@line 128-138 
		private void LateUpdate()
			{

			//I changed this, locks camera when game Paused
			if (_menuAccess.GetGameIsPaused() || _gameOver.IsGameOver()) { return; }

			if (!_menuAccess.GetGameIsPaused() || !_gameOver.IsGameOver())
				{
				  CameraRotation();
				}
			}

StarterAssetsInputs.cs
	@line 15
		public bool pause;
	@line 42-45
		public void OnPause(InputValue value)
		{
			PauseInput(value.IsPressed);
		}
	@line 69-72
		public void PauseInput(bool newPauseState)
		{
			pause = newPauseState;
		}
