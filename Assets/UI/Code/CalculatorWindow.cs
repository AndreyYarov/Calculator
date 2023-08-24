using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.UI
{
    public class CalculatorWindow : MonoBehaviour
    {
        public event EventHandler SubmitButtonPressed;
        public event EventHandler<string> EquationChanged;

        [SerializeField] private Button submitButton;
        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private TextMeshProUGUI historyField;

        private void Awake()
        {
            submitButton.onClick.AddListener(() => SubmitButtonPressed?.Invoke(this, EventArgs.Empty));
            inputField.onValueChanged.AddListener(equation => EquationChanged?.Invoke(this, equation));
        }

        public void UpdateHistory(string history)
        {
            historyField.text = history;
        }

        public void ClearInput()
        {
            inputField.text = string.Empty;
        }
    }
}
