using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    internal class Program
    {
        // Hàm tìm số ngày trong tháng
        static byte TimSoNgayTrongThang(int Thang, int Nam)
        {
            if (Nam <= 0) return 0;
            if (Thang < 1 || Thang > 12) return 0;

            byte SoNgayTrongThang;

            switch (Thang)
            {
                case 2:
                    // Kiểm tra năm nhuận
                    {
                        if ((Nam % 4 == 0 && Nam % 100 != 0) || (Nam % 400 == 0))
                            SoNgayTrongThang = 29;
                        else
                            SoNgayTrongThang = 28;
                        break;
                    }
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
            return SoNgayTrongThang;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;     // Để in chữ Tiếng Việt không bị lỗi
            int Thang, Nam;
            do
            {
                Console.Write("Nhập tháng: ");
                Thang = int.Parse(Console.ReadLine());
                if (Thang <= 0 || Thang > 12)
                    Console.WriteLine("Tháng phải nằm trong khoảng từ 1 đến 12. Vui lòng nhập lại.");
            }
            while (Thang <= 0 || Thang > 12);

            do
            {
                Console.Write("Nhập năm: ");
                Nam = int.Parse(Console.ReadLine());
                if (Nam <= 0)
                    Console.WriteLine("Năm phải lớn hơn 0. Vui lòng nhập lại.");
            }
            while (Nam <= 0);

            Console.WriteLine($"Số ngày trong tháng {Thang}/{Nam} là: {TimSoNgayTrongThang(Thang, Nam)}");
        }
    }
}
