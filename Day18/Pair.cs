namespace AdventOfCode2021.Day18
{
    public class Pair
    {
        public Pair? Parent;
        public Pair? LeftPair = null;
        public Pair? RightPair = null;
        public int LeftRegularNumber = -1;
        public int RightRegularNumber = -1;

        public Pair(Pair? parent)
        {
            Parent = parent;
        }

        public bool Explode()
        {
            return Explode(0);
        }

        public bool Explode(int count)
        {
            count++;
            if (count == 5)
            {
                if (LeftPair != null || RightPair != null)
                {
                    throw new Exception();
                }
                Parent?.AddToLeftParent(this, LeftRegularNumber);
                Parent?.AddToRightParent(this, RightRegularNumber);
                Parent?.Explode(this);
                return true;
            }
            if (LeftPair?.Explode(count) == true)
            {
                return true;
            }
            if (RightPair?.Explode(count) == true)
            {
                return true;
            }
            return false;
        }

        public void Explode(Pair? child)
        {
            if (LeftPair == child)
            {
                LeftPair = null;
                LeftRegularNumber = 0;
            }
            else if (RightPair == child)
            {
                RightPair = null;
                RightRegularNumber = 0;
            }
        }

        private void AddToLeftParent(Pair? child, int leftRegularNumber)
        {
            if (LeftRegularNumber != -1)
            {
                LeftRegularNumber += leftRegularNumber;
            }
            else if (LeftPair != null && LeftPair != child)
            {
                LeftPair.AddToRightChild(leftRegularNumber);
            }
            else if (Parent != null)
            {
                Parent.AddToLeftParent(this, leftRegularNumber);
            }
        }

        private void AddToRightParent(Pair? child, int rightRegularNumber)
        {
            if (RightRegularNumber != -1)
            {
                RightRegularNumber += rightRegularNumber;
            }
            else if (RightPair != null && RightPair != child)
            {
                RightPair.AddToLeftChild(rightRegularNumber);
            }
            else if (Parent != null)
            {
                Parent.AddToRightParent(this, rightRegularNumber);
            }
        }

        private void AddToLeftChild(int regularNumber)
        {
            if (LeftRegularNumber != -1)
            {
                LeftRegularNumber += regularNumber;
            }
            else if (LeftPair != null)
            {
                LeftPair.AddToLeftChild(regularNumber);
            }
        }

        private void AddToRightChild(int regularNumber)
        {
            if (RightRegularNumber != -1)
            {
                RightRegularNumber += regularNumber;
            }
            else if (RightPair != null)
            {
                RightPair.AddToRightChild(regularNumber);
            }
        }

        public bool Split()
        {
            if (LeftRegularNumber > 9)
            {
                LeftPair = CreateSplitPair(LeftRegularNumber);
                LeftRegularNumber = -1;
                return true;
            }
            if (LeftPair != null)
            {
                if (LeftPair.Split())
                {
                    return true;
                }
            }
            if (RightRegularNumber > 9)
            {
                RightPair = CreateSplitPair(RightRegularNumber);
                RightRegularNumber = -1;
                return true;
            }
            if (RightPair != null)
            {
                if (RightPair.Split())
                {
                    return true;
                }
            }
            return false;
        }

        private Pair CreateSplitPair(int regularNumber)
        {
            var pair = new Pair(this);
            pair.LeftRegularNumber = regularNumber / 2;
            pair.RightRegularNumber = (regularNumber / 2) + regularNumber % 2;
            return pair;
        }

        public long Magnitude()
        {
            long leftMagnitude;
            if (LeftPair != null)
            {
                leftMagnitude = 3 * LeftPair.Magnitude();
            }
            else
            {
                leftMagnitude = 3 * LeftRegularNumber;
            }
            long rightMagnitude;
            if (RightPair != null)
            {
                rightMagnitude = 2 * RightPair.Magnitude();
            }
            else
            {
                rightMagnitude = 2 * RightRegularNumber;
            }
            return leftMagnitude + rightMagnitude;
        }

        public override string ToString()
        {
            var result = string.Empty;
            result += '[';
            if (LeftPair != null)
            {
                result += LeftPair.ToString();
            }
            else
            {
                result += LeftRegularNumber;
            }
            result += ',';
            if (RightPair != null)
            {
                result += RightPair.ToString();
            }
            else
            {
                result += RightRegularNumber;
            }
            result += ']';
            return result;
        }

        public Pair Clone(Pair? parent = null)
        {
            var pair = new Pair(parent);
            pair.LeftRegularNumber = LeftRegularNumber;
            pair.RightRegularNumber = RightRegularNumber;
            pair.LeftPair = LeftPair?.Clone(pair);
            pair.RightPair = RightPair?.Clone(pair);
            return pair;
        }
    }
}
