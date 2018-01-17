using DemoCalculatorClient.Model;

namespace DemoCalculatorClient.Business
{
    /// <summary>
    /// Calculator repository interface used to evaluate equations
    /// </summary>
    public interface ICalculatorRepository
    {
        int Calculate(Operation opModel);
    }
}
