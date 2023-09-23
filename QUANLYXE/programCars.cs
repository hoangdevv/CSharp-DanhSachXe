using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QUANLYXE
{
    internal class programCars
    {

        public static void Main(string[] args)
        {
            List<Xe> listXe = nhapXe();
            var menu = false;
            do
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("\n\n\n---------------------------MENU----------------------------");
                Console.WriteLine("1. Thêm xe ô tô");
                Console.WriteLine("2. Thêm xe tải");
                Console.WriteLine("3. Xuất danh sách hiển thị thông tin tất cả các xe");
                Console.WriteLine("4. Tìm xe ô tô có số chỗ ngồi nhiều nhất (nếu có)");
                Console.WriteLine("5. Sắp xếp danh sách xe tải theo trọng tải tăng dần");
                Console.WriteLine("6. Xuất danh sách các biển số xe đẹp");
                Console.WriteLine("7. Tính số tiền đăng kiểm định kỳ của từng xe đến thời điểm hiện tại");
                Console.WriteLine("8. Tính thời gian đăng kiểm định kỳ của từng xe sắp tới");
                Console.WriteLine("9. Tính tổng số tiền đã đăng kiểm");
                Console.WriteLine("0. Thoat");
                Console.WriteLine("----------------------------------------------------------------\n");
                Console.WriteLine("Chọn chức năng: "); var chon = int.Parse(Console.ReadLine());
                Console.WriteLine("----------------------------------------------------------------\n");
                Console.WriteLine();
                
                switch (chon)
                {
                    case 1:
                        {
                            addcars(listXe,"oto");
                            break;
                        }
                    case 2:
                        {
                            addcars(listXe, "xetai");
                            break;
                        }
                    case 3:
                        {
                            XuatDSXe(listXe);
                            break;
                        }
                    case 4:
                        {
                            choNgoiNhieuNhat(listXe);
                            break;
                        }
                    case 5:
                        {
                            SortTrongTaiTangDan(listXe);
                            break;
                        }
                    case 6:
                        {
                            List<Xe> listXeDep = TimBienSoDepNhat(listXe);
                            foreach(var item in listXeDep)
                            {
                                Console.WriteLine();
                                item.outPut();
                            }

                            
                            break;
                        }
                    case 7:
                        {
                            soTienDangKiem(listXe);
                            break;
                        }
                    case 8:
                        {
                            thoiGianDangKiem(listXe);
                            break;
                        }
                    case 9:
                        {
                            tinhTongTienDangKiem(listXe);
                            break;
                        }
                    case 0:
                        {
                            Console.WriteLine("Thoát chương trình!");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Không có trong menu!");
                            break;
                        }

                }
            } while (!menu);
        }

        //ham nhap san
        private static List<Xe> nhapXe()
        {
            List<Xe> listXe = new List<Xe>();
            listXe.Add(new Oto("79C4-66666", "03/09/2023", 4, true));
            listXe.Add(new Oto("79C4-44444", "03/09/2022", 7, false));
            listXe.Add(new Oto("67B4-46464", "20/08/2021", 4, true));
            listXe.Add(new Oto("79C4-21245", "03/09/2020", 7, true));
            listXe.Add(new Oto("45C4-45457", "28/02/1998", 2, false));
            listXe.Add(new XeTai("79C4-66544", "03/09/1876", 10.5));
            listXe.Add(new XeTai("79C4-33333", "03/12/1876", 20.5));
            listXe.Add(new XeTai("79C4-12121", "04/07/2020", 45.5));
            listXe.Add(new XeTai("84B4-11111", "12/09/1876", 100));
            listXe.Add(new XeTai("79C4-22578", "24/02/1998", 7));
            return listXe;
        }

        //xuat
        private static void XuatDSXe(List<Xe> listXe)
        {
            foreach (Xe e in listXe)
            {
                if(e is Oto oto)
                {
                    Console.WriteLine();
                    oto.outPut();
                }

                if (e is XeTai xetai) 
                {
                    Console.WriteLine();
                    xetai.outPut();
                }
            }
        }

        //them xe
        private static void addcars(List<Xe> listXe,string loaixe)
        {
            Console.WriteLine("Nhập số lượng xe muốn thêm:");
            var n= int.Parse(Console.ReadLine());
            if(loaixe == "oto")
            {
                for (int i = 0; i < n; i++)
                {
                    Xe xe = new Oto();
                    Console.WriteLine($"Nhập xe ô tô lần thứ {i + 1} : ");
                    xe.inPut();
                    listXe.Add(xe);
                    Console.WriteLine("Thêm ô tô thành công!");

                }
            }
            else if (loaixe == "xetai")
            {
                for (int i = 0; i < n; i++)
                {
                    Xe xe = new XeTai();
                    Console.WriteLine($"Nhập xe tải lần thứ {i + 1} : ");
                    xe.inPut();
                    listXe.Add(xe);
                    Console.WriteLine("Thêm xe tải thành công!");

                }
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
        }

        //tim xe oto co cho ngoi nhieu nhat
        private static void choNgoiNhieuNhat(List<Xe> listXe)
        {
            var maxChoNgoi = listXe.OfType<Oto>().MaxBy(p => p.SoChoNgoi); //OfType : trả về 1 chuỗi chỉ chứa các phần tử có kiểu <>
            if(maxChoNgoi != null)
            {
                maxChoNgoi.outPut();
            }
            else { Console.WriteLine("Khong co xe oto nao co cho ngoi nhieu nhat!"); }
        }

        //Sap xep danh sach xe tai theo trong tai tang dan
        private static void SortTrongTaiTangDan(List<Xe> listXe)
        {
            var trongTaiTangDan = listXe.OfType<XeTai>().OrderBy(p=>p.TrongTai).ToList();
            foreach(var item in trongTaiTangDan)
            {
                Console.WriteLine();
                item.outPut();
            }
        }

        //Xuat danh sach co bien so xe dep
            private static bool DemSoGiongNhauCuoi(string bienSo)
            {
                // Any: phương thức trả về giá trị boolean (có phân tử nào thỏa mãn) 
                return bienSo.GroupBy(p=>p).Any(p=>p.Count() >= 4); //kiểm tra 4 số cuối trở lên 
            }
            private static List<Xe> TimBienSoDepNhat(List<Xe> listXe)
            {
                return listXe.Where(p=> DemSoGiongNhauCuoi(p.BienSo.Substring(p.BienSo.Length - 5))).ToList(); //Substring : được dùng để trích xuất 1 phần của chuỗi Substring(starIndex, length)
            }

        //Tính số tiền đăng kiểm định kỳ của từng xe đến thời điểm hiện tại
        private static void soTienDangKiem(List<Xe> listxe)
        {
            foreach(Xe xe in listxe)
            {
                if(xe is Oto oto)
                {
                    Console.WriteLine();
                    xe.outPut();
                    oto.tinhGiaDangKiem();
                }
                if (xe is XeTai xetai)
                {
                    Console.WriteLine();
                    xe.outPut();
                    xetai.tinhGiaDangKiem();
                }
            }
        }

        //Tính thời gian đăng kiểm định kỳ của từng xe sắp tới
        private static void thoiGianDangKiem(List<Xe> listxe)
        {
            foreach (Xe xe in listxe)
            {
                if (xe is Oto oto)
                {
                    xe.outPut();
                    oto.tinhTimeDangKiem();
                }
                if (xe is XeTai xetai)
                {
                    xe.outPut();
                    xetai.tinhTimeDangKiem();
                }
            }
        }

        //Tính tổng số tiền đã đăng kiểm
        private static double tinhTongTienDangKiem(List<Xe> listxe)
        {
            double tongTienOTo = 0; double tongTienXeTai = 0;
            double tongTien = 0;
            foreach (Xe xe in listxe)
            {
                if (xe is Oto oto)
                {
                    tongTienOTo = tongTienOTo + oto.tinhGiaDangKiem();
                }
                if (xe is XeTai xetai)
                {
                    tongTienXeTai = tongTienXeTai + xetai.tinhGiaDangKiem();
                }
            }
            Console.WriteLine($"Tổng tiền đăng kiểm của các xe ô tô: {tongTienOTo}");
            Console.WriteLine();
            Console.WriteLine($"Tổng tiền đăng kiểm của các xe tải: {tongTienXeTai}");
            Console.WriteLine();
            tongTien = tongTienOTo + tongTienXeTai;
            Console.WriteLine($"Tổng tiền đăng kiểm của các xe: {tongTien}");
            return tongTien;

        }



    }
}
