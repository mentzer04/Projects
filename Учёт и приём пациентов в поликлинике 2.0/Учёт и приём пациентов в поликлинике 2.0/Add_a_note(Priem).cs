using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Учёт_и_приём_пациентов_в_поликлинике_2._0
{
    public partial class Add_a_note_Priem_cs : Form
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-2OB11C0\SQLEXPRESS;Initial Catalog=Поликлиника;Integrated Security=True");

        DataBase database = new DataBase();

        public Add_a_note_Priem_cs()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Add_a_note_Priem_cs_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select distinct id_doctor from Doctor", sqlConnection);
            DataTable tb = new DataTable();
            sd.Fill(tb);
            foreach (DataRow row in tb.Rows)
            {
                comboBox_id_doctor.Items.Add(row["id_doctor"].ToString());
            }

            SqlDataAdapter sw = new SqlDataAdapter("select distinct id_patient from Patient", sqlConnection);
            DataTable tw = new DataTable();
            sw.Fill(tw);
            foreach (DataRow row in tw.Rows)
            {
                comboBox_card_number_patient.Items.Add(row["id_patient"].ToString());
            }
        } // вывод данных в combobox из бд

        private void buttonSave_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var id_doctor = comboBox_id_doctor.Text;
            int id_patient;
            var visit_date = dateTimePicker_visit_date.Text;
            var diagnosis = textBox_diagnosis.Text;
            var therapy = textBox_therapy.Text;

            if (int.TryParse(comboBox_card_number_patient.Text, out id_patient))
            {
                var addQuery = $"insert into Priem (id_doctor, id_patient, visit_date, diagnosis, therapy) values ('{id_doctor}', '{id_patient}', '{visit_date}', '{diagnosis}', '{therapy}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Поле Номер Пациента должно иметь числовое значение!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            database.closeConnection();
            this.Hide();
        } // занесение данных в бд
    }
}
