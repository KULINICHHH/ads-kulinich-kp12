    public class Program
    {
        static Random rnd = new Random();
        static int M, N;
        static void Main()
        {
            while (true)
            {
            Console.Write("Оберiть розмір масиву\nN = ");
            try
            {
                N = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nM = ");
                M = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Не число");
                Console.Clear();
                return;
            }
            Console.Clear();
            int[,] arr = new int[N, M];
            arr = RandomMatrix(N, M);

            Console.WriteLine("Масив чисел:");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    Console.Write(String.Format("{0,5}", arr[i, j]));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Sort(arr);
            }
        }
        public static void Sort(int[,] array)
        {
            List<int> SortList = new List<int>();
            bool direction = true;
            int c = 1;
            while (M - c > c)
            {
                if (direction)
                {
                    for (int i = c; i < M - c; i++)
                        SortList.Add(array[i, c - 1]);
                }
                else
                {
                    for (int i = M - c - 1; i > c - 1; i--)
                        SortList.Add(array[i, c - 1]);
                }
                direction = !direction;
                c++;
            }
            c = 1;
            direction = true;
            SortList = QuickSort(SortList, 0, SortList.Count - 1);
            int counter = 0;
            while (M - c > c)
            {
                if (direction)
                    for (int i = c; i < M - c; i++)
                    {
                        array[i, c - 1] = SortList[counter];
                        counter++;
                    }
                else
                    for (int i = M - c - 1; i > c - 1; i--)
                    {
                        array[i, c - 1] = SortList[counter];
                        counter++;
                    }
                direction = !direction;
                c++;
            }
            counter = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (j < counter && j < M - 1 - counter)
                    {
                        Console.Write(String.Format("{0,5}", array[i, j]));
                    }
                    else
                    {
                        Console.Write(String.Format("{0,5}", array[i, j]));
                    }
                }
                Console.WriteLine();
                counter++;
            }
            Console.WriteLine("\nЩоб повернутися до початку натисніть \"Enter\"");
            Console.ReadLine();
            Console.Clear();
        }
        public static List<int> QuickSort(List<int> array, int minIndex, int maxIndex)
        {
            if (maxIndex - minIndex < M)
            {
                for (int i = 1; i < array.Count; i++)
                {
                    int key = array[i];
                    int j = i;
                    while ((j > 1) && (array[j - 1] < key))
                    {
                        (array[j - 1], array[j]) = (array[j], array[j - 1]);
                        j--;
                    }

                    array[j] = key;
                }
                return array;
            }
            if (minIndex < maxIndex)
            {
                var pivotIndex = Partition(array, minIndex, maxIndex);
                QuickSort(array, minIndex, pivotIndex);
                QuickSort(array, pivotIndex + 1, maxIndex);
            }

            return array;
        }

        public static (int, int) Mediana(List<int> array, int minIndex, int maxIndex)
        {
            int a = array[minIndex];
            int b = array[(minIndex + maxIndex) / 2];
            int c = array[maxIndex];
            if (a > b)
            {
                if (c > a) return (a, minIndex);
                if (b > c) return (b, (minIndex + maxIndex) / 2);
                return (c, maxIndex);
            }
            if (b > a)
            {
                if (c > b) return (b, (minIndex + maxIndex) / 2);
                if (a > c) return (a, minIndex);
                return (c, maxIndex);
            }
            return (a, minIndex);
        }
        public static int Partition(List<int> array, int minIndex, int maxIndex)
        {
            (int pivot, int pivIndex) = Mediana(array, minIndex, maxIndex);
            (array[pivIndex], array[maxIndex]) = (array[maxIndex], array[pivIndex]);
            int j = maxIndex - 1;
            int i = minIndex;
            while (i < j)
            {
                if (array[i] <= pivot && array[j] >= pivot)
                    (array[i], array[j]) = (array[j], array[i]);
                if (array[i] > pivot)
                    i++;
                if (array[j] < pivot)
                    j--;
            }
            (array[i], array[maxIndex]) = (array[maxIndex], array[i]);
            return i;
        }
        public static int[,] RandomMatrix(int N, int M)
        {
            int[,] res = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    res[i, j] = rnd.Next(50);
                }
            }
            return res;
        }
    }
