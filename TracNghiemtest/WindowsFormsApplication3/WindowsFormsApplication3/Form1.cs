using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapTracNghiem
{
    public partial class Form1 : Form
    {
        private Label labelTieuDe;
        private Label labelCauHoi;
        private RadioButton[] radioButtonDapAn;

        public Form1()
        {
            InitializeComponent();

            // Khai báo biến "soCauHoi", "soLuongDapAn", "cauHoi", "dapAn", và "dapAnCuaNguoiDung"
            int soCauHoi = 0;
            int soLuongDapAn = 4;
            string cauHoi = new string[] {
                "Thủ đô của Việt Nam là gì?",
                "Diện tích của Việt Nam là bao nhiêu?",
                "Ngày quốc khánh của Việt Nam là ngày nào?"
            };
            dapAn = new string[] {
                "Hà Nội",
                "331.210 km2",
                "2 tháng 9"
            };
            dapAnCuaNguoiDung = new string[soLuongDapAn];

            // Hiển thị tiêu đề ứng dụng trên thanh tiêu đề
            Text = "Bài kiểm tra trắc nghiệm";

            // Khởi tạo các lựa chọn trả lời với vị trí và kích thước phù hợp
            for (int i = 0; i < soLuongDapAn; i++)
            {
                radioButtonDapAn[i] = new RadioButton();
                radioButtonDapAn[i].Location = new Point(100, 100 + i * 20);
                radioButtonDapAn[i].Text = cauHoi[i];
                Controls.Add(radioButtonDapAn[i]);
            }
        }

        private void buttonBatDau_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị của biến "i"
            if (i < soLuongDapAn)
            {
                // Hiển thị câu hỏi
                labelCauHoi.Text = cauHoi[i];

                // Khởi tạo lại các lựa chọn trả lời
                for (int j = 0; j < soLuongDapAn; j++)
                {
                    radioButtonDapAn[j].Checked = false;
                }

                // Chuyển sang câu hỏi tiếp theo
                i++;
            }
        }

        private void radioButtonDapAn_CheckedChanged(object sender, EventArgs e)
        {
            // Lưu trữ đáp án của người dùng
            dapAnCuaNguoiDung[i - 1] = ((RadioButton)sender).Text;
        }

        private void buttonKetQua_Click(object sender, EventArgs e)
        {
            // Kiểm tra kết quả của người dùng
            int soCauDung = 0;
            for (int i = 0; i < soLuongDapAn; i++)
            {
                if (dapAn[i] == dapAnCuaNguoiDung[i])
                {
                    soCauDung++;
                }
            }

            // Hiển thị kết quả trên màn hình
            labelKetQua.Text = "Số câu đúng: " + soCauDung;
        }
    }
}
