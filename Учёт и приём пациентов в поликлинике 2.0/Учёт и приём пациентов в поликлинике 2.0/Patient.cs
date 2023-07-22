using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Учёт_и_приём_пациентов_в_поликлинике_2._0
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Patient : Form
    {

        DataBase database = new DataBase();

        int selectedRow;

        public Patient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_patient", "id");
            dataGridView1.Columns.Add("last_name", "Фамилия");
            dataGridView1.Columns.Add("first_name", "Имя");
            dataGridView1.Columns.Add("father_name", "Отчество");
            dataGridView1.Columns.Add("birthday", "Дата рождения");
            dataGridView1.Columns.Add("address_of", "Адрес");
            dataGridView1.Columns.Add("polisy_OMS", "Полис ОМС");
            dataGridView1.Columns.Add("card_number", "Номер карты");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            this.dataGridView1.Columns["IsNew"].Visible = false;
        } // переименовываем столбцы

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetInt32(7), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Patient";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                ReadSingleRow(dgw, reader);

            }
            reader.Close();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1_id.Text = row.Cells[0].Value.ToString();
                textBox2_Last_name.Text = row.Cells[1].Value.ToString();
                textBox3_First_name.Text = row.Cells[2].Value.ToString();
                textBox4_Father_name.Text = row.Cells[3].Value.ToString();
                dateTimePicker1_Birthday.Text = row.Cells[4].Value.ToString();
                textBox6_Address.Text = row.Cells[5].Value.ToString();
                maskedTextBox2_Polisy_OMS.Text = row.Cells[6].Value.ToString();
                maskedTextBox1_Card_number.Text = row.Cells[7].Value.ToString();
            }
        } //вывод данных в поля

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        } // обновление таблицы

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Add_a_note addfrm = new Add_a_note();
            addfrm.Show();
        } // переход на форму создания записи Пациента

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Patient where concat(id_patient, last_name, first_name, father_name, birthday, address_of, polisy_OMS, card_number) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());

            SqlDataReader read = com.ExecuteReader();

            while(read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        } // метод поиска данных

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        } // поиск данных

        private void deleteRow()
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex; 

                dataGridView1.Rows[index].Visible = false;

                if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridView1.Rows[index].Cells[8].Value = RowState.Deleted;
                    return;
                }
                dataGridView1.Rows[index].Cells[8].Value = RowState.Deleted;
            }
            catch
            {
                MessageBox.Show("Выберите запись на удаление!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }  // метод удаления данных

        private void Update()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[8].Value;

                if (rowState == RowState.Existed)
                    continue;

                try
                {
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Patient where id_patient = {id}";

                        var command = new SqlCommand(deleteQuery, database.getConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Изменения внесены в базу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Прежде чем удалить пациента, снимите его с приёма!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if(rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var last_name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var first_name = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var father_name = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var birthday = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var address = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var polisy_OMS = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var card_number = dataGridView1.Rows[index].Cells[7].Value.ToString();

                    var changeQuery = $"update Patient set last_name = '{last_name}', first_name = '{first_name}', father_name = '{father_name}', birthday = '{birthday}', address_of = '{address}', polisy_OMS = '{polisy_OMS}', card_number = '{card_number}' where id_patient = '{id}'";
                    var command = new SqlCommand(changeQuery, database.getConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменения внесены в базу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            database.closeConnection();
        } // метод сохранения данных

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Update();
            ClearFields();
        } // сохранение данных

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteRow();
        } // удаление данных
         
        private void Change()
        {
            try
            {
                var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

                var id = textBox1_id.Text;
                var last_name = textBox2_Last_name.Text;
                var first_name = textBox3_First_name.Text;
                var father_name = textBox4_Father_name.Text;
                var birthday = dateTimePicker1_Birthday.Text;
                var address = textBox6_Address.Text;
                var polisy_OMS = maskedTextBox2_Polisy_OMS.Text;
                int card_number;

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    if (int.TryParse(maskedTextBox1_Card_number.Text, out card_number))
                    {
                        dataGridView1.Rows[selectedRowIndex].SetValues(id, last_name, first_name, father_name, birthday, address, polisy_OMS, card_number);
                        dataGridView1.Rows[selectedRowIndex].Cells[8].Value = RowState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("Поле Номер карты должно иметь числовой формат!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("На изменение не выбранно ни одной записи!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // метод изменения данных

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        } // изменение данных

        private void ClearFields()
        {
            textBox1_id.Text = "";
            textBox2_Last_name.Text = "";
            textBox3_First_name.Text = "";
            textBox4_Father_name.Text = "";
            dateTimePicker1_Birthday.Text = "";
            textBox6_Address.Text = "";
            maskedTextBox2_Polisy_OMS.Text = "";
            maskedTextBox1_Card_number.Text = "";
        } // метод отчистки данных

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            ClearFields();
        } // отчистка данных

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        } // переход на Главное окно

        private void textBox2_Last_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме букв и beckspace

        private void textBox3_First_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме букв и beckspace

        private void textBox4_Father_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме букв и beckspace

        private void textBox7_Polisy_OMS_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(8))
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме цифр и beckspace
    }
}
