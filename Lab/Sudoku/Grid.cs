using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
	public class Grid
	{
		private int Base = 0;
		public class Cell
		{
			public int[,,] Notes = null;
			public int Value { get; set; }

		}

		public class Block
		{
			public Cell[,,] Cells = null;
		}

		public Block[,,] Blocks = null;

		public Grid(int baseDim)
		{
			Base = baseDim;

			Cell c = new Cell
			{
				Notes = new int[Base,Base,Base],
			};

			Block b = new Block()
			{
				Cells = new Cell[Base, Base, Base]
			};

			Blocks = new Block[Base,Base,Base];
		}


	}
}
