using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RobeSpriteCopier
{
    public partial class Form1 : Form
    {
        private string version = "0.1";
        public Form1()
        {
            InitializeComponent();
            this.Text += " v" + version;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //ダイアログのタイトルを指定する
            ofd.Title = "ファイルを選択して下さい";
            ofd.Filter = "(*.spr)|*.spr|すべてのファイル(*.*)|*.*";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string spr_path = ofd.FileName;


            IEnumerable<string> files = Directory.EnumerateFiles(Path.GetDirectoryName(spr_path), "*", System.IO.SearchOption.AllDirectories);

            //ファイルを列挙する
            foreach (string f in files)
            {
                if(Path.GetExtension(f) == ".act")
                {
                    File.Copy(
                        spr_path,
                        Path.GetDirectoryName(f) + "\\" + Path.GetFileNameWithoutExtension(f) + ".spr"
                        );
                }
            }
            System.Media.SystemSounds.Asterisk.Play();
        }
    }
}
