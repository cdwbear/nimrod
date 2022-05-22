using System;
using System.Collections.Generic;

namespace TowersOfHanoi
{
    public class TowerSolver
    {
        private int _numberOfDiscs = 0;
        private int _numberOfTowers = 3;
        private Form1 _mainForm = new Form1();
        private int _moveCount;

        private enum StackLabel : int
        {
            Left,
            Middle,
            Right
        }

        private Dictionary<int, Stack<int>> towers = new Dictionary<int, Stack<int>>();

        public TowerSolver(Form1 mainForm, int numberOfDiscs)
        {
            _numberOfDiscs = numberOfDiscs;
            _mainForm = mainForm;

            int count = _numberOfDiscs;

        }

        private void initTowers()
        {
            foreach (int towerIdx in Enum.GetValues(typeof(StackLabel)))
            {
                towers.Add(towerIdx, new Stack<int>());
            }

            int count = _numberOfDiscs;
            while (count > 0)
            {
                towers[0].Push(count--);
            }
        }

        private void Play()
        {
            int towerIdx = 0;
            int val = towers[towerIdx].Peek();
            int nextTower = NavigateLeft(towerIdx);

            if (towers[nextTower].Count == 0 || towers[nextTower].Peek() > val)
            {
                towers[nextTower].Push(towers[towerIdx].Pop());
            }

            val = towers[towerIdx].Peek();

            if (towers[nextTower].Count == 0 || towers[nextTower].Peek() > val)
            {
                towers[nextTower].Push(towers[towerIdx].Pop());
            }
            else
            {
                nextTower = NavigateLeft(nextTower);
            }

            if (towers[nextTower].Count == 0 || towers[nextTower].Peek() > val)
            {
                towers[nextTower].Push(towers[towerIdx].Pop());
            }

        }

        private int NavigateLeft(int currentTower)
        {
            return (currentTower == 0 ? _numberOfTowers - 1 : --currentTower);
        }

        //public void moveTower(int height, string fromPole, string toPole, string withPole)
        public void moveTower(int height, string fromPole, string withPole, string toPole)
        {
            _mainForm.richTextBoxStack.AppendText($"height: {height}, fromPole: {fromPole}, toPole: {toPole}, withPole: {withPole}\r\n");

            if (height >= 1)
            {
                // moveTower(height - 1, fromPole, withPole, toPole);
                moveTower(height - 1, fromPole, toPole, withPole);
                moveDisk(fromPole, toPole);
                //moveTower(height - 1, withPole, toPole, fromPole);
                moveTower(height - 1, withPole, fromPole, toPole);
            }
        }

        private void moveDisk(string fp, string tp)
        {
            _mainForm.richTextBoxMoves.AppendText($"{++_moveCount}: moving disk from {fp} to {tp}\r\n");
            _mainForm.richTextBoxStack.AppendText($"{_moveCount}: moving disk from {fp} to {tp}\r\n");
        }

        public void moveTower2(int height, string fromPole, string toPole, string withPole)
        {
            _mainForm.richTextBoxStack.AppendText($"height: {height}, fromPole: {fromPole}, toPole: {toPole}, withPole: {withPole}\r\n");

            if (height == 1)
            {
                moveDisk(fromPole, toPole);
            }
            else
            {
                moveTower2(height - 1, fromPole, withPole, toPole);
                moveDisk(fromPole, toPole);
                _mainForm.richTextBoxStack.AppendText($"height: {height}, fromPole: {fromPole}, toPole: {toPole}, withPole: {withPole}\r\n");
                moveTower2(height-1, withPole, toPole, fromPole);
            }
        }
    }
}
