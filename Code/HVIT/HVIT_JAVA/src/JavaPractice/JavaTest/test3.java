package JavaPractice.JavaTest;

import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.util.*;

class NgayThang {
    private int ngay;
    private int thang;
    private int nam;
    private int thu;

    public int getNgay() {
        return ngay;
    }

    public void setNgay(int ngay) {
        this.ngay = ngay;
    }

    public int getThang() {
        return thang;
    }

    public void setThang(int thang) {
        this.thang = thang;
    }

    public int getNam() {
        return nam;
    }

    public void setNam(int nam) {
        this.nam = nam;
    }

    public int getThu() {
        return thu;
    }

    public void setThu() {
        Calendar calendar = new GregorianCalendar(nam, thang - 1, ngay);
        thu = calendar.get(Calendar.DAY_OF_WEEK);
    }

    public NgayThang(int ngay, int thang, int nam) {
        this.ngay = ngay;
        this.thang = thang;
        this.nam = nam;
        setThu();
    }

    public void InThongTin() {
        System.out.println("Thu " + getThu() + " ngay " + getNgay() + "/" + getThang() + "/" + getNam());
    }
}

public class test3 {
    public static void main(String[] args) {
        NgayThang ngayThang = new NgayThang(22, 5, 1997);
        ngayThang.InThongTin();
    }
}