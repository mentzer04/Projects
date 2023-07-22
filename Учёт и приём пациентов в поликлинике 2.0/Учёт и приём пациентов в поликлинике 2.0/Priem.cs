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
    enum RowState3
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Priem : Form
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-2OB11C0\SQLEXPRESS;Initial Catalog=Поликлиника;Integrated Security=True");

        DataBase database = new DataBase();

        int selectedRow;

        public Priem()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_priem", "Номер приёма");
            dataGridView1.Columns.Add("id_doctor", "Номер врача");
            dataGridView1.Columns.Add("id_patient", "Номер пациента");
            dataGridView1.Columns.Add("visit_date", "Дата посещения");
            dataGridView1.Columns.Add("diagnosis", "Диагноз");
            dataGridView1.Columns.Add("therapy", "Лечение");
            dataGridView1.Columns.Add("IsNew", String.Empty);
            this.dataGridView1.Columns["IsNew"].Visible = false;
        }  // вывод полей

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetString(5), RowState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Priem";

            SqlCommand command = new SqlCommand(queryString, database.getConnection());

            database.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);

            }
            reader.Close();
        }

        private void Priem_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select distinct id_doctor from Doctor", sqlConnection);
            DataTable tb = new DataTable();
            sd.Fill(tb);
            foreach (DataRow row in tb.Rows)
            {
                comboBox1_id_doctor.Items.Add(row["id_doctor"].ToString());
            }

            SqlDataAdapter sq = new SqlDataAdapter("select distinct id_patient from Patient", sqlConnection);
            DataTable tq = new DataTable();
            sq.Fill(tq);
            foreach (DataRow row in tq.Rows)
            {
                comboBox2_id_patient.Items.Add(row["id_patient"].ToString());
            }
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        } // вывод данных в combobox

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox1_id.Text = row.Cells[0].Value.ToString();
                comboBox1_id_doctor.Text = row.Cells[1].Value.ToString();
                comboBox2_id_patient.Text = row.Cells[2].Value.ToString();
                dateTimePicker1_Visit_date.Text = row.Cells[3].Value.ToString();
                textBox3_Diagnosis.Text = row.Cells[4].Value.ToString();
                textBox4_Therapy.Text = row.Cells[5].Value.ToString();
            }
        } //  вывод данных в поля

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        } // обновление таблицы

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Add_a_note_Priem_cs addfrm = new Add_a_note_Priem_cs();
            addfrm.Show();
        } // переход на форму создания записи Пациента

        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Priem where concat(id_doctor, id_patient, visit_date, diagnosis, therapy) like '%" + textBox_search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, database.getConnection());

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
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
                    dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
                    return;
                }
                dataGridView1.Rows[index].Cells[6].Value = RowState.Deleted;
            }
            catch
            {
                MessageBox.Show("Выберите запись на удаление!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } // метод удаления данных

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
                var id_doctor = comboBox1_id_doctor.Text;
                int id_patient;
                var vidit_date = dateTimePicker1_Visit_date.Text;
                var diagnosis = textBox3_Diagnosis.Text;
                var therapy = textBox4_Therapy.Text;

                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    if (int.TryParse(comboBox2_id_patient.Text, out id_patient))
                    {
                        dataGridView1.Rows[selectedRowIndex].SetValues(id, id_doctor, id_patient, vidit_date, diagnosis, therapy);
                        dataGridView1.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
                    }
                    else
                    {
                        MessageBox.Show("Поле Номер амбулаторной карты должно иметь числовой формат!");
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

        private void Update()
        {
            database.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Priem where id_priem = {id}";

                    var command = new SqlCommand(deleteQuery, database.getConnection());
                    MessageBox.Show("Изменения внесены в базу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id_priem = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var id_doctor = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var id_patient = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var visit_date = dataGridView1.Rows[index].Cells[3].Value.ToString();
                    var diagnosis = dataGridView1.Rows[index].Cells[4].Value.ToString();
                    var therapy = dataGridView1.Rows[index].Cells[5].Value.ToString();

                    var changeQuery = $"update Priem set id_doctor = '{id_doctor}', id_patient = '{id_patient}', visit_date = '{visit_date}', diagnosis = '{diagnosis}', therapy = '{therapy}' where id_priem = '{id_priem}'";
                    var command = new SqlCommand(changeQuery, database.getConnection());
                    MessageBox.Show("Изменения внесены в базу!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    command.ExecuteNonQuery();
                }

            }
            database.closeConnection();
        } // метод изменения данных

         private void buttonSave_Click(object sender, EventArgs e)
        {
            Update();
            ClearFields();
        } // сохранение данных

        private void ClearFields()
        {
            textBox1_id.Text = "";
            comboBox1_id_doctor.Text = "";
            comboBox2_id_patient.Text = "";
            dateTimePicker1_Visit_date.Text = "";
            textBox3_Diagnosis.Text = "";
            textBox4_Therapy.Text = "";
        } // метод очистки данных

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        } // очистка данных

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        } // переход на главное меню

        private void buttonNew_Click_1(object sender, EventArgs e)
        {
            Add_a_note_Priem_cs addfrm = new Add_a_note_Priem_cs();
            addfrm.Show();
        } // переход на создание записи

        private void textBox3_Diagnosis_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я 0-9 ,]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничения в textbox

        private void textBox4_Therapy_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я 0-9 ,]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } //  ограничения в textbox
    }
}
