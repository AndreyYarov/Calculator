using UnityEngine;

namespace Calculator.Data
{
    public class DataController
    {
        private const string HistoryKey = "HISTORY";
        private const string EquationKey = "EQUATION";
        
        public CalculatorData Data { get; }
        
        public DataController()
        {
            var equation = PlayerPrefs.GetString(EquationKey);
            var history = PlayerPrefs.GetString(HistoryKey);
            Data = new CalculatorData(equation, history);
            Data.HistoryChanged += DataHistoryChanged;
            Data.EquationChanged += DataEquationChanged;
        }

        private void DataHistoryChanged(object sender, string history)
        {
            PlayerPrefs.SetString(HistoryKey, history);
            PlayerPrefs.Save();
        }

        private void DataEquationChanged(object sender, string equation)
        {
            PlayerPrefs.SetString(EquationKey, equation);
            PlayerPrefs.Save();
        }
    }
}
