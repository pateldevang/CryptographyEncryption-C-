using System.Collections.Generic;
using System.Text;

public class HillCipher
{
    public HillCipher(int[,] encodingMatrix, int[,] decodingMatrix, bool mapNumbers = true)
    {
        this.EncodingMatrix = encodingMatrix;
        this.DecodingMatrix = decodingMatrix;
        this.MapNumbers = mapNumbers;
    }

    private int[,] EncodingMatrix { get; set; }
    private int[,] DecodingMatrix { get; set; }
    private bool MapNumbers { get; set; }

    public string EncryptText(string plainText)
    {
        var plainMatrix = this.GetMatrixFromText(plainText);
        var cipherMatrix = MultiplyMatrices(this.EncodingMatrix, plainMatrix);
        var cipherText = GetNumbersFromMatrix(cipherMatrix);
        if (this.MapNumbers)
          cipherText = NumberToChar(cipherText);

        return cipherText;
    }

    public string DecryptText(string cipherText)
    {
        if (this.MapNumbers)
           cipherText = CharToNumber(cipherText);

        var cipherMatrix = this.GetMatrixFromNumbers(cipherText);
        var plainMatrix = MultiplyMatrices(this.DecodingMatrix, cipherMatrix);
        return GetTextFromMatrix(plainMatrix);
    }

    private static string GetTextFromMatrix(int[,] matrix)
    {
        var text = new StringBuilder();
        for (var j = 0; j < matrix.GetLength(1); j++)
            for (var i = 0; i < matrix.GetLength(0); i++)
                text.Append(matrix[i, j] > 0 ? ((char)matrix[i, j]).ToString() : string.Empty);

        return text.ToString();
    }

    private static string GetNumbersFromMatrix(int[,] matrix)
    {
        var text = new StringBuilder();
        for (var j = 0; j < matrix.GetLength(1); j++)
            for (var i = 0; i < matrix.GetLength(0); i++)
                text.Append(matrix[i, j].ToString("0") + " ");

        return text.ToString();
    }

    private static int[,] MultiplyMatrices(int[,] m1, int[,] m2)
    {
        var rows = m1.GetLength(0);
        var columns = m2.GetLength(1);
        var matrix = new int[rows, columns];

        for (var i = 0; i < rows; i++)
            for (var j = 0; j < columns; j++)
                for (var k = 0; k < m1.GetLength(1); k++)
                    matrix[i, j] += m1[i, k] * m2[k, j];

        return matrix;
    }

    private static string NumberToChar(string text)
    {
        var result = new StringBuilder();
        foreach (var t in text)
           result.Append((char)(t + ((int)t == 32 ? 33 : 21)));

        return result.ToString();
    }

    private static string CharToNumber(string text)
    {
        var result = new StringBuilder();
        foreach (var t in text)
            result.Append((char)(t - ((int)t == 65 ? 33 : 21)));
        return result.ToString();
    }

    private int[,] GetMatrixFromArray(IList arr)
    {
        var rows = this.EncodingMatrix.GetLength(0);
        var columns = arr.Count % rows == 0 ? arr.Count / rows : (arr.Count / rows) + 1;
        var matrix = new int[rows, columns];

        for (var i = 0; i < arr.Count; i++)
            matrix[i % rows, i / rows] = arr[i];

        if (arr.Count % rows != 0)
            for (var i = arr.Count % rows; i < rows; i++)
                matrix[i, (arr.Count - 1) / rows] = 0;

        return matrix;
    }

    private int[,] GetMatrixFromText(string text)
    {
        var arr = new int[text.Length];
        for (var i = 0; i < text.Length; i++)
            arr[i] = text[i];

        return this.GetMatrixFromArray(arr);
    }

    private int[,] GetMatrixFromNumbers(string text)
    {
        var numbers = text.Split(' ');
        var arr = new List();
        foreach (var t in numbers)
          if (!string.IsNullOrWhiteSpace(t))
              arr.Add(int.Parse(t));
        return this.GetMatrixFromArray(arr);
    }
}
