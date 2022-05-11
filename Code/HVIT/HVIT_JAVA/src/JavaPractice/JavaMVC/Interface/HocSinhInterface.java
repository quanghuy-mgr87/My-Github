package JavaPractice.JavaMVC.Interface;

import JavaPractice.JavaMVC.Model.HocSinh;

import java.util.List;

public interface HocSinhInterface {
    public boolean ThemHocSinh(HocSinh hocSinh);

    public boolean SuaHocSinh(HocSinh hocSinh);

    public boolean XoaHocSinh(int hocSinhId);

    public void HienThiDS(List<HocSinh> lst);
}
