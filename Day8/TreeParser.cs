using System;
namespace Day8
{
    public class TreeParser
    {
        List<Tree> _trees = new List<Tree>();
        private int _maxX = 0;
        private int _maxY = 0;

        public TreeParser()
        {
        }

        public void Parse(List<string> lines)
        {
            int row = 0;
            foreach (var line in lines)
            {
                ParseLine(line, row);
                row++;
            }

            _maxX = _trees.Select(a => a.LocationX).Max();
            _maxY = _trees.Select(a => a.LocationY).Max();
        }

        private void ParseLine(string line, int row)
        {
            var chars = line.ToCharArray();
            int column = 0;
            foreach (var ch in chars)
            {
                int height = int.Parse(ch.ToString());
                Tree tree = new Tree();
                tree.Height = height;
                tree.LocationY = row;
                tree.LocationX = column;
                _trees.Add(tree);
                column++;
            }
        }

        private Tree? GetTreeAtLocation(int x, int y)
        {
            var tree = _trees.Where(a => a.LocationX == x && a.LocationY == y).FirstOrDefault();
            return tree;
        }

        public void OutputTree()
        {
            for (int y = 0; y <= _maxY; y++)
            {
                for (int x = 0; x <= _maxX; x++)
                {
                    var tree = GetTreeAtLocation(x, y);
                    if (tree != null)
                        Console.Write($"{tree.Height}");
                }
                Console.WriteLine();
            }
        }

        public void SetVisibility()
        {
            SetEdgeVisibility();
            for (int row = 1; row < _maxY; row++)
            {
                SetVisibilityFromWest(row);
                SetVisibilityFromEast(row);
            }

            for (int column = 1; column < _maxX; column++)
            {
                SetVisibilityFromNorth(column);
                SetVisibilityFromSouth(column);
            }
        }

        private void SetEdgeVisibility()
        {
            // North & South
            for (int i = 0; i <= _maxX; i++)
            {
                var tree = GetTreeAtLocation(i, 0);
                if (tree != null)
                    tree.IsVisible = true;

                tree = GetTreeAtLocation(i, _maxY);
                if (tree != null)
                    tree.IsVisible = true;
            }

            // West & East
            for (int i = 0; i <= _maxY; i++)
            {
                var tree = GetTreeAtLocation(0, i);
                if (tree != null)
                    tree.IsVisible = true;

                tree = GetTreeAtLocation(_maxX, i);
                if (tree != null)
                    tree.IsVisible = true;
            }
        }

        public void SetVisibilityFromWest(int row)
        {
            int maxHeightSoFar = 0;

            var tree = GetTreeAtLocation(0, row);
            if (tree != null)
                maxHeightSoFar = tree.Height;

            for (int index = 1; index <= _maxX; index++)
            {
                tree = GetTreeAtLocation(index, row);
                if (tree != null)
                {
                    if (tree.Height > maxHeightSoFar)
                    {
                        maxHeightSoFar = tree.Height;
                        tree.IsVisible = true;
                    }
                }
            }
        }

        public void SetVisibilityFromEast(int row)
        {
            int maxHeightSoFar = 0;

            var tree = GetTreeAtLocation(_maxX, row);
            if (tree != null)
                maxHeightSoFar = tree.Height;

            for (int index = _maxX; index > 1; index--)
            {
                tree = GetTreeAtLocation(index, row);
                if (tree != null)
                {
                    if (tree.Height > maxHeightSoFar)
                    {
                        maxHeightSoFar = tree.Height;
                        tree.IsVisible = true;
                    }
                }
            }
        }

        public void SetVisibilityFromNorth(int column)
        {
            int maxHeightSoFar = 0;

            var tree = GetTreeAtLocation(column, 0);
            if (tree != null)
                maxHeightSoFar = tree.Height;

            for (int index = 1; index <= _maxY; index++)
            {
                tree = GetTreeAtLocation(column, index);
                if (tree != null)
                {
                    if (tree.Height > maxHeightSoFar)
                    {
                        maxHeightSoFar = tree.Height;
                        tree.IsVisible = true;
                    }
                }
            }
        }

        public void SetVisibilityFromSouth(int column)
        {
            int maxHeightSoFar = 0;

            var tree = GetTreeAtLocation(column, _maxY);
            if (tree != null)
                maxHeightSoFar = tree.Height;

            for (int index = _maxY; index > 0; index--)
            {
                tree = GetTreeAtLocation(column, index);
                if (tree != null)
                {
                    if (tree.Height > maxHeightSoFar)
                    {
                        maxHeightSoFar = tree.Height;
                        tree.IsVisible = true;
                    }
                }
            }
        }

        public int GetVisibleCount()
        {
            return _trees.Where(a => a.IsVisible == true).Count();
        }

        public void CalculateScenicScore()
        {
            foreach (Tree tree in _trees)
            {
                // Look east
                int distance = 0;
                for (int indexX = tree.LocationX + 1; indexX <= _maxX; indexX++)
                {
                    Tree? nextTree = GetTreeAtLocation(indexX, tree.LocationY);
                    if (nextTree != null)
                    {
                        distance++;
                        if (nextTree.Height >= tree.Height)
                        {
                            break;
                        }
                    }
                }
                if (distance != 0)
                    tree.ScenicScores.Add(distance);

                // Look west
                distance = 0;
                for (int indexX = tree.LocationX - 1; indexX >= 0; indexX--)
                {
                    Tree? nextTree = GetTreeAtLocation(indexX, tree.LocationY);
                    if (nextTree != null)
                    {
                        distance++;
                        if (nextTree.Height >= tree.Height)
                            break;
                    }
                }
                if (distance != 0)
                    tree.ScenicScores.Add(distance);

                // Look north
                distance = 0;
                for (int indexY = tree.LocationY - 1; indexY >= 0; indexY--)
                {
                    Tree? nextTree = GetTreeAtLocation(tree.LocationX, indexY);
                    if (nextTree != null)
                    {
                        distance++;
                        if (nextTree.Height >= tree.Height)
                            break;
                    }
                }
                if (distance != 0)
                    tree.ScenicScores.Add(distance);

                // Look south
                distance = 0;
                for (int indexY = tree.LocationY + 1; indexY <= _maxY; indexY++)
                {
                    Tree? nextTree = GetTreeAtLocation(tree.LocationX, indexY);
                    if (nextTree != null)
                    {
                        distance++;
                        if (nextTree.Height >= tree.Height)
                            break;
                    }
                }
                if (distance != 0)
                    tree.ScenicScores.Add(distance);

                tree.CalculateScenicScoreTotal();
            }
        }

        public int GetHighestScenicScore()
        {
            return _trees.Max(a => a.ScenicScoreTotal);
        }
    }
}

