using CodeChallenge.Core;

namespace Lab4
{
    public class PolishNotationController : FileTask
    {
        private readonly Stack<int> _stack = new Stack<int>(100);

        public void Add()
        {
            _stack.Push(_stack.Pop() + _stack.Pop());
        }
        public void Subtract()
        {
            _stack.Push(-_stack.Pop() + _stack.Pop());
        }
        public void Multiply()
        {
            _stack.Push(_stack.Pop() * _stack.Pop());
        }

        public void PushNum(int value)
        {
            _stack.Push(value);
        }
        public int GetAnswer()
        {
            return _stack.Pop();
        }

        public override void Execute()
        {
            var query = ReadLine().TrimEnd().Split();

            var pc = new PolishNotationController();

            foreach (var op in query)
            {
                if (int.TryParse(op, out int num))
                {
                    pc.PushNum(num);
                    continue;
                }

                switch (op[0])
                {
                    case '+':
                        pc.Add();
                        break;
                    case '-':
                        pc.Subtract();
                        break;
                    case '*':
                        pc.Multiply();
                        break;
                }
            }

            WriteLine(pc.GetAnswer());
        }
    }
}
