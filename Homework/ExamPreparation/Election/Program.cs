namespace Election
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            BigInteger[] resultList = new BigInteger[100001];
            resultList[0] = 1;
            var maxSum = 0;
            
            for (var i = 0; i < n; i++)
            {
                int l = int.Parse(Console.ReadLine());

                maxSum += l;

                for (var p = maxSum-1; p >= 0; p--)
                {
                    if (resultList[p] != 0)
                    {
                        resultList[p + l] += resultList[p];
                    }
                }
            }

            BigInteger sum = 0;
            for (var u = k; u < resultList.Length; u++)
            {
                sum += resultList[u];
            }

            Console.WriteLine(sum);
        }

    }
}
