using System;
using System.Text;

namespace Calculator.Data
{
    public class CalculatorData
    {
        public event EventHandler<string> HistoryChanged;
        public event EventHandler<string> EquationChanged; 

        private readonly StringBuilder _history;
        private string _equation;

        public CalculatorData(string equation, string history)
        {
            _equation = equation;
            _history = new StringBuilder(history);
        }

        public void AppendHistory(string line)
        {
            _history.AppendLine(line);
            HistoryChanged?.Invoke(this, History);
        }

        public string Equation
        {
            get => _equation;
            set
            {
                if (string.Equals(_equation, value))
                {
                    return;
                }

                _equation = value;
                EquationChanged?.Invoke(this, _equation);
            }
        }

        public string History => _history.ToString();
    }
}
