using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ReusableUI {
	
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(CanvasGroup))]
    public class UI_Screen : MonoBehaviour {

		#region Variables
		[Header("Main Properties")]
		public Selectable startSelectable;	// the element that will start highlighted

		[Header("Screen Events")]
		public UnityEvent onScreenStart = new UnityEvent();
		public UnityEvent onScreenClose = new UnityEvent();

		private Animator animator;
		private const string SHOW_TRIGGER = "show";
		private const string HIDE_TRIGGER = "hide";

		#endregion

		#region Main Methods
		
		void Awake () {
			animator = GetComponent<Animator>();

			if(startSelectable)
				EventSystem.current.SetSelectedGameObject(startSelectable.gameObject);
		}
		
		#endregion

	

		#region Helper Methods

		public virtual void StartScreen() {
			if(onScreenStart != null)
				onScreenStart.Invoke();

			HandleAnimator(SHOW_TRIGGER);
		}

		public virtual void CloseScreen() {
			if(onScreenClose != null)
				onScreenClose.Invoke();

			HandleAnimator(HIDE_TRIGGER);
		}

		private void HandleAnimator(string aTrigger) {
			if(animator) {
				animator.SetTrigger(aTrigger);
			}
		}

		#endregion
	}
}