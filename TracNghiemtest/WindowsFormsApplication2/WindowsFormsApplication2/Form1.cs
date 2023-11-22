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

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataTable dt;
        private int? currentQuestionIndex = null;
        private bool isFinished = false;
        private int score = 0;

        public Form1()
        {
            InitializeComponent();

            // Connect to the database
            string connectionString = "Data Source=.\\A209PC27;Initial Catalog=QuizDB;Integrated Security=True";
            conn = new SqlConnection(connectionString);

            // Load questions from the database
            string sql = "SELECT * FROM Bang";
            da = new SqlDataAdapter(sql, conn);
            dt = new DataTable();
            da.Fill(dt);

            // Display the first question
            NextQuestion();
        }

        private void NextQuestion()
        {
            if (currentQuestionIndex == null || currentQuestionIndex >= dt.Rows.Count)
            {
                isFinished = true;
            }
            else
            {
                DataRow row = currentQuestionIndex1;
                txtCH.Text = row["CauHoi"].ToString();
                radioButton1.Text = row["DapAn1"].ToString();
                radioButton2.Text = row["DapAn2"].ToString();
                radioButton3.Text = row["DapAn3"].ToString();
                radioButton4.Text = row["DapAn4"].ToString();
                lblQuestionNumber.Text = (currentQuestionIndex + 1) + " of " + dt.Rows.Count;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!isFinished)
            {
                string selectedAnswer = GetSelectedAnswer();
                string correctAnswer = dt.Rows[currentQuestionIndex]["DapAnDung"].ToString();

                if (selectedAnswer == correctAnswer)
                {
                    score++;
                    lblStatus.Text = "Correct!";
                }
                else
                {
                    lblStatus.Text = "Incorrect. The correct answer is " + correctAnswer;
                }

                currentQuestionIndex++;
                NextQuestion();
            }
        }

        private string GetSelectedAnswer()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                return radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                return radioButton3.Text;
            }
            else
            {
                return radioButton4.Text;
            }
        }
    }
