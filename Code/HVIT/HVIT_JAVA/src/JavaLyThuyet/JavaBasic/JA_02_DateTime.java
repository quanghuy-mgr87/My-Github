package JavaLyThuyet.JavaBasic;

import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.util.Calendar;
import java.util.Date;

public class JA_02_DateTime {
    public static void main(String[] args) {
        Date now = new Date();
        System.out.println(now);
        long nowInMs = System.currentTimeMillis();
        System.out.println(nowInMs);
        long newMs = now.getTime();
        System.out.println(newMs);

        //hien thi 100 ngay sau ngay hien tai
        //doi thoi gian hien tai ra millisecond, sau do doi thoi gian 1 ngay ra millisecond roi nhan voi 100 dem + voi thoi gian hien tai thi ra thoi gian 100 ngay sau
        Date ngayThu100 = new Date(nowInMs + 24 * 60 * 60 * 1000 * 100);
        System.out.println(ngayThu100);

        LocalDate localDate = LocalDate.now();
        System.out.println(localDate);
        LocalDate newDate = LocalDate.of(1997, 05, 22);
        System.out.println(newDate);

        //tang them 1 ngay
        newDate = newDate.plusDays(1);
        System.out.println(newDate);

        //xac dinh ngay hom nay la ngay thu bao nhieu cua nam 2020
        System.out.println(localDate.getDayOfYear());

        //format date
        Date now1 = new Date();
        SimpleDateFormat simple = new SimpleDateFormat("dd/MM/yyyy");
        String time = simple.format(now1);
        System.out.println(time);

        //Calendar
        Calendar cal = Calendar.getInstance();

        //ngay hom nay la ngay thu may trong tuan?
        System.out.println("Day of week: " + cal.get(Calendar.DAY_OF_WEEK));
        System.out.println("Year: "+cal.get(Calendar.YEAR));

        //lay so tuan lon nhat trong nam co the co
        int max = cal.getMaximum(Calendar.WEEK_OF_YEAR);
        System.out.println(max);
        //lay so ngay lon nhat trong nam co the co
        System.out.println(cal.getMaximum(Calendar.DAY_OF_YEAR));
    }
}
