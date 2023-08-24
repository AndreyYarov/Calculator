using Calculator.Data;
using Calculator.UI;
using UnityEngine;

namespace Calculator.Launcher
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private CalculatorWindow calculatorWindow;

        private DataController _dataController;
        private CalculatorPresenter _calculatorPresenter;

        private void Awake()
        {
            _dataController = new DataController();
            _calculatorPresenter = new CalculatorPresenter(_dataController.Data, calculatorWindow);
        }
    }
}
