using System.Windows.Forms;
using TaskManagerCommandsLib;
using System.Diagnostics;
using System.ComponentModel.Design;
using TaskManagerCommandsLib.Commands;
using System;

namespace TaskManagerWinAPI
{
    public partial class Form1 : Form
    {
        Manager manager = new Manager();
        StartProcess process = new StartProcess();
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadTable()
        {
            string[] str = new string[1];
            string[] pid = manager.ExecuteCommand("GPID").Split(' ');
            string[] pName = manager.ExecuteCommand("GPNAME").Split('\\');
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(pid.Length);
            for (int i = 0; i < dataGridView1.Rows.Count - 2; i++)
            {
                dataGridView1[0, i].Value = pid[i];
                dataGridView1[1, i].Value = pName[i];
            }
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "Обновить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 65);
            this.button2.TabIndex = 1;
            this.button2.Text = "Завершить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(276, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 65);
            this.button3.TabIndex = 2;
            this.button3.Text = "Завершить дерево процессов";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(563, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(132, 63);
            this.button4.TabIndex = 3;
            this.button4.Text = "Запустить приложение";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(411, 14);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(146, 64);
            this.listBox1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ProcName});
            this.dataGridView1.Location = new System.Drawing.Point(12, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(683, 384);
            this.dataGridView1.TabIndex = 5;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 320;
            // 
            // ProcName
            // 
            this.ProcName.HeaderText = "Имя процесса";
            this.ProcName.Name = "ProcName";
            this.ProcName.Width = 320;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(704, 480);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTable();
            listBox1.Items.AddRange(process.ReturnAppsNames());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentRow = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            manager.ExecuteCommand("KP " + (dataGridView1[0, currentRow]).Value.ToString());
            LoadTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int currentRow = Convert.ToInt32(dataGridView1.CurrentCell.RowIndex);
            manager.ExecuteCommand("KP " + dataGridView1[1, currentRow].Value.ToString());
            LoadTable();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            manager.ExecuteCommand("SP " + listBox1.SelectedItem.ToString());
            LoadTable();
        }
    }
}