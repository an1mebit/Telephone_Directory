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
    public partial class FormCombo : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
                        "User Id = {2};Password={3};Database={4}",
                        "localhost", 5432, "postgres", "936X730Az", "Practica2");

        private NpgsqlConnection conn;

        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        public FormCombo()
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

        private void FormCombo_Load(object sender, EventArgs e)
        {
            LoadTheme();
            Init();
            conn = new NpgsqlConnection(connstring);
            Select();
        }


        List<string> list = new List<string>() { "lastname", "firstname", "middlename", "city", "street", "build" };
        List<string> oper = new List<string>() { "INSERT", "UPDATE", "DELETE" };

        public void Init()
        {
            comboBox1.DataSource = list;
            comboBox2.DataSource = oper;
        }

        private string comb;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox3.DataSource = null;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                comboBox3.DataSource = null;
                conn.Open();
                DataTable kt = new DataTable();
                NpgsqlDataAdapter adap0 = new NpgsqlDataAdapter("select fam_id, fam_fam from fam", conn);
                adap0.Fill(kt);
                comboBox3.DataSource = kt;
                comb = comboBox3.DisplayMember = "fam_fam";
                comboBox3.ValueMember = "fam_id";
                conn.Close();

                conn.Open();
                sql = "select * from fam";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 1)
            {
                comboBox3.DataSource = null;
                conn.Open();
                DataTable dt = new DataTable();
                NpgsqlDataAdapter adap = new NpgsqlDataAdapter("select name_id, name_name from name", conn);
                adap.Fill(dt);
                comboBox3.DataSource = dt;
                comb = comboBox3.DisplayMember = "name_name";
                comboBox3.ValueMember = "name_id";
                conn.Close();

                conn.Open();
                sql = "select * from name";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;

            }

            if (comboBox1.SelectedIndex == 2)
            {
                comboBox3.DataSource = null;
                conn.Open();
                DataTable bt = new DataTable();
                NpgsqlDataAdapter adap2 = new NpgsqlDataAdapter("select otc_id, otc_otc from otc", conn);
                adap2.Fill(bt);
                comboBox3.DataSource = bt;
                comb = comboBox3.DisplayMember = "otc_otc";
                comboBox3.ValueMember = "otc_id";
                conn.Close();

                conn.Open();
                sql = "select * from otc";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 3)
            {
                comboBox3.DataSource = null;
                conn.Open();
                DataTable ft = new DataTable();
                NpgsqlDataAdapter adap3 = new NpgsqlDataAdapter("select city_id, city_city from city", conn);
                adap3.Fill(ft);
                comboBox3.DataSource = ft;
                comb = comboBox3.DisplayMember = "city_city";
                comboBox3.ValueMember = "city_id";
                conn.Close();

                conn.Open();
                sql = "select * from city";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 4)
            {
                comboBox3.DataSource = null;
                conn.Open();
                DataTable at = new DataTable();
                NpgsqlDataAdapter adap4 = new NpgsqlDataAdapter("select str_id, str_str from str", conn);
                adap4.Fill(at);
                comboBox3.DataSource = at;
                comb = comboBox3.DisplayMember = "str_str";
                comboBox3.ValueMember = "str_id";
                conn.Close();

                conn.Open();
                sql = "select * from str";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }

            if (comboBox1.SelectedIndex == 5)
            {
                comboBox3.DataSource = null;
                conn.Open();
                DataTable tt = new DataTable();
                NpgsqlDataAdapter adap5 = new NpgsqlDataAdapter("select bld_id, bld_bld from bld", conn);
                adap5.Fill(tt);
                comboBox3.DataSource = tt;
                comb = comboBox3.DisplayMember = "bld_bld";
                comboBox3.ValueMember = "bld_id";
                conn.Close();

                conn.Open();
                sql = "select * from bld";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                conn.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                if (comboBox2.SelectedIndex == 0)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        sql = "insert into fam(fam_fam) values('" + textBox1.Text + "')";
                    }
                    else if(comboBox1.SelectedIndex == 1)
                    {
                        sql = "insert into name(name_name) values('" + textBox1.Text + "')";
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        sql = "insert into otc(otc_otc) values('" + textBox1.Text + "')";
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        sql = "insert into city(city_city) values('" + textBox1.Text + "')";
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        sql = "insert into str(str_str) values('" + textBox1.Text + "')";
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        sql = "insert into bld(bld_bld) values('" + textBox1.Text + "')";
                    }
                }
                else if(comboBox2.SelectedIndex == 1)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        sql = "update fam set fam_fam='" + textBox1.Text +"' where fam_fam = '" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        sql = "update name set name_name='" + textBox1.Text + "' where name_name = '" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        sql = "update otc set otc_otc='" + textBox1.Text + "' where otc_otc = '" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        sql = "update city set city_city='" + textBox1.Text + "' where city_city = '" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        sql = "update str set str_str='" + textBox1.Text + "' where str_str = '" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        sql = "update bld set bld_bld='" + textBox1.Text + "' where bld_bld = '" + comboBox3.Text + "'";
                    }

                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    if (comboBox1.SelectedIndex == 0)
                    {
                        sql = "delete from fam where fam_fam='" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 1)
                    {
                        sql = "delete from name where name_name='" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 2)
                    {
                        sql = "delete from otc where otc_otc='" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 3)
                    {
                        sql = "delete from city where city_city='" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 4)
                    {
                        sql = "delete from str where str_str='" + comboBox3.Text + "'";
                    }
                    else if (comboBox1.SelectedIndex == 5)
                    {
                        sql = "delete from bld where bld_bld='" + comboBox3.Text + "'";
                    }
                }

                cmd = new NpgsqlCommand(sql, conn);
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("success");
                }
                conn.Close();

                if (comboBox1.SelectedIndex == 0)
                {
                    conn.Open();
                    sql = "select * from fam group by fam_id";
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                else if(comboBox1.SelectedIndex == 1)
                {
                    conn.Open();
                    sql = "select * from name group by name_id";
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    conn.Open();
                    sql = "select * from otc group by otc_id";
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    conn.Open();
                    sql = "select * from city group by city_id";
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedIndex == 4)
                {
                    conn.Open();
                    sql = "select * from str group by str_id";
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.SelectedIndex == 5)
                {
                    conn.Open();
                    sql = "select * from bld group by bld_id";
                    cmd = new NpgsqlCommand(sql, conn);
                    dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                comboBox3.Enabled = false;
                textBox1.Enabled = true;
            }

            if (comboBox2.SelectedIndex == 1)
            {
                comboBox3.Enabled = true;
                textBox1.Enabled = true;
            }

            if (comboBox2.SelectedIndex == 2)
            {
                comboBox3.Enabled = true;
                textBox1.Enabled = false;
            }
        }
    }
}
