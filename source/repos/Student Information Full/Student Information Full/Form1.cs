using System.Data;
using System.Data.SqlClient;
namespace Student_Information_Full
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=BEST-KOMP\SQLEXPRESS03;Initial Catalog=master;Integrated Security=True");
        public int StudentID;
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_insertion VALUES(@Id,@Name,@FName,@Age,@Gender,@Address)",con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id",textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@FName", textBox3.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox6.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Student is seccsfully saved","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                GetStudentsRecord();

                Reset();
            }
        }

        private bool IsValid()
        {
            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Student Name is required","Failed",MessageBoxButtons.OK,MessageBoxIcon.Error);

                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentsRecord();
        }

        private void GetStudentsRecord()
        { 
            SqlCommand cmd = new SqlCommand("Select*from tbl_insertion", con);
            DataTable dt = new DataTable();

            con.Open();

            SqlDataReader sdr = cmd.ExecuteReader(); 
            dt.Load(sdr);
            con.Close();

            dataGridView1.DataSource= dt;   

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE  tbl_insertion SET Id=@Id,Name=@Name,FName=@FName,Age=@Age,Gender=@Gender,Address=@Address", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@FName", textBox3.Text);
                cmd.Parameters.AddWithValue("@Age", textBox4.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox6.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("New Student is seccsfully update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetStudentsRecord();

                Reset();
            }
            else
            {
                MessageBox.Show("Please select his information", "Select?", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}