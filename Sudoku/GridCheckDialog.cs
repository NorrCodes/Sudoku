using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
	public partial class GridCheckDialog : Form
	{
		internal int? grid = null;
		internal int? value = null;

		public GridCheckDialog ()
		{
			InitializeComponent();
			addEventHandlers();
		}

		void addEventHandlers()
		{
			G1.Click += new EventHandler(Button_Click);
			G2.Click += new EventHandler(Button_Click);
			G3.Click += new EventHandler(Button_Click);
			G4.Click += new EventHandler(Button_Click);
			G5.Click += new EventHandler(Button_Click);
			G6.Click += new EventHandler(Button_Click);
			G7.Click += new EventHandler(Button_Click);
			G8.Click += new EventHandler(Button_Click);
			G9.Click += new EventHandler(Button_Click);
			V1.Click += new EventHandler(Button_Click);
			V2.Click += new EventHandler(Button_Click);
			V3.Click += new EventHandler(Button_Click);
			V4.Click += new EventHandler(Button_Click);
			V5.Click += new EventHandler(Button_Click);
			V6.Click += new EventHandler(Button_Click);
			V7.Click += new EventHandler(Button_Click);
			V8.Click += new EventHandler(Button_Click);
			V9.Click += new EventHandler(Button_Click);
			CheckButton.Click += new EventHandler(Button_Click);
		}

		private void Button_Click (object sender, EventArgs e)
		{
			char[] b = ( (Button)sender ).Name.ToCharArray();

			Text = Convert.ToString(b);

			if (b[0]=='G')
			{
				grid = b[1];

				if(value!=null)
				{
					CheckButton.Visible = true;
				}
			}
			else if (b[0]=='V')
			{
				value = b[1];

				if (grid!= null)
				{
					CheckButton.Visible = true;
				}
			}
			else 
			{
				Visible = false;
			}
		}
	}
}
