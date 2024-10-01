namespace Graph.Logic.Mathematical_Operations.Polynomial_Operation;

public class NaivePolynomial : PolynomialOperations
{
    // Прямое (наивное) вычисление многочлена
    public override double Evaluate(double x, double[] coefficients)
    {
        double result = 0;
        int n = coefficients.Length;

        // Формула вычисления P(x) = sum(v_k * x^(k-1))
        for (int k = 0; k < n; k++)
        {
            result += coefficients[k] * Math.Pow(x, k);
        }

        return result;
    }
}