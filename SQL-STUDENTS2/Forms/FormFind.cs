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
    public partial class FormFind : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
                   "User Id = {2};Password={3};Database={4}",
                   "localhost", 5432, "postgres", "936X730Az", "Practica2");

        private NpgsqlConnection conn;

        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        public FormFind()
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

        private void FormFind_Load(object sender, EventArgs e)
        {
            Init();
            LoadTheme();
            conn = new NpgsqlConnection(connstring);
            comboBox6.Enabled = comboBox3.Enabled = comboBox4.Enabled = textBox3.Enabled = false;
            radioButton3.Checked = true;
        }

        private void buttonFind_Click(object sender, EventArgs e)
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
						where fam_fam like '%" + textBox1.Text + @"' or name_name like '%" + textBox1.Text + @"' or otc_otc like '%" + textBox1.Text + @"'
                        or city_city like '%" + textBox1.Text + @"' or str_str like '%" + textBox1.Text + @"' or bld_bld like '%" + textBox1.Text + @"'
                        or m_nm like '%" + textBox1.Text + @"' or m_tel like '%" + textBox1.Text + "'" +
                        "order by m_id";

                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@text", textBox1.Text);

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show("Finding Error" + ex.Message);
            }
        }

        List<string> list = new List<string>() { "lastname", "firstname", "middlename", "city", "street", "build", "number", "telephone"};
        List<string> list0 = new List<string>() { "lastname", "firstname", "middlename", "city", "street", "build", "number", "telephone" };
        List<string> oper = new List<string>() { "=", "!=", ">=", "<=" };
        List<string> oper0 = new List<string>() { "=", "!=", ">=", "<=" };

        public void Init()
        {
            comboBox1.DataSource = list;
            comboBox3.DataSource = list0;
            comboBox5.DataSource = oper;
            comboBox6.DataSource = oper0;
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
            {
                
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            comboBox6.Enabled = comboBox3.Enabled = comboBox4.Enabled = textBox3.Enabled = true;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            comboBox6.Enabled = comboBox3.Enabled = comboBox4.Enabled = textBox3.Enabled = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            comboBox6.Enabled = comboBox3.Enabled = comboBox4.Enabled = textBox3.Enabled = false;
        }

        private string comb;
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
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
                conn.Open();
                DataTable kt = new DataTable();
                NpgsqlDataAdapter adap0 = new NpgsqlDataAdapter("select fam_id, fam_fam from fam", conn);
                adap0.Fill(kt);
                comboBox2.DataSource = kt;
                comb = comboBox2.DisplayMember = "fam_fam";
                comboBox2.ValueMember = "fam_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 1)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter adap = new NpgsqlDataAdapter("select name_id, name_name from name", conn);
                adap.Fill(dt);
                comboBox2.DataSource = dt;
                comb = comboBox2.DisplayMember = "name_name";
                comboBox2.ValueMember = "name_id";
                conn.Close();

            }

            if (comboBox1.SelectedIndex == 2)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
                conn.Open();
                DataTable bt = new DataTable();
                NpgsqlDataAdapter adap2 = new NpgsqlDataAdapter("select otc_id, otc_otc from otc", conn);
                adap2.Fill(bt);
                comboBox2.DataSource = bt;
                comb = comboBox2.DisplayMember = "otc_otc";
                comboBox2.ValueMember = "otc_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 3)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
                conn.Open();
                DataTable ft = new DataTable();
                NpgsqlDataAdapter adap3 = new NpgsqlDataAdapter("select city_id, city_city from city", conn);
                adap3.Fill(ft);
                comboBox2.DataSource = ft;
                comb = comboBox2.DisplayMember = "city_city";
                comboBox2.ValueMember = "city_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 4)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
                conn.Open();
                DataTable at = new DataTable();
                NpgsqlDataAdapter adap4 = new NpgsqlDataAdapter("select str_id, str_str from str", conn);
                adap4.Fill(at);
                comboBox2.DataSource = at;
                comb = comboBox2.DisplayMember = "str_str";
                comboBox2.ValueMember = "str_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 5)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = true;
                textBox2.Enabled = false;
                conn.Open();
                DataTable tt = new DataTable();
                NpgsqlDataAdapter adap5 = new NpgsqlDataAdapter("select bld_id, bld_bld from bld", conn);
                adap5.Fill(tt);
                comboBox2.DataSource = tt;
                comb = comboBox2.DisplayMember = "bld_bld";
                comboBox2.ValueMember = "bld_id";
                conn.Close();
            }

            if (comboBox1.SelectedIndex == 6)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = false;
                textBox2.Enabled = true;
                comb = "m_nm";
            }

            if (comboBox1.SelectedIndex == 7)
            {
                comboBox2.DataSource = null;
                comboBox2.Enabled = false;
                textBox2.Enabled = true;
                comb = "m_tel";
            }
        }

        private string comb0;
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            if (comboBox3.SelectedIndex == -1)
            {
                comboBox4.DataSource = null;
            }
            if (comboBox3.SelectedIndex == 0)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = true;
                textBox3.Enabled = false;
                conn.Open();
                DataTable kt = new DataTable();
                NpgsqlDataAdapter adap0 = new NpgsqlDataAdapter("select fam_id, fam_fam from fam", conn);
                adap0.Fill(kt);
                comboBox4.DataSource = kt;
                comb0 = comboBox4.DisplayMember = "fam_fam";
                comboBox4.ValueMember = "fam_id";
                conn.Close();
            }

            if (comboBox3.SelectedIndex == 1)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = true;
                textBox3.Enabled = false;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter adap = new NpgsqlDataAdapter("select name_id, name_name from name", conn);
                adap.Fill(dt);
                comboBox4.DataSource = dt;
                comb0 = comboBox4.DisplayMember = "name_name";
                comboBox4.ValueMember = "name_id";
                conn.Close();

            }

            if (comboBox3.SelectedIndex == 2)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = true;
                textBox3.Enabled = false;
                conn.Open();
                DataTable bt = new DataTable();
                NpgsqlDataAdapter adap2 = new NpgsqlDataAdapter("select otc_id, otc_otc from otc", conn);
                adap2.Fill(bt);
                comboBox4.DataSource = bt;
                comb0 = comboBox4.DisplayMember = "otc_otc";
                comboBox4.ValueMember = "otc_id";
                conn.Close();
            }

            if (comboBox3.SelectedIndex == 3)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = true;
                textBox3.Enabled = false;
                conn.Open();
                DataTable ft = new DataTable();
                NpgsqlDataAdapter adap3 = new NpgsqlDataAdapter("select city_id, city_city from city", conn);
                adap3.Fill(ft);
                comboBox4.DataSource = ft;
                comb0 = comboBox4.DisplayMember = "city_city";
                comboBox4.ValueMember = "city_id";
                conn.Close();
            }

            if (comboBox3.SelectedIndex == 4)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = true;
                textBox3.Enabled = false;
                conn.Open();
                DataTable at = new DataTable();
                NpgsqlDataAdapter adap4 = new NpgsqlDataAdapter("select str_id, str_str from str", conn);
                adap4.Fill(at);
                comboBox4.DataSource = at;
                comb0 = comboBox4.DisplayMember = "str_str";
                comboBox4.ValueMember = "str_id";
                conn.Close();
            }

            if (comboBox3.SelectedIndex == 5)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = true;
                textBox3.Enabled = false;
                conn.Open();
                DataTable tt = new DataTable();
                NpgsqlDataAdapter adap5 = new NpgsqlDataAdapter("select bld_id, bld_bld from bld", conn);
                adap5.Fill(tt);
                comboBox4.DataSource = tt;
                comb0 = comboBox4.DisplayMember = "bld_bld";
                comboBox4.ValueMember = "bld_id";
                conn.Close();
            }

            if (comboBox3.SelectedIndex == 6)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = false;
                textBox3.Enabled = true;
                comb0 = "m_nm";
            }

            if (comboBox3.SelectedIndex == 7)
            {
                comboBox4.DataSource = null;
                comboBox4.Enabled = false;
                textBox3.Enabled = true;
                comb0 = "m_tel";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (radioButton1.Enabled == true)
                {
                    if (comboBox2.Enabled == true && textBox2.Enabled == false)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + comboBox2.Text + @"'";
                    }
                    else if (comboBox2.Enabled == false && textBox2.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + textBox2.Text + @"'";
                    }
                }

                if (radioButton1.Checked == true)
                {
                    if (comboBox2.Enabled == true && comboBox4.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + comboBox2.Text + @"' OR " + comb0 + comboBox6.Text + @"'" + comboBox4.Text + @"'";
                    }
                    else if(comboBox2.Enabled == true && textBox3.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + comboBox2.Text + @"' OR " + comb0 + comboBox6.Text + @"'" + textBox3.Text + @"'";
                    }
                    else if (textBox2.Enabled == true && comboBox4.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + textBox2.Text + @"' OR " + comb0 + comboBox6.Text + @"'" + comboBox4.Text + @"'";
                    }
                    else if (textBox2.Enabled == true && textBox3.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + textBox2.Text + @"' OR " + comb0 + comboBox6.Text + @"'" + textBox3.Text + @"'";
                    }
                }

                if (radioButton2.Checked == true)
                {
                    if (comboBox2.Enabled == true && comboBox4.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + comboBox2.Text + @"' AND " + comb0 + comboBox6.Text + @"'" + comboBox4.Text + @"'";
                    }
                    else if (comboBox2.Enabled == true && textBox3.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + comboBox2.Text + @"' AND " + comb0 + comboBox6.Text + @"'" + textBox3.Text + @"'";
                    }
                    else if (textBox2.Enabled == true && comboBox4.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + textBox2.Text + @"' AND " + comb0 + comboBox6.Text + @"'" + comboBox4.Text + @"'";
                    }
                    else if (textBox2.Enabled == true && textBox3.Enabled == true)
                    {
                        sql = @"select m_id as id, fam_fam as lastname, name_name as firstname, otc_otc as middlename,
                        city_city as city, str_str as street, bld_bld as build, m_nm as number, m_tel as telephone from main
                        join fam on m_fam = fam_id
                        join name on m_name = name_id
                        join otc on m_otc = otc_id
                        join city on m_city = city_id
                        join str on m_str = str_id
                        join bld on m_bld = bld_id
						where " + comb + comboBox5.Text + @"'" + textBox2.Text + @"' AND " + comb0 + comboBox6.Text + @"'" + textBox3.Text + @"'";
                    }
                }

                cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@text", textBox1.Text);

                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Finding Error" + ex.Message);
            }

        }
    }
}