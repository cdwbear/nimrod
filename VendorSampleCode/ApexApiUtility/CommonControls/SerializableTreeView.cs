using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonControls
{
	public partial class SerializableTreeView : TreeView, ISerializable
	{
		public SerializableTreeView()
		{
			InitializeComponent();
		}

		public SerializableTreeView(IContainer container)
		{
			container.Add(this);

			InitializeComponent();
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new NotImplementedException();
		}
	}
}
