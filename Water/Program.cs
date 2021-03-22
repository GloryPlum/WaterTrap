using System;

namespace Water
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = new int[] {0, 7, 1, 4, 6};
            Console.WriteLine(Trap(height));
        }
        static int Trap(int[] height)
        {
            int water = 0;
            int index = -1;
            for (int i = 0; i < height.Length - 2; i++)//Начальная точка
            {
                Start1:
                for (int j = i + 1; j < height.Length; j++)//Вторая точка
                {
                    if ((height[i] <= height[j]))
                    {
                        i = j;
                    }
                    else
                    {
                        for (int k = j + 1; k < height.Length; k++)
                        {
                        Start:
                            if (height[j] >= height[k])
                            {
                                j = k;
                            }
                            else
                            {
                                int max = height[k];
                                for (int l = k + 1; l < height.Length; l++)
                                {
                                    if (height[l] > max&&(max<=height[i]))
                                    {
                                        max = height[l];
                                        index = l;
                                    }

                                }
                                if (max == height[k])
                                {
                                    if (height[i] > height[k])
                                    {
                                        water = water + height[k] * (k - i - 1);
                                        for (int m = i + 1; m < k; m++)
                                        {
                                            if (height[m] > height[k])
                                                water = water - height[k];
                                            else
                                                water = water - height[m];
                                        }
                                        i = k;
                                    }
                                    else
                                    {
                                        water = water + height[i] * (k - i - 1);
                                        for (int m = i + 1; m < k; m++)
                                        {
                                            if (height[m] > height[k])
                                                water = water - height[i];
                                            else
                                                water = water - height[m];
                                        }

                                        i = k;
                                        goto Start1;
                                    }
                                }
                                else
                                {
                                    if (height[k]>=height[i])
                                    {
                                            water = water + height[i] * (k - i - 1);
                                            for (int m = i + 1; m < k; m++)
                                            {
                                                if (height[m] > height[k])
                                                    water = water - height[i];
                                                else
                                                    water = water - height[m];
                                        }
                                            i = k;
                                    }
                                    else
                                    {
                                        k = index;
                                        j = k - 1;
                                        goto Start;
                                    }
                                }
                            }
                        } 
                    }
                }

            }
           return water;
        }
    }
}
