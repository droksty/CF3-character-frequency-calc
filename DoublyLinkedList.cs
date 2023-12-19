namespace CharacterFrequencyCalculator
{
    internal class DoublyLinkedList<T>
    {
        public GenericNode<T>? First { get; set; }
        public GenericNode<T>? Last { get; set; }

        
        public DoublyLinkedList()
        {
            First = null;
            Last = null;
        }


        // API

        public void InsertFirst(T t)
        {
            var oldFirst = First;
            var first = new GenericNode<T>() { Value = t };
            first.Next = oldFirst;
            first.Count++;
            if (oldFirst is null) Last = first;
            else oldFirst.Prev = first;
            First = first;
        }


        public void PrintResults(int count)
        {
            if (First is not null)
            {
                Console.WriteLine($"Total chars: {count}");
                for (GenericNode<T>? node = First; node != null; node = node.Next)
                {
                    Console.WriteLine($"Character: {node.Value}, count: {node.Count}, frequency: {((double)node.Count / count):P}");
                }
            }
            else
            {
                Console.WriteLine("The list is empty..");
            }
        }


        public GenericNode<T>? GetNodePosition(T t)
        {
            GenericNode<T>? node = First;
            while (node != null)
            {
                if (node.Value!.Equals(t)) return node;
                node = node.Next;
            }
            return null;
        }


        public void IncreaseCount(GenericNode<T> node)
        {
            node.Count++;
        }


        public void IncreaseCount(T t)
        {
            GetNodePosition(t)!.Count++;
        }



    }
}
