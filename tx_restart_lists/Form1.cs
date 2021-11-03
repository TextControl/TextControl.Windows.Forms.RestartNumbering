using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace tx_restart_lists
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // global flag that indicates whether the next inserted list item
        // should be continued
        private bool restartFlag = false;

        // restarts the numbering
        private void button1_Click(object sender, EventArgs e)
        {
            textControl1.Selection.ListFormat.RestartNumbering = true;
            restartFlag = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textControl1.ButtonBar = buttonBar1;
        }

        // continues the following paragraph (item), if the global flag is true
        private void textControl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Return || restartFlag == false) return;

            if (textControl1.Selection.ListFormat.Type == TXTextControl.ListType.Numbered)
            {
                textControl1.Selection.ListFormat.RestartNumbering = false;
                restartFlag = false;
            }
        }
    }
}