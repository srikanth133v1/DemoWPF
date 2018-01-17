using DemoCalculatorClient.Model;
using System;

namespace DemoCalculatorClient.Business
{
    /// <summary>
    /// Repository class to evaluate equation
    /// </summary>
    public class CalculatorRepository : ICalculatorRepository
    {
        public double Calculate(Operation opModel)
        {
            switch (opModel.Operator)
            {
                case "+":
                    return opModel.Left + opModel.Right;
                case "-":
                    return opModel.Left - opModel.Right;
                case "*":
                    return opModel.Left * opModel.Right;
                case "/":
                    if (opModel.Right != 0)
                    {
                        return opModel.Left / opModel.Right;
                    }
                    else
                    {
                        throw new DivideByZeroException("Right param (param2) cannot be Zero");
                    }
            }

            throw new Exception("Unable to perform any operation");
        }
    }
}
