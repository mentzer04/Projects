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

namespace Учёт_и_приём_пациентов_в_поликлинике_2._0
{
    enum RowState2
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Doctor : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-2OB11C0\SQLEXPRESS;Initial Catalog=Поликлиника;Integrated Security=True");

        DataBase database = new DataBase();

        int selectedRow;

        public Doctor()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_doctor", "id");
            dataGridView1.Columns.Add("last_name", "Фамилия");
            dataGridView1.Columns.Add("first_name", "Имя");
            dataGridView1.Columns.Add("father_name", "Отчество");
            dataGridView1.Columns.Add("speciality", "Специальность");
            dataGridView1.Columns.Add("qualification", "Квалификация");
            dataGridView1.Columns.Add("cabinet", "Кабинет");
            dataGridView1.Columns.Add("reception_hours_from", "Время приёма с");
            dataGridView1.Columns.Add("office_hours_until", "Время приёма до");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            this.dataGridView1.Columns["IsNew"].Visible = false;
        } // переименовываем столбцы

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetInt32(6), record.GetString(7), record.GetString(8), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Doctor";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);

            }
            reader.Close();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select distinct speciality from Speciality", sqlConnection);
            DataTable tb = new DataTable();
            sd.Fill(tb);
            foreach (DataRow row in tb.Rows)
            {
                comboBox1_Speciality.Items.Add(row["speciality"].ToString());
            }
            CreateColumns();
            RefreshDataGrid(dataGridView1);

            SqlDataAdapter sq = new SqlDataAdapter("select distinct qualification from Qualification", sqlConnection);
            DataTable tq = new DataTable();
            sq.Fill(tq);
            foreach (DataRow row in tq.Rows)
            {
                comboBox2_Qualification.Items.Add(row["qualification"].ToString());
            }

            SqlDataAdapter sw = new SqlDataAdapter("select distinct cabinet from Cabinet", sqlConnection);
            DataTable tw = new DataTable();
            sw.Fill(tw);
            foreach (DataRow row in tw.Rows)
            {
                comboBox3_Cabinet.Items.Add(row["cabinet"].ToString());
            }
        } // вывод данных в comboBox(специальность, квалификация, кабинеты)

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1_id.Text = row.Cells[0].Value.ToString();
                textBox2_Last_name.Text = row.Cells[1].Value.ToString();
                textBox3_First_name.Text = row.Cells[2].Value.ToString();
                textBox4_Father_name.Text = row.Cells[3].Value.ToString();
                comboBox1_Speciality.Text = row.Cells[4].Value.ToString();
                comboBox2_Qualification.Text = row.Cells[5].Value.ToString();
                comboBox3_Cabinet.Text = row.Cells[6].Value.ToString();
                maskedTextBox1_Reception_hours_from.Text = row.Cells[7].Value.ToString();
                maskedTextBox2_Office_hours_until.Text = row.Cells[8].Value.ToString();
            }
        } // вывод данных в поля

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        } // обновление таблицы

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Add_a_note_Doctor_ addfrm = new Add_a_note_Doctor_();
            addfrm.Show();
        } // переход на форму создания записи Врача

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Doctor where concat(id_doctor, last_name, first_name, father_name, speciality, qualification, cabinet, reception_hours_from, office_hours_until) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }

            read.Close();
        } // метод поиска данных

        private void textBox_search_TextChanged(object sender, EventArgs e) // поиск данных
        {
            Search(dataGridView1);
        }

        private void deleteRow()
        {
            try
            {
                int index = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows[index].Visible = false;

                if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
                    return;
                }
                dataGridView1.Rows[index].Cells[9].Value = RowState.Deleted;
            }
            catch
            {
                MessageBox.Show("Выберите запись на удаление!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // метод удаления данных

        private void Update()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[9].Value;

                if (rowState == RowState.Existed)
                    continue;

                try
                {
                    if (rowState == RowState.Deleted)
                    {
                        var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                        var deleteQuery = $"delete from Doctor where id_doctor = {id}";

                        var command = new SqlCommand(deleteQuery, database.getConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Изменения внесены в базу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Прежде чем удалить врача, снимите его с приёма!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var last_name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var first_name = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var father_name = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var speciality = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var qualification = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var cabinet = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var reception_hours_from = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var office_hours_until = dataGridView1.Rows[index].Cells[8].Value.ToString();

                    var changeQuery = $"update Doctor set last_name = '{last_name}', first_name = '{first_name}', father_name = '{father_name}', speciality = '{speciality}', qualification = '{qualification}', cabinet = '{cabinet}', reception_hours_from = '{reception_hours_from}', office_hours_until = '{office_hours_until}' where id_doctor = '{id}'";
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
        }  // сохранения данных

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteRow();
        } // удаление денных

        private void Change()
        {
            try
            {
                var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

                var id = textBox1_id.Text;
                var last_name = textBox2_Last_name.Text;
                var first_name = textBox3_First_name.Text;
                var father_name = textBox4_Father_name.Text;
                var speciality = comboBox1_Speciality.Text;
                var qualification = comboBox2_Qualification.Text;
                int cabinet;
                var reception_hours_from = maskedTextBox1_Reception_hours_from.Text;
                var office_hours_until = maskedTextBox2_Office_hours_until.Text;

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    if (int.TryParse(comboBox3_Cabinet.Text, out cabinet))
                    {
                        dataGridView1.Rows[selectedRowIndex].SetValues(id, last_name, first_name, father_name, speciality, qualification, cabinet, reception_hours_from, office_hours_until);
                        dataGridView1.Rows[selectedRowIndex].Cells[9].Value = RowState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("Поле Кабинет должно иметь числовой формат!");
                    }
                }
            }
            catch
            {
                MessageBox.Show("На изменение не выбранно ни одной записи!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // метод зменения данных

        private void buttonChange_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        } // изменение денных

        private void ClearFields()
        {
            textBox1_id.Text = "";
            textBox2_Last_name.Text = "";
            textBox3_First_name.Text = "";
            textBox4_Father_name.Text = "";
            comboBox1_Speciality.Text = "";
            comboBox2_Qualification.Text = "";
            comboBox3_Cabinet.Text = "";
            maskedTextBox1_Reception_hours_from.Text = "";
            maskedTextBox2_Office_hours_until.Text = "";
        }  // иетод отчистки полей

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        } // отчистка полей

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
    }
}
