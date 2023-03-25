using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KR_OS
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			long parts = 3L; // Кол-во частей
			string p = @textBox1.Text;
			using (FileStream fs = new FileStream(p, FileMode.Open, FileAccess.Read))
			{
				long partSz = fs.Length / parts; // Размер одной части
				byte[] buff;
				bool mod = fs.Length % parts == 0; // Все части одного размера
				for (int i = 0; i < parts; i++)
				{
					using (FileStream pStream = new FileStream(string.Format("C:\\Users\\darya\\Desktop\\матлаб\\{0}.part", i), FileMode.Create, FileAccess.Write))
					{
						buff = new byte[i == parts - 1 && !mod ? fs.Length - (parts - 1) * partSz : partSz];
						fs.Read(buff, 0, buff.Length);
						pStream.Write(buff, 0, buff.Length);
					}
					buff = null;
				}
			}
		}
	}
}
