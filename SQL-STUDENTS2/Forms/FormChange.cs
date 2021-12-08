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
    public partial class FormChange : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
                   "User Id = {2};Password={3};Database={4}",
                   "localhost", 5432, "postgres", "936X730Az", "Practica2");

        private NpgsqlConnection conn;

        private string sql;
        private string sql2;
        private NpgsqlCommand cmd;
        private DataTable dt;
        private int RowIndex;
        public FormChange()
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
        private void fillcombo()
        {
            conn.Open();
            DataTable kt = new DataTable();
            NpgsqlDataAdapter adap0 = new NpgsqlDataAdapter("select fam_id, fam_fam from fam", conn);
            adap0.Fill(kt);
            comboBox1.DataSource = kt;
            comboBox1.DisplayMember = "fam_fam";
            comboBox1.ValueMember = "fam_id";
            conn.Close();

            conn.Open();
            DataTable dt = new DataTable();
            NpgsqlDataAdapter adap = new NpgsqlDataAdapter("select name_id, name_name from name", conn);
            adap.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "name_name";
            comboBox2.ValueMember = "name_id";
            conn.Close();

            conn.Open();
            DataTable bt = new DataTable();
            NpgsqlDataAdapter adap2 = new NpgsqlDataAdapter("select otc_id, otc_otc from otc", conn);
            adap2.Fill(bt);
            comboBox3.DataSource = bt;
            comboBox3.DisplayMember = "otc_otc";
            comboBox3.ValueMember = "otc_id";
            conn.Close();

            conn.Open();
            DataTable ft = new DataTable();
            NpgsqlDataAdapter adap3 = new NpgsqlDataAdapter("select city_id, city_city from city", conn);
            adap3.Fill(ft);
            comboBox4.DataSource = ft;
            comboBox4.DisplayMember = "city_city";
            comboBox4.ValueMember = "city_id";
            conn.Close();

            conn.Open();
            DataTable at = new DataTable();
            NpgsqlDataAdapter adap4 = new NpgsqlDataAdapter("select str_id, str_str from str", conn);
            adap4.Fill(at);
            comboBox5.DataSource = at;
            comboBox5.DisplayMember = "str_str";
            comboBox5.ValueMember = "str_id";
            conn.Close();

            conn.Open();
            DataTable tt = new DataTable();
            NpgsqlDataAdapter adap5 = new NpgsqlDataAdapter("select bld_id, bld_bld from bld", conn);
            adap5.Fill(tt);
            comboBox6.DataSource = tt;
            comboBox6.DisplayMember = "bld_bld";
            comboBox6.ValueMember = "bld_id";
            conn.Close();
        }

        private void freecombo()
        {
            comboBox1.DataSource = null;
            comboBox2.DataSource = null;
            comboBox3.DataSource = null;
            comboBox4.DataSource = null;
            comboBox5.DataSource = null;
            comboBox6.DataSource = null;
        }

        private void FormChange_Load(object sender, EventArgs e)
        {
            LoadTheme();
            conn = new NpgsqlConnection(connstring);
            Select();
            fillcombo();
            comboBox1.SelectedIndex = comboBox2.SelectedIndex = comboBox3.SelectedIndex = comboBox4.SelectedIndex
            = comboBox5.SelectedIndex = comboBox6.SelectedIndex = -1;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    RowIndex = dataGridView1.CurrentCell.RowIndex;
                    conn.Open();
                    sql = @"select * from combo_insert(@fam_fam, @name_name, @otc_otc, @city_city, @str_str, @bld_bld)";

                    cmd = new NpgsqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@fam_fam", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@name_name", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@otc_otc", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@city_city", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@str_str", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@bld_bld", comboBox6.Text);
                    cmd.Parameters.AddWithValue("@m_tel", textBox1.Text);
                    cmd.Parameters.AddWithValue("@m_nm", textBox2.Text);

                    if (cmd.ExecuteScalar() == null)
                    {
                        //MessageBox.Show("Inserted fail");
                    }
                    else
                    {
                        //MessageBox.Show("Inserted succesfully");
                    }

                    conn.Close();

                    conn.Open();
                    sql2 = @"select * from update_table(@fam_fam,@name_name,@otc_otc,@city_city,@str_str,
                        @bld_bld,@m_nm,@m_tel,@u_id)";

                    cmd = new NpgsqlCommand(sql2, conn);

                    cmd.Parameters.AddWithValue("@u_id", Convert.ToInt32(dataGridView1.Rows[RowIndex].Cells["id"].FormattedValue.ToString()));
                    cmd.Parameters.AddWithValue("@fam_fam", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@name_name", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@otc_otc", comboBox3.Text);
                    cmd.Parameters.AddWithValue("@city_city", comboBox4.Text);
                    cmd.Parameters.AddWithValue("@str_str", comboBox5.Text);
                    cmd.Parameters.AddWithValue("@bld_bld", comboBox6.Text);
                    cmd.Parameters.AddWithValue("@m_tel", textBox1.Text);
                    cmd.Parameters.AddWithValue("@m_nm", int.Parse(textBox2.Text.ToString()));

                    if (cmd.ExecuteScalar() == null)
                    {
                        MessageBox.Show("Change fail");
                    }
                    else
                    {
                        MessageBox.Show("Change succesfully");
                    }

                    conn.Close();
                    Select();
                    freecombo();
                    fillcombo();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("Change Error" + ex.Message);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                RowIndex = e.RowIndex;
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["middlename"].Value.ToString();
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["city"].Value.ToString();
                comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["street"].Value.ToString();
                comboBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["build"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["telephone"].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["number"].Value.ToString();
            }
        }
    }
}
