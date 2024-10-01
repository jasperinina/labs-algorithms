namespace Graph.Logic.Mathematical_Operations.Polynomial_Operation;

public class HornerPolynomial : PolynomialOperations
{
    // Вычисление многочлена методом Горнера
    public override double Evaluate(double x, double[] coefficients)
    {
        double result = 0;
        int n = coefficients.Length;

        // Вычисляем по схеме Горнера
        for (int k = n - 1; k >= 0; k--)
        {
            result = result * x + coefficients[k];
        }

        return result;
    }
}