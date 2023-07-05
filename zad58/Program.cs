// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18


// 1. новый метод - проверка массивов на возможность умножения 
bool TestMatrix(int[,] m1, int[,] m2)
{
    if (m1.GetLength(0) == m2.GetLength(1) && m1.GetLength(1) == m2.GetLength(0))
    {
        return true;
    }
    return false;
}

// 3. новый метод - умножение массивов 

int[,] MatrixMultiplication(int[,] m1, int[,] m2)
{
    int row = m1.GetLength(0);
    int col = m2.GetLength(1);
    // создаем результирующий массив - размер - по количеству строк исходного
    int[,] resultMatrix = new int[row, row];

    // по индексам  результирующей матрицы

    for (int i = 0; i < row; i++) // в пределах строк первой матрицы
    {
        for (int j = 0; j < col; j++) // проходим по размеру второй матрицы - столбцам ]
        {

            for (int k = 0; k < row; k++) // проходим циклом по каждой строке для подсчета сумм произведений]
            {
                resultMatrix[i, j] += m1[i, k] * m2[k, j];
            }

        }


    }
    return resultMatrix;
}

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

//..........................

int[] size = ReadInt("Задайте количество строк и столбцов первого массива через запятую: ");
int[] range = ReadInt("Задайте левую и правую границы элементов массива через запятую:  ");
int[,] matrix1 = FillMatrix(size[0], size[1], range[0], range[1]);
int[,] matrix2 = FillMatrix(size[1], size[0], range[0], range[1]);
System.Console.WriteLine("Первый массив:");
PrintMatrix(matrix1);
System.Console.WriteLine("");

// запрос на самостоятельный выбор размера второго массива и его генерация

System.Console.Write("Вы хотите самостоятельно задать размер второго массива? Да/Нет ");
string res = Convert.ToString(System.Console.ReadLine()) + "";

if (res == "Да")
{
    int[] Msize = ReadInt("Задайте количество строк и столбцов второго через запятую: ");
    int[] Mrange = ReadInt("Задайте левую и правую границы элементов второго массива через запятую:  ");
    matrix2 = FillMatrix(Msize[0], Msize[1], Mrange[0], Mrange[1]);
}

System.Console.WriteLine("Второй массив:");
PrintMatrix(matrix2);
System.Console.WriteLine("");

//  просто для возможности проверки правильности длин массивов - как опция
if (TestMatrix(matrix1, matrix2) == false)
{
    System.Console.WriteLine("Эти матрицы не могут быть перемножены");
    System.Console.WriteLine("");
    return;
}

System.Console.WriteLine("Результат: ");
PrintMatrix(MatrixMultiplication(matrix1, matrix2));
System.Console.WriteLine("");
