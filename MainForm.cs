using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFA_SendingEmail.UsersClasses;
using static WFA_SendingEmail.UsersClasses.InfoEmailSending;

namespace WFA_SendingEmail
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBoxEmail.Text = "task_code_development@list.ru";
            textBoxName.Text = "Артем Сергеевич";
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void buttonSent_Click(object sender, EventArgs e)
        {
            //проверка TextBox на наличие значений
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
            string.IsNullOrWhiteSpace(textBoxName.Text) ||
            string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
            string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            string smtp = " smtp.mail.ru ";
            StringPair fromInfo = new StringPair("maluish2004@mail.ru", "Шеховцов Иван Александрович");
            string password = "ncx135NzJ4CBj51dYGWx";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);
            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now} \n" +
            $"{Dns.GetHostName()} \n" +
            $"{Dns.GetHostAddresses(Dns.GetHostName()).First()} \n" +
            $"{textBoxBody.Text}";

            InfoEmailSending info =
            new InfoEmailSending(smtp, fromInfo, password, toInfo, subject, body);
            SendingEmail sendingEmail = new SendingEmail(info);
            sendingEmail.Send();

            MessageBox.Show("Письмо отправлено!");
            foreach (TextBox textBox in Controls.OfType<TextBox>())
                textBox.Text = "";
        }
    }
}
