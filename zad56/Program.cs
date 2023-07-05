// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки 
// с наименьшей суммой элементов: 1 строка


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

// определение строки с наименьшей суммой элементов

int MatrixSorting(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);
    int[] array = new int[rows]; // для сохранения сумм строк 

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            array[i] += matrix[i, j];
        }
        // System.Console.WriteLine(array[i]);
    }
    int maxIndex = 0;

    int sum = array[0];
    for (int j = 1; j < rows; j++)
    {
        if (array[j] < sum)
        {
            sum = array[j];
            maxIndex = j;
        }
    }
    return maxIndex + 1;
}

//..........................

int[] size = ReadInt("Задайте количество строк и столбцов  массива через запятую: ");
int[] range = ReadInt("Задайте левую и правую границы элементов массива через запятую:  ");
int[,] matrix = FillMatrix(size[0], size[1], range[0], range[1]);

System.Console.WriteLine("Исходный массив:");
PrintMatrix(matrix);

System.Console.WriteLine("");
System.Console.WriteLine($"с наименьшей суммой элементов: {MatrixSorting(matrix)} строка");
System.Console.WriteLine("");
