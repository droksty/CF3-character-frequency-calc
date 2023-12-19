namespace CharacterFrequencyCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:/tmp/a-test-file.txt";        // Your test file

            try
            {
                using StreamReader reader = new(filePath);
                DoublyLinkedList<char> linkedList = new();
                GenericNode<char>? node;
                int totalCharCount = 0;
                char ch;

                while (reader.Peek() >= 0)
                {
                    ch = (char)reader.Read();
                    if (!char.IsLetterOrDigit(ch)) continue;

                    node = linkedList.GetNodePosition(ch);
                    if (node != null) linkedList.IncreaseCount(node);
                    else linkedList.InsertFirst(ch);

                    totalCharCount++;
                }

                linkedList.PrintResults(totalCharCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}