public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // 1. Create a new array of doubles with the given length
        // 2. Loop through each index from 0 to length - 1
        // 3. At each index i, store number * (i + 1)
        //    (i + 1 because the first multiple is number * 1, not number * 0)
        // 4. Return the completed array
    
        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Find the split point: the index where the rotation starts
        //    This is (data.Count - amount), since we're moving the last 
        //    'amount' items to the front
        // 2. Use GetRange to grab the tail (from splitPoint to the end)
        // 3. Use GetRange to grab the head (from 0 to splitPoint)
        // 4. Clear the original list
        // 5. Add the tail first, then add the head — this gives us the rotated order
    
        int splitPoint = data.Count - amount;
        var tail = data.GetRange(splitPoint, amount);
        var head = data.GetRange(0, splitPoint);
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
