
namespace Учёт_и_приём_пациентов_в_поликлинике_2._0
{
    partial class Doctor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Doctor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox3_Cabinet = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox2_Qualification = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBox2_Office_hours_until = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.maskedTextBox1_Reception_hours_from = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1_Speciality = new System.Windows.Forms.ComboBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4_Father_name = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3_First_name = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2_Last_name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1_id = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Врачи";
            // 
            // textBox_search
            // 
            this.textBox_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_search.Location = new System.Drawing.Point(669, 13);
            this.textBox_search.Multiline = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(119, 24);
            this.textBox_search.TabIndex = 2;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(599, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Поиск";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.comboBox3_Cabinet);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.comboBox2_Qualification);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.maskedTextBox2_Office_hours_until);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.maskedTextBox1_Reception_hours_from);
            this.panel2.Controls.Add(this.comboBox1_Speciality);
            this.panel2.Controls.Add(this.buttonBack);
            this.panel2.Controls.Add(this.buttonClear);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.buttonChange);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox4_Father_name);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBox3_First_name);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.textBox2_Last_name);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBox1_id);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonNew);
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.buttonRefresh);
            this.panel2.Location = new System.Drawing.Point(12, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 190);
            this.panel2.TabIndex = 5;
            // 
            // comboBox3_Cabinet
            // 
            this.comboBox3_Cabinet.FormattingEnabled = true;
            this.comboBox3_Cabinet.Location = new System.Drawing.Point(567, 43);
            this.comboBox3_Cabinet.Name = "comboBox3_Cabinet";
            this.comboBox3_Cabinet.Size = new System.Drawing.Size(81, 21);
            this.comboBox3_Cabinet.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(462, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 15);
            this.label12.TabIndex = 37;
            this.label12.Text = "Квалификация";
            // 
            // comboBox2_Qualification
            // 
            this.comboBox2_Qualification.FormattingEnabled = true;
            this.comboBox2_Qualification.Location = new System.Drawing.Point(465, 43);
            this.comboBox2_Qualification.Name = "comboBox2_Qualification";
            this.comboBox2_Qualification.Size = new System.Drawing.Size(96, 21);
            this.comboBox2_Qualification.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(109, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 15);
            this.label11.TabIndex = 35;
            this.label11.Text = "Время приёма до:";
            // 
            // maskedTextBox2_Office_hours_until
            // 
            this.maskedTextBox2_Office_hours_until.Location = new System.Drawing.Point(112, 94);
            this.maskedTextBox2_Office_hours_until.Mask = "00:00";
            this.maskedTextBox2_Office_hours_until.Name = "maskedTextBox2_Office_hours_until";
            this.maskedTextBox2_Office_hours_until.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox2_Office_hours_until.TabIndex = 34;
            this.maskedTextBox2_Office_hours_until.ValidatingType = typeof(System.DateTime);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 15);
            this.label9.TabIndex = 33;
            this.label9.Text = "Время приёма с:";
            // 
            // maskedTextBox1_Reception_hours_from
            // 
            this.maskedTextBox1_Reception_hours_from.Location = new System.Drawing.Point(6, 94);
            this.maskedTextBox1_Reception_hours_from.Mask = "00:00";
            this.maskedTextBox1_Reception_hours_from.Name = "maskedTextBox1_Reception_hours_from";
            this.maskedTextBox1_Reception_hours_from.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBox1_Reception_hours_from.TabIndex = 32;
            this.maskedTextBox1_Reception_hours_from.ValidatingType = typeof(System.DateTime);
            // 
            // comboBox1_Speciality
            // 
            this.comboBox1_Speciality.FormattingEnabled = true;
            this.comboBox1_Speciality.Location = new System.Drawing.Point(358, 43);
            this.comboBox1_Speciality.Name = "comboBox1_Speciality";
            this.comboBox1_Speciality.Size = new System.Drawing.Size(101, 21);
            this.comboBox1_Speciality.TabIndex = 31;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.White;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBack.Location = new System.Drawing.Point(3, 158);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(98, 25);
            this.buttonBack.TabIndex = 30;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClear.BackgroundImage")));
            this.buttonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClear.Location = new System.Drawing.Point(736, 42);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(33, 33);
            this.buttonClear.TabIndex = 29;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(565, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 15);
            this.label10.TabIndex = 28;
            this.label10.Text = "Кабинет";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(356, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 15);
            this.label8.TabIndex = 24;
            this.label8.Text = "Специальность";
            // 
            // buttonChange
            // 
            this.buttonChange.BackColor = System.Drawing.Color.White;
            this.buttonChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonChange.Location = new System.Drawing.Point(567, 158);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(98, 25);
            this.buttonChange.TabIndex = 22;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = false;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(249, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Отчество";
            // 
            // textBox4_Father_name
            // 
            this.textBox4_Father_name.Location = new System.Drawing.Point(252, 43);
            this.textBox4_Father_name.Name = "textBox4_Father_name";
            this.textBox4_Father_name.Size = new System.Drawing.Size(100, 20);
            this.textBox4_Father_name.TabIndex = 10;
            this.textBox4_Father_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_Father_name_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(143, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Имя";
            // 
            // textBox3_First_name
            // 
            this.textBox3_First_name.Location = new System.Drawing.Point(146, 43);
            this.textBox3_First_name.Name = "textBox3_First_name";
            this.textBox3_First_name.Size = new System.Drawing.Size(100, 20);
            this.textBox3_First_name.TabIndex = 8;
            this.textBox3_First_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_First_name_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(37, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Фамилия";
            // 
            // textBox2_Last_name
            // 
            this.textBox2_Last_name.Location = new System.Drawing.Point(40, 43);
            this.textBox2_Last_name.Name = "textBox2_Last_name";
            this.textBox2_Last_name.Size = new System.Drawing.Size(100, 20);
            this.textBox2_Last_name.TabIndex = 6;
            this.textBox2_Last_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_Last_name_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "id";
            // 
            // textBox1_id
            // 
            this.textBox1_id.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1_id.Location = new System.Drawing.Point(4, 43);
            this.textBox1_id.Name = "textBox1_id";
            this.textBox1_id.ReadOnly = true;
            this.textBox1_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1_id.Size = new System.Drawing.Size(30, 20);
            this.textBox1_id.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(-2, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Управление записями";
            // 
            // buttonNew
            // 
            this.buttonNew.BackColor = System.Drawing.Color.White;
            this.buttonNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNew.Location = new System.Drawing.Point(463, 158);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(98, 25);
            this.buttonNew.TabIndex = 1;
            this.buttonNew.Text = "Создать запись";
            this.buttonNew.UseVisualStyleBackColor = false;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSave.BackgroundImage")));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.Location = new System.Drawing.Point(736, 81);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(33, 33);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.White;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDelete.Location = new System.Drawing.Point(671, 158);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(98, 25);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.BackgroundImage")));
            this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRefresh.ImageKey = "(отсутствует)";
            this.buttonRefresh.Location = new System.Drawing.Point(736, 3);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(33, 33);
            this.buttonRefresh.TabIndex = 2;
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 263);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(776, 297);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // Doctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(196)))), ((int)(((byte)(221)))));
            this.ClientSize = new System.Drawing.Size(800, 572);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.label1);
            this.Name = "Doctor";
            this.Text = "Врачи";
            this.Load += new System.EventHandler(this.Doctor_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4_Father_name;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox3_First_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox2_Last_name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1_id;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ComboBox comboBox1_Speciality;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1_Reception_hours_from;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2_Office_hours_until;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox2_Qualification;
        private System.Windows.Forms.ComboBox comboBox3_Cabinet;
    }
}