using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ErrorDisplayer : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private TextMeshProUGUI textError;

        private static readonly int ShowErrorTrigger = Animator.StringToHash("showError");
        private static readonly int HideErrorTrigger = Animator.StringToHash("hideError");

        private Coroutine _hideCoroutine;

        /// <summary>
        /// <para>Displays an error on the bottom of the screen</para>
        /// </summary>
        /// <param name="error">The message that will be shown</param>
        /// <param name="secondsShowing">The time that the message will be displayed</param>
        public void ShowError(string error, float secondsShowing = 2)
        {
            textError.text = error;
            animator.SetTrigger(ShowErrorTrigger);
            CancelCoroutine();
            _hideCoroutine = StartCoroutine(WaitUntilHideError(secondsShowing));
        }

        private void HideError()
        {
            CancelCoroutine();
            animator.SetTrigger(HideErrorTrigger);
        }

        private IEnumerator WaitUntilHideError(float secondsUntilHideError)
        {
            yield return new WaitForSeconds(secondsUntilHideError);
            HideError();
        }

        private void CancelCoroutine()
        {
            if(_hideCoroutine != null) StopCoroutine(_hideCoroutine);
        }

    }
}
