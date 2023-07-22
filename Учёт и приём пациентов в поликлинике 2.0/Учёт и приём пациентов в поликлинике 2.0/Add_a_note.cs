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
    public partial class Add_a_note : Form
    {

        DataBase database = new DataBase();

        public Add_a_note()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var last_name = textBox_last_name.Text;
            var first_name = textBox_first_name.Text;
            var father_name = textBox_father_name.Text;
            var birthday = dateTimePicker_birthday.Text;
            var address = textBox_address.Text;
            var polisy_OMS = maskedTextBox_polisy_OMS.Text;
            int card_number;

            if(int.TryParse(maskedTextBox_card_number.Text, out card_number))
            {
                var addQuery = $"insert into Patient (last_name, first_name, father_name, birthday, address_of, polisy_OMS, card_number) values ('{last_name}', '{first_name}', '{father_name}', '{birthday}', '{address}', '{polisy_OMS}', '{card_number}')";

                var command = new SqlCommand(addQuery, database.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запись успешно создана!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Поле Номер карты должно иметь числовое значение!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            database.closeConnection();
            this.Hide();
        } // занесение данных в бд

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
