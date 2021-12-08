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
    public partial class FormSelect : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
                                        "User Id = {2};Password={3};Database={4}",
                                        "localhost", 5432, "postgres", "936X730Az", "Practica2");

        private NpgsqlConnection conn;

        private string sql;
        private NpgsqlCommand cmd;
        private DataTable dt;
        public FormSelect()
        {
            InitializeComponent();
        }

        private void FormSelect_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
            Select();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
