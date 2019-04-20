using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ReusableUI {
	
    public class UI_System : MonoBehaviour {

		#region Variables
		
		[Header("System Events")]
		public UI_Screen startScreen;

		[Header("System Events")]
		public UnityEvent onSwitchScreen = new UnityEvent();

		[Header("Fader Properties")]
		public Image fader;
		public float fadeInDuration = 1f;
		public float fadeOutDuration = 1f;

		private Component[] screens = new Component[0];
		private UI_Screen currentScreen;
		private UI_Screen previousScreen;
		
		public UI_Screen CurrentScreen {
			get { return currentScreen; }
		}

		public UI_Screen PreviousScreen {
			get { return previousScreen; }
		}
		#endregion

		#region Main Methods
		// Use this for initialization
		void Start () {
			screens = GetComponentsInChildren<UI_Screen>(true);
			InitializeScreens();

			if(startScreen)
				SwitchScreen(startScreen);

			if(fader)
				fader.gameObject.SetActive(true);

			FadeIn();
		}
		
		
		#endregion

		#region Helper Methods

		public void SwitchScreen(UI_Screen aScreen) {
			if(aScreen) {
				if(currentScreen) {
					currentScreen.CloseScreen();
					previousScreen = currentScreen;
				}

				currentScreen = aScreen;
				currentScreen.gameObject.SetActive(true);
				currentScreen.StartScreen();

				if(onSwitchScreen != null)
					onSwitchScreen.Invoke();
			}
		}

		public void FadeIn() {
			if(fader)
				fader.CrossFadeAlpha(0f, fadeInDuration, false);
		}

		public void FadeOut() {
			if(fader)
				fader.CrossFadeAlpha(0f, fadeOutDuration, false);
		}

		public void GoToPreviousScreen() {
			if(previousScreen)
				SwitchScreen(previousScreen);
		}

		void InitializeScreens() {
            foreach(var screen in screens) {
                screen.gameObject.SetActive(true);
            }
        }
		#endregion
	}
}