using Engine.Methods;

namespace Engine
{
    class Startup
    {
        static void Main(string[] args)
        {

            //ArrayStack<int> myStack = new ArrayStack<int>();
            //myStack.Push(10);
            //myStack.Push(20);
            //myStack.Push(20);
            //myStack.Push(20);
            //myStack.Pop();
            ArrayStack<int> stack = new ArrayStack<int>();

            //Assert.AreEqual(0
                System.Console.WriteLine(stack.Count);

            stack.Push(1);
            System.Console.WriteLine(stack.Count);
            //Assert.AreEqual(1, stack.Count);
            System.Console.WriteLine(stack.Pop());
            //Assert.AreEqual(1, stack.Pop());
            System.Console.WriteLine(stack.Count);
            //Assert.AreEqual(0, stack.Count);

            //System.Console.WriteLine(string.Join(" ", myStack.ToArray()));
        }
    }
}
