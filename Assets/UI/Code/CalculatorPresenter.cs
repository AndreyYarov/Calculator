using System;
using Calculator.Data;
using Calculator.Domain;

namespace Calculator.UI
{
    public class CalculatorPresenter
    {
        private readonly CalculatorData _data;
        private readonly CalculatorWindow _window;

        public CalculatorPresenter(CalculatorData data, CalculatorWindow window)
        {
            _data = data;
            data.HistoryChanged += ModelHistoryChanged;

            _window = window;
            window.EquationChanged += WindowEquationChanged;
            window.SubmitButtonPressed += WindowSubmitButtonPressed;
            _window.UpdateEquation(_data.Equation);
            _window.UpdateHistory(_data.History);
        }

        private void ModelHistoryChanged(object sender, string history)
        {
            _window.UpdateHistory(history);
        }

        private void WindowEquationChanged(object sender, string equation)
        {
            _data.Equation = equation;
        }

        private void WindowSubmitButtonPressed(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_data.Equation))
            {
                return;
            }
            
            var solution = EquationParser.Solve(_data.Equation);
            _data.AppendHistory($"{_data.Equation}={solution}");
            _data.Equation = string.Empty;
            _window.UpdateEquation(string.Empty);
        }
    }
}
