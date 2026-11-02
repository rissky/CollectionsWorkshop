using System;
using System.Collections.Generic;

namespace CollectionsWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PART 1: THE FIXED ARRAY (T[]) ===");
            Console.WriteLine("Arrays have a fixed size in memory. Once created, they cannot grow or shrink.\n");

            // 1. Initialization
            string[] inventoryArray = new string[3];
            Console.WriteLine($"Created an array with {inventoryArray.Length} slots.");

            // 2. Adding items (Requires manual index tracking)
            inventoryArray[0] = "Health Potion";
            inventoryArray[1] = "Iron Sword";
            inventoryArray[2] = "Gold Coin";

            Console.WriteLine("\nArray Contents after adding:");
            PrintArray(inventoryArray);

            // 3. Removing an item (Leaves a 'hole' in memory)
            Console.WriteLine("\nRemoving 'Iron Sword' (Index 1)...");
            inventoryArray[1] = null; // We can't delete the slot, only empty it.

            Console.WriteLine("\nArray Contents after removal:");
            PrintArray(inventoryArray);

            // 4. The limitation
            Console.WriteLine("\nAttempting to add a 4th item ('Magic Shield')...");
            Console.WriteLine("ERROR: Cannot use inventoryArray[3] - would cause IndexOutOfRangeException!");


            Console.WriteLine("\n\n=== PART 2: THE DYNAMIC LIST (List<T>) ===");
            Console.WriteLine("Lists manage an underlying array for you, automatically resizing and shifting data.\n");

            // 1. Initialization
            List<string> inventoryList = new List<string>();
            Console.WriteLine($"Created a list. Initial Count: {inventoryList.Count}");

            // 2. Adding items (Automatically appends to the end)
            inventoryList.Add("Health Potion");
            inventoryList.Add("Iron Sword");
            inventoryList.Add("Gold Coin");

            Console.WriteLine($"\nList Contents after adding (Count is now {inventoryList.Count}):");
            PrintList(inventoryList);

            // 3. Removing an item (Automatically compacts the list)
            Console.WriteLine("\nRemoving 'Iron Sword'...");
            inventoryList.Remove("Iron Sword");
            // Notice we didn't need to know the index, and the list shrank!

            Console.WriteLine($"\nList Contents after removal (Count shrank to {inventoryList.Count}):");
            PrintList(inventoryList);

            // 4. The flexibility
            Console.WriteLine("\nAdding a 4th item ('Magic Shield')...");
            inventoryList.Add("Magic Shield");

            Console.WriteLine($"\nList Contents after expanding (Count is now {inventoryList.Count}):");
            PrintList(inventoryList);


            Console.WriteLine("\n\n=== PART 3: THE HYBRID (Our Unity Inventory Approach) ===");
            Console.WriteLine("In our Unity game, we want the flexibility of List<T> methods (like IndexOf),");
            Console.WriteLine("but we want fixed slots (like an Array) so items don't shift when we drag/drop.\n");

            List<string> unityInventory = new List<string>();
            int maxCapacity = 5;

            // Pre-fill with nulls to create stable slots
            for (int i = 0; i < maxCapacity; i++)
            {
                unityInventory.Add(null);
            }

            // Find first empty slot safely
            int firstEmpty = unityInventory.IndexOf(null);
            if (firstEmpty != -1)
            {
                unityInventory[firstEmpty] = "Starter Bow";
                Console.WriteLine($"Added 'Starter Bow' to the first empty slot (Index {firstEmpty}).");
            }

            Console.ReadLine(); // Pause console
        }

        // Helper method to print arrays
        static void PrintArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                string display = arr[i] == null ? "[EMPTY]" : arr[i];
                Console.WriteLine($"  Slot {i}: {display}");
            }
        }

        // Helper method to print lists
        static void PrintList(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"  Index {i}: {list[i]}");
            }
        }
    }
}