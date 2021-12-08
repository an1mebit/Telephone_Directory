using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQL_STUDENTS2.Forms
{
    public partial class FormDelete : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
                           "User Id = {2};Password={3};Database={4}",
                           "localhost", 5432, "postgres", "936X730Az", "Practica2");

        private NpgsqlConnection conn;

        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private int RowIndex;
        public FormDelete()
        {
            InitializeComponent();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor; ;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }

        private new void Select()
        {
            try
            {
                conn.Open();
                sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
                        order by m_id";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void FormDelete_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = -1;
            comboBox2.DataSource = null;
            LoadTheme();
            Init();
            conn = new NpgsqlConnection(connstring);
            Select();
        }

        List<string> list = new List<string>() {"lastname", "firstname", "middlename", "city", "street", "build" };

        public void Init()
        {
            comboBox1.DataSource = list;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            RowIndex = dataGridView1.CurrentCell.RowIndex;
            DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    sql = @"DELETE FROM public.main
	                    WHERE m_id=@u_id; ";
                    cmd = new NpgsqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@u_id", Convert.ToInt32(dataGridView1.Rows[RowIndex].Cells["id"].FormattedValue.ToString()));
                    if (cmd.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Delete student successfully");
                    }
                    conn.Close();
                    Select();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Deleted Error" + ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox2.DataSource = null;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox2.DataSource = null;
                conn.Open();
                DataTable kt = new DataTable();
                NpgsqlDataAdapter adap0 = new NpgsqlDataAdapter("select fam_id, fam_fam from fam", conn);
                adap0.Fill(kt);
                comboBox2.DataSource = kt;
                comboBox2.DisplayMember = "fam_fam";
                comboBox2.ValueMember = "fam_id";
                conn.Close();
            }

            if(comboBox1.SelectedIndex == 1)
            {
                comboBox2.DataSource = null;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter adap = new NpgsqlDataAdapter("select name_id, name_name from name", conn);
                adap.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "name_name";
                comboBox2.ValueMember = "name_id";
                conn.Close();

            }

            if(comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = null;
                conn.Open();
                DataTable bt = new DataTable();
                NpgsqlDataAdapter adap2 = new NpgsqlDataAdapter("select otc_id, otc_otc from otc", conn);
                adap2.Fill(bt);
                comboBox2.DataSource = bt;
                comboBox2.DisplayMember = "otc_otc";
                comboBox2.ValueMember = "otc_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.DataSource = null;
                conn.Open();
                DataTable ft = new DataTable();
                NpgsqlDataAdapter adap3 = new NpgsqlDataAdapter("select city_id, city_city from city", conn);
                adap3.Fill(ft);
                comboBox2.DataSource = ft;
                comboBox2.DisplayMember = "city_city";
                comboBox2.ValueMember = "city_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.DataSource = null;
                conn.Open();
                DataTable at = new DataTable();
                NpgsqlDataAdapter adap4 = new NpgsqlDataAdapter("select str_id, str_str from str", conn);
                adap4.Fill(at);
                comboBox2.DataSource = at;
                comboBox2.DisplayMember = "str_str";
                comboBox2.ValueMember = "str_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 5)
            {
                comboBox2.DataSource = null;
                conn.Open();
                DataTable tt = new DataTable();
                NpgsqlDataAdapter adap5 = new NpgsqlDataAdapter("select bld_id, bld_bld from bld", conn);
                adap5.Fill(tt);
                comboBox2.DataSource = tt;
                comboBox2.DisplayMember = "bld_bld";
                comboBox2.ValueMember = "bld_id";
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    if (comboBox1.Text == "lastname")
                    {
                        sql = "DELETE FROM public.fam where fam_fam= '" + comboBox2.Text + "'";
                    }
                    if (comboBox1.Text == "firstname")
                    {
                        sql = "DELETE FROM public.name where name_name='" + comboBox2.Text + "'";
                    }
                    if (comboBox1.Text == "middlename")
                    {
                        sql = "DELETE FROM public.otc where otc_otc='" + comboBox2.Text + "'";
                    }
                    if (comboBox1.Text == "street")
                    {
                        sql = "DELETE FROM public.str where str_str='" + comboBox2.Text + "'";
                    }
                    if (comboBox1.Text == "city")
                    {
                        sql = "DELETE FROM public.city where city_city='" + comboBox2.Text + "'";
                    }
                    if (comboBox1.Text == "build")
                    {
                        sql = "DELETE FROM public.bld where bld_bld='" + comboBox2.Text + "'";
                    }
                    cmd = new NpgsqlCommand(sql, conn);

                    if (cmd.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Delete student successfully");
                    }
                    conn.Close();

                    conn.Open();
                    sql = "select * from " + comboBox1.Text;
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Deleted Error" + ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Select();
        }
    }
}