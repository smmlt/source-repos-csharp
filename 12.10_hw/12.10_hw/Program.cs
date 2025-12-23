namespace _12._10_hw
{
    public class MyStack<T>
    {
        private T[] Stack;
        private int _currentIndex = -1;

        public MyStack(int capacity = 10)
        {
            Stack = new T[capacity];
        }

        public void Push(T item)
        {
            if (_currentIndex == Stack.Length - 1)
            {
                Array.Resize(ref Stack, Stack.Length * 2);
            }
            Stack[++_currentIndex] = item;
        }

        public void Pop()
        {
            if (_currentIndex < 0) throw new InvalidOperationException("Stack is empty.");
            _currentIndex--;
        }

        public T Peek()
        {
            if (_currentIndex < 0) throw new InvalidOperationException("Stack is empty.");
            return Stack[_currentIndex];
        }

        public int Count() => _currentIndex + 1; 
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);

            Console.WriteLine($"Top element: {stack.Peek()}");
            Console.WriteLine($"Number of elements in the stack: {stack.Count()}");

            stack.Pop();

            stack.Peek();

            Console.WriteLine($"Top element: {stack.Peek()}");
            Console.WriteLine($"Number of elements in the stack: {stack.Count()}");
        }
    }
}
