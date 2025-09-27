using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class Program
    {
        // Hàm kiểm tra ngày tháng năm nhập vào có hợp lệ hay không
        static bool KiemTraNgayThangNamHople(byte Ngay, byte Thang, short Nam)
        {
            if (Nam <= 0) return false;
            if (Thang < 1 || Thang > 12) return false;

            int SoNgayTrongThang;

            switch (Thang)
            {
                case 2:
                    // Kiểm tra năm nhuận
                    bool NamNhuan = (Nam % 4 == 0 && Nam % 100 != 0) || (Nam % 400 == 0);
                    SoNgayTrongThang = NamNhuan ? 29 : 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    SoNgayTrongThang = 30;
                    break;
                default:
                    SoNgayTrongThang = 31;
                    break;
            }
            return Ngay >= 1 && Ngay <= SoNgayTrongThang;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;     // Để in chữ Tiếng Việt không bị lỗi
            byte Ngay, Thang;
            short Nam;
            do
            {
                Console.Write("Nhập ngày: ");
                Ngay = byte.Parse(Console.ReadLine());
                if (Ngay <= 0 || Ngay > 31)
                    Console.WriteLine("Ngày phải nằm trong khoảng từ 1 đến 31. Vui lòng nhập lại.");
            }
            while (Ngay <= 0 || Ngay > 31);

            do
            {
                Console.Write("Nhập tháng: ");
                Thang = byte.Parse(Console.ReadLine());
                if (Thang <= 0 || Thang > 12)
                    Console.WriteLine("Tháng phải nằm trong khoảng từ 1 đến 12. Vui lòng nhập lại.");
            }
            while (Thang <= 0 || Thang > 12);

            do
            {
                Console.Write("Nhập năm: ");
                Nam = short.Parse(Console.ReadLine());
                if (Nam <= 0)
                    Console.WriteLine("Năm phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (Nam <= 0);

            if (KiemTraNgayThangNamHople(Ngay, Thang, Nam))
                Console.Write("Hợp lệ!");
            else
                Console.Write("Không hợp lệ");
        }
    }
}
