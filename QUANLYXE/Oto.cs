using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYXE
{
    internal class Oto : Xe
    {
        private int soChoNgoi;
        private bool kinhDoanhVanTai;

        public Oto() { }
        public Oto(string bienSo, string ngaySX, int soChoNgoi, bool kinhDoanhVanTai) : base(bienSo, ngaySX)
        {
            this.soChoNgoi = soChoNgoi;
            this.kinhDoanhVanTai = kinhDoanhVanTai;
        }

        public int SoChoNgoi { get => soChoNgoi; set => soChoNgoi = value; }
        public bool KinhDoanhVanTai { get => kinhDoanhVanTai; set => kinhDoanhVanTai = value; }

        //nhap
        public override void inPut()
        {
            base.inPut();
            Console.WriteLine("Nhập số lượng chỗ ngồi: ");
            soChoNgoi = int.Parse(Console.ReadLine());
            Console.WriteLine("Có đăng ký kinh doanh vận tải không? (true / false): ");
            kinhDoanhVanTai = bool.Parse(Console.ReadLine());
        }

        //xuat
        public override void outPut()
        {
            base.outPut();
            Console.Write($" Số chỗ ngồi: {this.soChoNgoi,-5} | Đăng ký kinh doanh vận tải: {this.kinhDoanhVanTai,-6} |");
        }
        
        //Ham tinh gia dang kiem
        public double tinhGiaDangKiem()
        {
            DateTime NgaySXDate = DateTime.ParseExact(NgaySX, "dd/mm/yyyy", null);
            int soNamThoiHan = DateTime.Now.Year - NgaySXDate.Year;
            double mucGiaDangKiem = 0;
            if (soChoNgoi <= 10)// cho ngoi <= 10 cho
            {
                mucGiaDangKiem = 240000;
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
            DateTime NgaySXDate = DateTime.ParseExact(NgaySX, "dd/mm/yyyy", null);
            int soNamThoiHan = DateTime.Now.Year - NgaySXDate.Year;
            int thoiHanDangKiem = 0;
            if (soNamThoiHan <= 7) //o to sx duoi 7 nam
            {
                if (soChoNgoi <= 9)
                {
                    if (kinhDoanhVanTai == true)
                    {
                        thoiHanDangKiem = 12; //1 nam
                    }
                    else
                    {
                        thoiHanDangKiem = 24; //2 nam
                    }
                }
                else
                {
                    thoiHanDangKiem = 12; //1 nam
                }
            }
            else //o to sx tren 7 nam
            {
                thoiHanDangKiem = 6; //6 thang
            }
            Console.WriteLine($" Thời gian đăng kiểm định kỳ: {thoiHanDangKiem} tháng\n");
        }

    }
}
