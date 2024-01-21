using System;
using System.Collections.Generic;

namespace Task_F
{
    class Task_F
    {
        static bool IsOwnerBasketsContainsAppleType(List<Dictionary<int, int>> baskets, int appleType)
        {
            foreach (var basket in baskets)
            {
                if (basket.ContainsKey(appleType))
                {
                    return true;
                }
            }
            return false;
        }

        static List<Dictionary<int, int>> BuildOwnerBaskets(List<int> basketIndices, List<Dictionary<int, int>> baskets)
        {
            var ret = new List<Dictionary<int, int>>();
            foreach (var basketIndex in basketIndices)
            {
                ret.Add(baskets[basketIndex]);
            }
            return ret;
        }

        static bool TryPlaceBasket(Dictionary<byte, List<int>> basketsByOwner, List<Dictionary<int, int>> baskets, List<Dictionary<int, int>> staticBaskets)
        {            
            if (basketsByOwner[1].Count == 0 && basketsByOwner[2].Count == 0)
            {
                basketsByOwner[1].Add(0);
                return true;
            }
            else
            {
                var basketsOwner1 = BuildOwnerBaskets(basketsByOwner[1], staticBaskets);
                var basketsOwner2 = BuildOwnerBaskets(basketsByOwner[2], staticBaskets);
                var basketForPlace = baskets[0];
                foreach (int appleType in basketForPlace.Keys)
                {
                    if (IsOwnerBasketsContainsAppleType(basketsOwner1, appleType) && IsOwnerBasketsContainsAppleType(basketsOwner2, appleType))
                    {
                        // If each owner has this apple type
                        return false;
                    }
                    else if (!IsOwnerBasketsContainsAppleType(basketsOwner1, appleType) && !IsOwnerBasketsContainsAppleType(basketsOwner2, appleType) && basketsOwner1.Count == 0)
                    {
                        // Place in owner 1 if no one has this apple type
                        basketsByOwner[1].Add(basketsOwner1.Count + basketsOwner2.Count);
                        return true;
                    }
                    else if (!IsOwnerBasketsContainsAppleType(basketsOwner1, appleType) && !IsOwnerBasketsContainsAppleType(basketsOwner2, appleType) && basketsOwner2.Count == 0)
                    {
                        // Place in owner 2 if no one has this apple type
                        basketsByOwner[2].Add(basketsOwner1.Count + basketsOwner2.Count);
                        return true;
                    }
                    else if (IsOwnerBasketsContainsAppleType(basketsOwner1, appleType))
                    {
                        // Only owner 1 has this apple type
                        basketsByOwner[1].Add(basketsOwner1.Count + basketsOwner2.Count);
                        return true;
                    }
                    else
                    {
                        // Only owner 2 has this apple type
                        basketsByOwner[2].Add(basketsOwner1.Count + basketsOwner2.Count);
                        return true;
                    }
                }
            }
            return false;
        }

        static bool TrySortBaskets(List<Dictionary<int, int>> baskets, List<int> appleTypes, out List<string> sortResult)
        {
            sortResult = new List<string>();
            var basketsByOwner = new Dictionary<byte, List<int>>();
            basketsByOwner.Add(1, new List<int>());
            basketsByOwner.Add(2, new List<int>());
            var staticBaskets = new List<Dictionary<int, int>>(baskets);
            while (baskets.Count > 0)
            {
                if (TryPlaceBasket(basketsByOwner, baskets, staticBaskets))
                {
                    baskets.RemoveAt(0);
                }
                else
                {
                    return false;
                }
            }
            for (int i = 0; i < staticBaskets.Count; i++)
            {
                if (basketsByOwner[1].Contains(i))
                {
                    sortResult.Add("1");
                }
                else
                {
                    sortResult.Add("2");
                }
            }
            return true;
        }

        static int IndexOfBasketThatContainsOnlyUniqueAppleTypes(List<Dictionary<int, int>> baskets, List<int> appleTypes)
        {
            for (int i = 0; i < baskets.Count; i++)
            {
                bool containsOnlyUniqueAppleTypes = true;
                for (int j = 0; j < baskets.Count; j++)
                {
                    if (j != i)
                    {
                        bool needBreak = false;
                        foreach (int appleType in baskets[j].Keys)
                        {
                            if (baskets[i].ContainsKey(appleType))
                            {
                                containsOnlyUniqueAppleTypes = false;
                                needBreak = true;
                                break;
                            }
                        }
                        if (needBreak)
                        {
                            break;
                        }
                    }
                }
                if (containsOnlyUniqueAppleTypes)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Main(string[] args)
        {
            var values = Console.ReadLine().Split(' ');
            int n = int.Parse(values[0]);
            int m = int.Parse(values[1]);
            var baskets = new List<Dictionary<int, int>>();
            var appleTypes = new List<int>();
            for (int i = 0; i < n; i++)
            {
                Console.ReadLine();
                var apples = new Dictionary<int, int>();
                foreach (string appleTypeStr in Console.ReadLine().Split(' '))
                {
                    int appleTypeInt = int.Parse(appleTypeStr);
                    if (!appleTypes.Contains(appleTypeInt))
                    {
                        appleTypes.Add(appleTypeInt);
                    }
                    if (apples.ContainsKey(appleTypeInt))
                    {
                        apples[appleTypeInt]++;
                    }
                    else
                    {
                        apples.Add(appleTypeInt, 1);
                    }
                }
                baskets.Add(apples);
            }
            bool isPresentAppleTypeThatContainsInAllBaskets = false;
            foreach (int appleType in appleTypes)
            {
                int countOfBasketsThatContainsAppleType = 0;
                foreach (var basket in baskets)
                {
                    if (basket.ContainsKey(appleType))
                    {
                        countOfBasketsThatContainsAppleType++;
                    }
                }
                if (countOfBasketsThatContainsAppleType == baskets.Count)
                {
                    isPresentAppleTypeThatContainsInAllBaskets = true;
                    break;
                }
            }
            if (isPresentAppleTypeThatContainsInAllBaskets)
            {
                Console.Write("NO");
            }
            else
            {
                appleTypes.Sort();
                int indexOfUniqueBasket = IndexOfBasketThatContainsOnlyUniqueAppleTypes(baskets, appleTypes);
                if (indexOfUniqueBasket == -1)
                {
                    if (TrySortBaskets(baskets, appleTypes, out var sortResult))
                    {
                        if (sortResult == null || sortResult.Count == 0)
                        {
                            Console.Write("NO");
                        }
                        {
                            Console.WriteLine("YES");
                            foreach (var item in sortResult)
                            {
                                Console.Write("{0} ", item);
                            }
                        }
                    }
                    else
                    {
                        Console.Write("NO");
                    }
                }
                else
                {
                    for (int i = 0; i < baskets.Count; i++)
                    {
                        if (i == indexOfUniqueBasket)
                        {
                            Console.Write("1 ");
                        }
                        else
                        {
                            Console.Write("2 ");
                        }
                    }
                }
            }
        }
    }
}