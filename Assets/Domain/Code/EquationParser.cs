namespace Calculator.Domain
{
    public static class EquationParser
    {
        private const string ErrorMessage = "ERROR";
        
        public static string Solve(string equation)
        {
            var parts = equation.Split('+', 2);
            
            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out var leftOperand) || 
                !int.TryParse(parts[1], out var rightOperand))
            {
                return ErrorMessage;
            }

            var sum = leftOperand + rightOperand;
            return sum.ToString();
        }
    }
}
