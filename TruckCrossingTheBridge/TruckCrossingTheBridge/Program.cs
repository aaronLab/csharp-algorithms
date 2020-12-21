using System;
using System.Collections.Generic;

namespace TruckCrossingTheBridge
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int l1 = 2;
            int w1 = 10;
            int[] tw1 = { 7, 4, 5, 6 };
            int solution1 = Solution.solution(l1, w1, tw1);
            Console.WriteLine(solution1); // ==> 8

            int l2 = 100;
            int w2 = 100;
            int[] tw2 = { 10 };
            int solution2 = Solution.solution(l2, w2, tw2);
            Console.WriteLine(solution2); // ==> 101

            int l3 = 100;
            int w3 = 100;
            int[] tw3 = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            int solution3 = Solution.solution(l3, w3, tw3);
            Console.WriteLine(solution3); // ==> 110
        }
    }
}

public class Solution
{
    public static int solution(int bridge_length, int weight, int[] truck_weights)
    {
        Queue<int> bridge = new Queue<int>(new int[bridge_length]);
        Queue<int> trucks = new Queue<int>(truck_weights);
        int time = 0;
        int arrivalCount = 0;
        int truckNum = truck_weights.Length;
        int totalWeight = 0;
        while (arrivalCount != truckNum)
        {
            time++;
            var arrival = bridge.Dequeue();
            if (arrival > 0)
            {
                totalWeight -= arrival;
                arrivalCount++;
            }
            if (trucks.Count == 0)
                bridge.Enqueue(0);
            else if (totalWeight + trucks.Peek() > weight)
                bridge.Enqueue(0);
            else
            {
                int newTruck = trucks.Dequeue();
                bridge.Enqueue(newTruck);
                totalWeight += newTruck;
            }
        }
        return time;
    }
}
