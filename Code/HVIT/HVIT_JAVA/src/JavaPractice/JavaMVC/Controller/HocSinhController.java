package JavaPractice.JavaMVC.Controller;

import JavaPractice.JavaMVC.Interface.HocSinhInterface;
import JavaPractice.JavaMVC.Model.HocSinh;
import JavaPractice.JavaMVC.Model.ListHS;

import java.util.Collections;
import java.util.List;

public class HocSinhController implements HocSinhInterface {
    private HocSinh TimHocSinhTheoMa(int maHocSinh) {
        for (HocSinh hs : ListHS.lst) {
            if (hs.getMaHS() == maHocSinh)
                return hs;
        }
        return null;
    }

    @Override
    public boolean ThemHocSinh(HocSinh hocSinh) {
        HocSinh hs = TimHocSinhTheoMa(hocSinh.getMaHS());
        if (hs == null) {
            ListHS.lst.add(hocSinh);
            return true;
        }
        return false;
    }

    @Override
    public boolean SuaHocSinh(HocSinh hocSinh) {
        HocSinh hs = TimHocSinhTheoMa(hocSinh.getMaHS());
        if (hs != null) {
            hs.setHoTen(hocSinh.getHoTen());
            hs.setTuoi(hocSinh.getTuoi());
            Collections.replaceAll(ListHS.lst, hs, hocSinh);
            return true;
        }
        return false;
    }

    @Override
    public boolean XoaHocSinh(int hocSinhId) {
        HocSinh hs = TimHocSinhTheoMa(hocSinhId);
        if (hs != null) {
            ListHS.lst.remove(hs);
            return true;
        }
        return false;
    }

    @Override
    public void HienThiDS(List<HocSinh> lst) {
        for (HocSinh hocSinh : ListHS.lst) {
            System.out.println(hocSinh.toString());
        }
    }
}
