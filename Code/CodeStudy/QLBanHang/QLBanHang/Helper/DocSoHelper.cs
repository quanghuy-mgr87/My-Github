using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Helper
{
    internal class DocSoHelper
    {
        //Khởi tạo Hashtable chứa các key và value dùng để đọc từng con số
        int[] kyso = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        string[] kytu1 = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        string[] kytu2 = { "", "mốt", "hai", "ba", "bốn", "lăm", "sáu", "bảy", "tám", "chín" };

        public Dictionary<int, string> h1 = new Dictionary<int, string>();
        public Dictionary<int, string> hdv = new Dictionary<int, string>();

        public DocSoHelper()
        {
             KhoiTao_h1_hdv();
            KhoiTao_hlop();
        }

        public void KhoiTao_h1_hdv()
        {
            for (int i = 0; i <= 9; i++)
            {
                h1.Add(kyso[i], kytu1[i]);
                hdv.Add(kyso[i], kytu2[i]);
            }
        }

        //Kiểm tra hai số liên tiếp có bằng 0 hay không
        private int Ktrazero(Nhom3So nhom)
        {
            if (nhom.ht == nhom.hc && nhom.ht == 0 && nhom.hd != 0)
                return 0;
            if (nhom.hc == nhom.hd && nhom.hc == 0 && nhom.ht != 0)
                return 1;
            if (nhom.ht == nhom.hc && nhom.hc == nhom.hd && nhom.ht == 0)
                return 2;
            else return 3;
        }

        //Đọc hàng đơn vị
        private string Docdv(Nhom3So nhom)
        {
            if (nhom.hc != 0)
                return hdv[nhom.hd].ToString();
            else
                return h1[nhom.hd].ToString();
        }

        private string Doc1so(int so)
        {
            return h1[so].ToString();
        }

        private string Doc3so(Nhom3So nhom, bool lopdautien, bool lopdonvi) //Kiểm tra xem lớp đang đọc có phải lớp bên trái cùng
        {
            BaSo0 = false;
            if (Ktrazero(nhom) == 0)
                if (lopdautien)
                    return Docdv(nhom);
                else
                    return "không trăm linh " + Docdv(nhom);
            else
                if (Ktrazero(nhom) == 1)
                return Doc1so(nhom.ht) + " trăm";
            else
                    if (Ktrazero(nhom) == 2)
            {
                BaSo0 = true;
                return "";
            }
            else
                        if (nhom.ht == 0)
            {
                if (lopdautien)
                {
                    if (nhom.hc == 1)
                        if (nhom.hd != 1)
                            return " mười " + Docdv(nhom);
                        else
                            return " mười một ";
                    else
                        if (nhom.hc == 0)
                        return " linh " + Docdv(nhom);
                    else
                        return Doc1so(nhom.hc) + " mươi " + Docdv(nhom);
                }
                else
                {
                    if (nhom.hc == 1)
                        if (nhom.hd != 1)
                            return " mười " + Docdv(nhom);
                        else
                            if (!lopdonvi)
                            return " không trăm mười một";
                        else
                            return "mười một";
                    else
                        if (nhom.hc == 0)
                        return " không trăm linh " + Docdv(nhom);
                    else
                        return " không trăm " + Doc1so(nhom.hc) + " mươi " + Docdv(nhom);
                }
            }
            else
                            if (nhom.hc == 0)
                return Doc1so(nhom.ht) + " trăm linh " + Docdv(nhom);
            else
                                if (nhom.hc == 1)
                return Doc1so(nhom.ht) + " trăm mười một";
            else
                return Doc1so(nhom.ht) + " trăm " + Doc1so(nhom.hc) + " mươi " + Docdv(nhom);


        }

        Nhom3So[] nhomso = new Nhom3So[0];

        //Đếm số nhóm của số cần đọc và TRỪ ĐI 1
        private int DemSoNhom(string so)
        {
            if (so.Length % 3 == 0)
                return so.Length / 3 - 1;
            else
                return so.Length / 3;
        }

        //Đảo nhóm 3 chữ số
        //private string DaoNhom(string nhom)
        //{
        //    string kq = "";
        //    for (int i = nhom.Length - 1; i >= 0; i--)
        //        kq += nhom[i];
        //    return kq;
        //}

        //Tách số thành từng nhóm 3 số, đưa các nhóm 3 số này vào mảng nhomso
        private void TachNhom(string so)
        {
            if (DemSoNhom(so) < 1)
            {
                Stack<char> temp2 = new Stack<char>();
                for (int i = so.Length - 1; i >= 0; i--)
                    temp2.Push(so[i]);
                Array.Resize<Nhom3So>(ref nhomso, nhomso.Length + 1);
                StringBuilder sb = new StringBuilder();
                while (temp2.Count > 0)
                    sb.Append(temp2.Pop());
                nhomso[nhomso.Length - 1] = new Nhom3So(sb.ToString());
                Array.Reverse(nhomso);
            }
            else
            {
                for (int i = 0; i < DemSoNhom(so); i++)
                {
                    Stack<char> temp = new Stack<char>();
                    for (int j = so.Length - (1 + i * 3); j >= so.Length - (3 + i * 3); j--)
                        temp.Push(so[j]);
                    Array.Resize<Nhom3So>(ref nhomso, nhomso.Length + 1);
                    StringBuilder sb = new StringBuilder();
                    while (temp.Count > 0)
                        sb.Append(temp.Pop());
                    nhomso[nhomso.Length - 1] = new Nhom3So(sb.ToString());
                }
                Stack<char> temp2 = new Stack<char>();
                for (int i = so.Length - (1 + DemSoNhom(so) * 3); i >= 0; i--)
                    temp2.Push(so[i]);
                Array.Resize<Nhom3So>(ref nhomso, nhomso.Length + 1);
                StringBuilder sb2 = new StringBuilder();
                while (temp2.Count > 0)
                    sb2.Append(temp2.Pop());
                nhomso[nhomso.Length - 1] = new Nhom3So(sb2.ToString());
                Array.Reverse(nhomso);
            }
        }

        //Khởi tạo Hashtable dùng để đọc tên lớp nghìn, triệu, tỉ...
        int[] solop = { 0, 1, 2, 3 }; //Số nhóm đã đếm với DemSoNhom()
        string[] tenlop = { "", " nghìn ", " triệu ", " tỉ " };

        public Dictionary<int, string> hlop = new Dictionary<int, string>();
        private void KhoiTao_hlop()
        {
            for (int i = 0; i <= solop.Length - 1; i++)
                hlop.Add(solop[i], tenlop[i]);
        }

        //Cách đọc lớp
        private string DocLop(int so) //Nhập vào CHỈ SỐ (INDEX) của nhóm (tính từ phải sang trái)
        {
            if (so <= 3)
                return hlop[so].ToString();
            else
                if (so % 3 == 0)
                return hlop[3].ToString();
            else
                return hlop[so % 3].ToString();
        }

        public bool BaSo0 = false;

        //Bỏ các số 0 vô nghĩa bên trái cùng
        private string Boso0(string so)
        {
            while (so[0] == '0')
            {
                string temp = "";
                for (int i = 1; i < so.Length; i++)
                    temp += so[i];
                so = temp;
            }
            return so;
        }

        //Định dạng chuỗi "không có khoảng trắng thừa, viết hoa kí tự đầu tiên"
        private string DinhDang(string s)
        {
            while (s[0] == ' ')
            {
                string temp = "";
                for (int i = 1; i < s.Length; i++)
                    temp += s[i];
                s = temp;
            }
            //while (s.IndexOf("  ") !=-1)
            //    s.Replace("  ", " ");

            string temp2 = "";
            temp2 += char.ToUpper(s[0]);
            for (int i = 1; i < s.Length; i++)
                temp2 += s[i];
            s = temp2;
            return s;
        }

        public string DocSo(int number)
        {
            if(number == 0)
            {
                return "không";
            }
            Array.Resize<Nhom3So>(ref nhomso, 0);
            string stringSo = Boso0(number.ToString());
            TachNhom(stringSo);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < nhomso.Length; i++)
            {
                if (i == 0 && i == DemSoNhom(stringSo))
                    sb.Append(Doc3so(nhomso[i], true, true));
                else
                    if (i == 0 && i != DemSoNhom(stringSo))
                    sb.Append(Doc3so(nhomso[i], true, false));
                else
                        if (i != 0 && i == DemSoNhom(stringSo))
                    sb.Append(Doc3so(nhomso[i], false, true));
                else
                    sb.Append(Doc3so(nhomso[i], false, false));
                if (!BaSo0)
                    sb.Append(DocLop(DemSoNhom(stringSo) - i));
            }
            return DinhDang(sb.ToString());
        }
    }
}
