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
    public partial class Add_a_note_Doctor_ : Form
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-2OB11C0\SQLEXPRESS;Initial Catalog=Поликлиника;Integrated Security=True");

        DataBase database = new DataBase();

        public Add_a_note_Doctor_()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            database.openConnection();

            var last_name = textBox_last_name.Text;
            var first_name = textBox_first_name.Text;
            var father_name = textBox_father_name.Text;
            var speciality = comboBox_speciality.Text;
            var qualification = comboBox_qualification.Text;
            int cabinet;
            var reception_hours_from = maskedTextBox_reception_hours_from.Text;
            var office_hours_until = maskedTextBox_office_hours_until.Text;

            if (int.TryParse(comboBox_cabinet.Text, out cabinet))
            {
                var addQuery = $"insert into Doctor (last_name, first_name, father_name, speciality, qualification, cabinet, reception_hours_from, office_hours_until) values ('{last_name}', '{first_name}', '{father_name}', '{speciality}', '{qualification}', '{cabinet}', '{reception_hours_from}', '{office_hours_until}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Поле Кабинет должно иметь числовое значение!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            database.closeConnection();
            this.Hide();
        } // занесение данных в бд

        private void Add_a_note_Doctor__Load(object sender, EventArgs e)
        {
            SqlDataAdapter sd = new SqlDataAdapter("select distinct speciality from Speciality", sqlConnection);
            DataTable tb = new DataTable();
            sd.Fill(tb);
            foreach(DataRow row in tb.Rows)
            {
                comboBox_speciality.Items.Add(row["speciality"].ToString());
            }

            SqlDataAdapter sq = new SqlDataAdapter("select distinct qualification from Qualification", sqlConnection);
            DataTable tq = new DataTable();
            sq.Fill(tq);
            foreach (DataRow row in tq.Rows)
            {
                comboBox_qualification.Items.Add(row["qualification"].ToString());
            }

            SqlDataAdapter sw = new SqlDataAdapter("select distinct cabinet from Cabinet", sqlConnection);
            DataTable tw = new DataTable();
            sw.Fill(tw);
            foreach (DataRow row in tw.Rows)
            {
                comboBox_cabinet.Items.Add(row["cabinet"].ToString());
            }
        } // вывод Срециальностей врачей, квалификации, кабинета

        private void textBox_last_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме букв и beckspace

        private void textBox_first_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме букв и beckspace

        private void textBox_father_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Symbol = e.KeyChar.ToString();

            if (!Regex.Match(Symbol, @"[а-яА-Я]").Success && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        } // ограничение на ввод символов кроме букв и beckspace
    }
}
