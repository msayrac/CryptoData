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

namespace CryptoData
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}


		void listele()
		{
			SqlDataAdapter da = new SqlDataAdapter("Select * from TBLVERILER", connection);
			DataTable dt = new DataTable();
			da.Fill(dt);
			dataGridView1.DataSource = dt;
		}

		void sifrele()
		{
			string ad = TxtAd.Text;
			byte[] adDizisi = ASCIIEncoding.ASCII.GetBytes(ad);
			string adSifre = Convert.ToBase64String(adDizisi);

			string soyad = TxtSoyad.Text;
			byte[] soyadDizisi = ASCIIEncoding.ASCII.GetBytes(soyad);
			string soyadSifre = Convert.ToBase64String(soyadDizisi);

			string mail = TxtMail.Text;
			byte[] mailDizisi = ASCIIEncoding.ASCII.GetBytes(mail);
			string mailSifre = Convert.ToBase64String(mailDizisi);

			string sifre = TxtSifre.Text;
			byte[] sifreDizisi = ASCIIEncoding.ASCII.GetBytes(sifre);
			string sifreSifre = Convert.ToBase64String(sifreDizisi);

			string hesapno = TxtHesapNo.Text;
			byte[] hesapDizisi = ASCIIEncoding.ASCII.GetBytes(hesapno);
			string hesapnoSifre = Convert.ToBase64String(hesapDizisi);

			connection.Open();
			SqlCommand command = new SqlCommand("insert into TBLVERILER (AD, SOYAD,MAIL,SIFRE,HESAPNO) values (@P1,@P2,@P3,@P4,@P5)", connection);
			command.Parameters.AddWithValue("@P1", adSifre);
			command.Parameters.AddWithValue("@P2", soyadSifre);
			command.Parameters.AddWithValue("@P3", mailSifre);
			command.Parameters.AddWithValue("@P4", sifreSifre);
			command.Parameters.AddWithValue("@P5", hesapnoSifre);

			command.ExecuteNonQuery();
			connection.Close();
			MessageBox.Show("Sifreli Veriler Eklendi");
			listele();
		}

		//void listelecoz()
		//{
		//	connection.Open();

		//	SqlDataAdapter da = new SqlDataAdapter("Select * from TBLVERILER", connection);

		//	DataTable dt = new DataTable();

		//	da.Fill(dt);

		//	dataGridView1.DataSource = dt;

		//	DataTable dt2 = new DataTable();

		//	dt2.Columns.Add("ID");
		//	dt2.Columns.Add("AD");
		//	dt2.Columns.Add("SOYAD");
		//	dt2.Columns.Add("MAIL");
		//	dt2.Columns.Add("SIFRE");
		//	dt2.Columns.Add("HESAPNO");

		//	for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
		//	{
		//		DataRow r = dt2.NewRow();
		//		for (int j = 0; j < dataGridView1.Columns.Count; j++)
		//		{
		//			try
		//			{
		//				string cozum = dataGridView1.Rows[i].Cells[j].Value.ToString();
		//				byte[] cozumdizi = Convert.FromBase64String(cozum);
		//				string cozumveri = ASCIIEncoding.ASCII.GetString(cozumdizi);

		//				r[j] = cozumveri;
		//			}
		//			catch
		//			{
		//				r[j] = dataGridView1.Rows[i].Cells[j].Value.ToString();
		//			}
		//		}

		//		dt2.Rows.Add(r);
		//	}
		//	dataGridView2.DataSource = dt2;
		//}

		SqlConnection connection = new SqlConnection(@"Data Source=msyc;Initial Catalog=Test;Integrated Security=True");
		private void BtnKaydet_Click(object sender, EventArgs e)
		{
			sifrele();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listele();
			//listelecoz();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string adCozum = TxtAd.Text;
			byte[] adCozumDizi = Convert.FromBase64String(adCozum);
			string adVerisi = ASCIIEncoding.ASCII.GetString(adCozumDizi);

			label6.Text = adVerisi.ToString();

			string soyadCozum = TxtSoyad.Text;
			byte[] soyadCozumDizi = Convert.FromBase64String(soyadCozum);
			string soyadVerisi = ASCIIEncoding.ASCII.GetString(soyadCozumDizi);

			string mailCozum = TxtMail.Text;
			byte[] mailCozumDizisi = Convert.FromBase64String(mailCozum);
			string mailVerisi = ASCIIEncoding.ASCII.GetString(mailCozumDizisi);

			string sifreCOzum = TxtSifre.Text;
			byte[] sifreDizisi = Convert.FromBase64String(sifreCOzum);
			string sifrVerisi = ASCIIEncoding.ASCII.GetString(sifreDizisi);

			string hesapNoCozum = TxtHesapNo.Text;
			byte[] hesapnoDizi = Convert.FromBase64String(hesapNoCozum);
			string hesapNoVerisi = ASCIIEncoding.ASCII.GetString(hesapnoDizi);


		}
	}
}
