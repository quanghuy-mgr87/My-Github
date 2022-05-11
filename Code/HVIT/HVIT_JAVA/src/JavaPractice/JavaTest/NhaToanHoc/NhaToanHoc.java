package JavaPractice.JavaTest.NhaToanHoc;

public class NhaToanHoc {
    //Thuoc tinh
    public String HoTen;
    public double ChieuCao;
    public int NamSinh;
    public String QueQuan;

    //Phuong thuc khoi tao
    public NhaToanHoc() {

    }

    public NhaToanHoc(String hoTen, double chieuCao, int namSinh, String queQuan) {
        HoTen = hoTen;
        ChieuCao = chieuCao;
        NamSinh = namSinh;
        QueQuan = queQuan;
    }

    //Hanh vi (Phuong thuc)
    public double Cong2So(double a, double b) {
        return a + b;
    }

    public Boolean KiemTraSoChan(int a) {
        if (a % 2 == 0)
            return true;
        else
            return false;
    }

    public void HienThiThongTinCaNhan() {
        System.out.println("Ho ten: " + HoTen + ", nam sinh " + NamSinh);
    }
}
