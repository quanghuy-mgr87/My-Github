package JavaPractice.JavaMVC;

import JavaPractice.JavaMVC.Model.HocSinh;
import JavaPractice.JavaMVC.View.HocSinhView;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

public class Main {
    public static void main(String[] args) throws ParseException {
//        HocSinhView.Menu();
//        String sDate1 = "31/12/1998";
//        Date date1 = new SimpleDateFormat("dd/MM/yyyy").parse(sDate1);
//        System.out.println(sDate1 + "\t" + date1);

        HocSinh hs = new HocSinh();
        hs.setMaHS(1);
        hs.setTuoi(12);
        hs.setHoTen("âsasdf");

        HocSinh hs2 = new HocSinh();
        hs.setTuoi(15);
        System.out.println(hs2.toString());
    }
}
