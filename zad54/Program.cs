// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

//Генерация исходного массива
int[,] FillMatrix(int row, int col, int leftRange, int rightRange)
{
    int[,] tempMatrix = new int[row, col];
    var rand = new Random();
    for (int i = 0; i < tempMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < tempMatrix.GetLength(1); j++)
        {
            tempMatrix[i, j] = rand.Next(leftRange, rightRange + 1);
        }
    }
    return tempMatrix;
}
//Ввод данных - через массив из двух элементов
int[] ReadInt(string text)
{
    System.Console.Write(text);
    return Array.ConvertAll(Console.ReadLine()!.Split(","), int.Parse); ;
}

// Печать двумерного массива
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + "\t");
        }
        System.Console.WriteLine();
    }
}

// сортировка массива по строкам

int[,] MatrixSorting(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int[,] ResultSorting = new int[rows, cols];
    int[] array = new int[cols];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            array[j] = matrix[i, j];
        }

        SortArrayDescending(array);

        for (int j = 0; j < cols; j++)
        {
            ResultSorting[i, j] = array[j];
        }
    }
    return ResultSorting;
}

// сортировка по убыванию

int[] SortArrayDescending(int[] array)
{
    int temp;
    for (int i = 0; i < array.Length - 1; i++)
    {
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[i] < array[j])
            {
                temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }

return array;
}

//..........................

int[] size = ReadInt("Задайте количество строк и столбцов  массива через запятую: ");
int[] range = ReadInt("Задайте левую и правую границы элементов массива через запятую:  ");
int[,] matrix = FillMatrix(size[0], size[1], range[0], range[1]);

System.Console.WriteLine("Исходный массив:");
PrintMatrix(matrix);
System.Console.WriteLine("");

System.Console.WriteLine("Результат сортировки: ");
PrintMatrix(MatrixSorting(matrix));
System.Console.WriteLine("");
