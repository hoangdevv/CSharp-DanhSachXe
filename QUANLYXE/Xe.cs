using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYXE
{
    internal class Xe
    {
        private string bienSo;
        private string ngaySX;

        public Xe() { }
        public Xe(string bienSo, string ngaySX)
        {
            this.bienSo = bienSo;
            this.ngaySX = ngaySX;
        }

        public string BienSo { get => bienSo; set => bienSo = value; }
        public string NgaySX { get => ngaySX; set => ngaySX = value; }

        //nhap
        public virtual void inPut()
        {
            do
            {
                Console.WriteLine("Nhập biển số xe:(ex: 79C4-66666): ");
                bienSo = Console.ReadLine();
                if (!KiemTraDinhDangBienSo(bienSo))
                {
                    Console.WriteLine("Nhập sai! Hãy nhập đúng 4 ký tự đầu là mã tỉnh và 5 kí tự sau. ");
                }
            } while (!KiemTraDinhDangBienSo(bienSo));
            Console.WriteLine("Nhập ngày sản xuất (dd/mm/yyyy): ");
            ngaySX = Console.ReadLine();
        }

        //xuat
        public virtual void outPut()
        {
            Console.Write($"| Biển số xe: {this.bienSo,-10} | Ngày sản xuất: {this.ngaySX,-10} |");
        }

        //Kiem tra dinh dang bien so xe
        private bool KiemTraDinhDangBienSo(string bienSo)
        {
            string dinhDang = @"^\d{2}[A-Z]\d{1,4}-\d{5}$";
            return System.Text.RegularExpressions.Regex.IsMatch(bienSo, dinhDang);
        }

    }
}
