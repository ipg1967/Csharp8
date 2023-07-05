// Задача 60. ...Сформируйте трёхмерный массив из двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

//Генерация исходного трехмерного массива
int[,,] FillMatrix(int x, int y, int z, int leftRange, int rightRange)
{
    int[,,] tempMatrix = new int[x, y, z];
    var rand = new Random();
    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                tempMatrix[i, j, k] = rand.Next(leftRange, rightRange + 1);
            }
        }
    }
    return tempMatrix;
}
//Ввод данных - через массив из трех элементов
int[] ReadInt(string text)
{
    System.Console.Write(text);
    return Array.ConvertAll(Console.ReadLine()!.Split(","), int.Parse);
}

// Печать трехмерного массива
void Print3DMatrix(int[,,] matrix)
{
    for (int i = 0; i < matrix.GetLength(2); i++)
    {
        System.Console.WriteLine();
        System.Console.WriteLine($"Слой {i + 1} :");
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            for (int k = 0; k < matrix.GetLength(1); k++)
            {
                System.Console.Write($"{matrix[j, k, i]} ({j},{k},{i})" + "\t");
            }
            System.Console.WriteLine();
        }
        
    }
}


//..........................

int[] size = ReadInt("Задайте число строк, столбцов и глубину 3D массива через запятую: ");
// int[] range = ReadInt("Задайте левую и правую границы величины элементов массива через запятую:  ");
// По условию числа - двузначные:
int[] range = {10, 99};
int[,,] matrix = FillMatrix(size[0], size[1], size[2], range[0], range[1]);
System.Console.WriteLine();
System.Console.WriteLine("Печать массива по слоям (в глубину): ");
Print3DMatrix(matrix);

