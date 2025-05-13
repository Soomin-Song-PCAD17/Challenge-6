/// You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise).
/// You have to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.
/// Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
/// Output: [[7,4,1],[8,5,2],[9,6,3]]
/// Input: matrix = [[5,1,9,11],[2,4,8,10],[13,3,6,7],[15,14,12,16]]
/// Output: [[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]]

//int[,] matrix6 = new int[6, 6];
//for (int i = 0; i < 6; i++)
//{
//    for (int j = 0; j < 6; j++)
//    {
//        matrix6[i, j] = 10 * i + j;
//    }
//}
//Demo(matrix6);
//Console.WriteLine();

int[,] matrix5 = new int[5, 5];
for (int i = 0; i < 5; i++)
{
    for (int j = 0; j < 5; j++)
    {
        matrix5[i, j] = 10 * i + j;
    }
}
Demo(matrix5);
Console.WriteLine();

int[,] matrix7 = new int[7, 7];
for (int i = 0; i < 7; i++)
{
    for (int j = 0; j < 7; j++)
    {
        matrix7[i, j] = 10 * i + j;
    }
}
Demo(matrix7);


//int[,] matrix3 = {
//   { 1, 2, 3 },
//   { 4, 5, 6 },
//   { 7, 8, 9 }
//};

//Demo(matrix3);

void Demo(int[,] matrix)
{
    DisplayMatrix(matrix);
    Console.WriteLine();
    DisplayMatrix(RotateMatrix(matrix));
}

int[,] RotateMatrix(int[,] matrix)
{
    // dimension mismatch, return immediately
    if (matrix.GetLength(0) != matrix.GetLength(1)) { return matrix; }
    // otherwise, store dimension length for easy reference
    int length = matrix.GetLength(0);

    // split matrix into four quadrants
    // rotate each element in the array
    // i: dimension 0, aka horizontal coordinate
    // j: dimension 1, aka vertical coordinate
    // quadrant 1: top left
    // quadrant 2: top right
    // quadrant 3: bottom right
    // quadrant 4: bottom left

    for(int i=0; i<=length/2; i++)
    {
        for(int j=0; j<length/2; j++)
        {
            int temp = matrix[i, j];
            matrix[i,j] = matrix[length - 1 - j, i]; // bottom left to top left
            matrix[length - 1 - j, i] = matrix[length - 1 - i, length - 1 - j]; // bottom right to bottom left
            matrix[length - 1 - i, length - 1 - j] = matrix[j,length - 1 - i]; // top right to bottom left
            matrix[j, length - 1 - i] = temp; // top left to top right
        }
    }
    return matrix;
}

void DisplayMatrix(int[,] matrix)
{
    Console.Write("[");
    for(int i = 0; i < matrix.GetLength(0); i++)
    {
        Console.Write("[");
        for(int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}");
            if(j < matrix.GetLength(1)-1) { Console.Write(",\t"); }
        }
        Console.Write("]");
        if(i < matrix.GetLength(0)-1) { Console.Write("\n"); }
    }
    Console.WriteLine("]");
}