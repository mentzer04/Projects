using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Учёт_и_приём_пациентов_в_поликлинике_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Patient_Click(object sender, EventArgs e)
        {
            Patient frm_patient = new Patient();
            frm_patient.Show();
            this.Hide();
        } // переход на форму Пациент

        private void Doctor_Click(object sender, EventArgs e)
        {
            Doctor frm_doctor = new Doctor();
            frm_doctor.Show();
            this.Hide();
        } // переход на форму Доктор

        private void Priem_Click(object sender, EventArgs e)
        {
            Priem frm_priem = new Priem();
            frm_priem.Show();
            this.Hide();
        } // переход на форму Приём

        private void Info_Click(object sender, EventArgs e)
        {
            Info frm_info = new Info();
            frm_info.Show();
        } // переход на форму Информация

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } // кнопка Выхода
    }
}
