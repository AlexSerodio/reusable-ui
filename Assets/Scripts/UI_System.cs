using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ReusableUI
{
    public class UI_System : MonoBehaviour {

		#region Variables
		
		[Header("System Events")]
		public UnityEvent onSwitchScreen = new UnityEvent();

		[Header("Fader Properties")]
		public Image m_Fader;
		public float m_FadeInDuration = 1f;
		public float m_FadeOutDuration = 1f;

		private Component[] screems = new Component[0];
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
			screems = GetComponentsInChildren<UI_Screen>(true);
		
			if(m_Fader)
				m_Fader.gameObject.SetActive(true);

			FadeIn();
		}
		
		
		#endregion

		#region Helper Methods

		public void SwitchScreen(UI_Screen aScreen) {
			if(aScreen) {
				if(currentScreen) {
					// currentScreen.Close();
					previousScreen = currentScreen;
				}

				currentScreen = aScreen;
				currentScreen.gameObject.SetActive(true);
				// currentScreen.StartScreen();

				if(onSwitchScreen != null)
					onSwitchScreen.Invoke();
			}
		}

		public void FadeIn() {
			if(m_Fader) {
				m_Fader.CrossFadeAlpha(0f, m_FadeInDuration, false);
			}
		}

		public void FadeOut() {
			if(m_Fader) {
				m_Fader.CrossFadeAlpha(0f, m_FadeOutDuration, false);
			}
		}

		public void GoToPreviousScreen() {
			if(previousScreen)
				SwitchScreen(previousScreen);
		}

		public void LoadScreen(int sceneIndex) {
			StartCoroutine(WaitToLoadScene(sceneIndex));
		}

		private IEnumerator WaitToLoadScene(int sceneIndex) {
			
			yield return null;
		}
		#endregion
	}
}