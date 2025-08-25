class Program
{
  static int[] TwoSum(int[] arr, int target)
  {
    Dictionary<int, int> map = new Dictionary<int, int>();

    for (int i = 0; i < arr.Length; i++)
    {
      int needed = target - arr[i];
      if (map.ContainsKey(needed))
      {
        return new int[] { map[needed], i };
      }
      if (!map.ContainsKey(needed))
      {
        map[arr[i]] = i;
      }
    }
    return new int[] { -1, -1 };
  }
  static void Main()
  {
    int[] arr = { 2, 7, 11, 15 };
    int target = 9;
    int[] result = TwoSum(arr, target);
    Console.WriteLine(string.Join(",", result));
  }
}
