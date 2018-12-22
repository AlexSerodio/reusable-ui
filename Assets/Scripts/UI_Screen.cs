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
		public Selectable m_StartSelectable;	// the element that will start highlighted

		[Header("Screen Events")]
		public UnityEvent onScreenStart = new UnityEvent();
		public UnityEvent onScreenClose = new UnityEvent();

		private Animator animator;

		#endregion



		#region Main Methods
		
		void Awake () {
			animator = GetComponent<Animator>();

			if(m_StartSelectable)
				EventSystem.current.SetSelectedGameObject(m_StartSelectable.gameObject);
		}
		
		#endregion

	

		#region Helper Methods

		public virtual void StartScreen() {
			if(onScreenStart != null) {
				onScreenStart.Invoke();
			}
			HandleAnimator("show");
		}

		public virtual void CloseScreen() {
			if(onScreenClose != null) {
				onScreenClose.Invoke();
			}

			HandleAnimator("hide");
		}

		private void HandleAnimator(string aTrigger) {
			if(animator) {
				animator.SetTrigger(aTrigger);
			}
		}

		#endregion
	}
}