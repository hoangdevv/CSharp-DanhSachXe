using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYXE
{
    internal class XeTai : Xe
    {
        private double trongTai;

        public XeTai() { }

        public XeTai(string bienSo, string ngaySX,double trongTai) : base(bienSo,ngaySX)
        {
            this.trongTai = trongTai;
        }

        public double TrongTai { get => trongTai; set => trongTai = value; }

        //nhap
        public override void inPut()
        {
            base.inPut();
            Console.WriteLine("Nhập trọng tải xe: ");
            trongTai = double.Parse(Console.ReadLine());
        }

        //xuat
        public override void outPut()
        {
            base.outPut();
            Console.Write($" Trọng tải xe: {this.trongTai,-5}tấn |");
        }


        //Ham tinh gia dang kiem
        public double tinhGiaDangKiem()
        {
            int soNamThoiHan = DateTime.Now.Year - DateTime.ParseExact(NgaySX, "dd/mm/yyyy", null).Year; //ParseExact:chuyển đổi từ 1 chuỗi thành đối tượng DateTime
            double mucGiaDangKiem = 0;
            if (trongTai > 20) // trong tai > 20 tan
            {
                mucGiaDangKiem = 560000;
            }
            else if (trongTai > 7 && trongTai <= 20)
            {
                mucGiaDangKiem = 350000;
            }
            else
            {
                mucGiaDangKiem = 320000;
            }
            //Console.WriteLine($"So tien dang kiem dinh ky: {mucGiaDangKiem} VND\n");
            return mucGiaDangKiem;
        }

        //Ham tinh thoi gian dang kiem dinh ky
        public void tinhTimeDangKiem()
        {
            int soNamThoiHan = DateTime.Now.Year - DateTime.ParseExact(NgaySX, "dd/mm/yyyy", null).Year; //ParseExact:chuyển đổi từ 1 chuỗi thành đối tượng DateTime
            int thoiHanDangKiem = 0;
            if (soNamThoiHan <= 20) //san xuat <= 20 nam
            {
                thoiHanDangKiem = 6; //6 thang
            }
            else
            {
                thoiHanDangKiem = 3; // 3 thang
            }
            Console.WriteLine($" Thời gian đăng kiểm định kỳ: {thoiHanDangKiem} tháng\n");
        }
    }
}
