namespace Algorithm.Test_Algorithms.Auto_Testing;

public class AutoTesterString
{
    private List<int> stringLengths = new List<int>();
    private List<int> steps = new List<int>();

    // Метод для автоматического тестирования поиска подстроки в строке
    public List<(int StringLength, int Steps)> TestSubstringSearch(Func<int, string> stringGenerationOperation, Func<string, string, (List<int>, int)> substringSearchOperation, int maxStringLength, int substringLength, int stepSize)
    {
        var results = new List<(int StringLength, int Steps)>();

        for (int length = substringLength; length <= maxStringLength; length += stepSize)
        {
            string generatedString = stringGenerationOperation(length);

            // Генерация подстроки (берём первые символы)
            string substring = generatedString.Substring(0, substringLength);

            // Выполняем поиск подстроки и считаем шаги
            var (_, stepCount) = substringSearchOperation(generatedString, substring);

            results.Add((length, stepCount));
            
            stringLengths.Add(length);
            steps.Add(stepCount);
        }

        return results;
    }
}