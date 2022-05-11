package JavaPractice.JavaOOPBasic.SoThuc;

public class SoThuc {
    private double GiaTri;
    private boolean LaSoDuong;

    public double getGiaTri() {
        return GiaTri;
    }

    public void setGiaTri(double giaTri) {
        GiaTri = giaTri;
        setLaSoDuong(GiaTri > 0 ? true : false);
    }

    public boolean isLaSoDuong() {
        return LaSoDuong;
    }

    public void setLaSoDuong(boolean laSoDuong) {
        LaSoDuong = laSoDuong;
    }

    public SoThuc(double gt) {
        setGiaTri(gt);
    }

    public static SoThuc TimMax(SoThuc a, SoThuc b, SoThuc c) {
        return (a.getGiaTri() > b.getGiaTri() && a.getGiaTri() > c.getGiaTri() ? a : b.getGiaTri() > a.getGiaTri() && b.getGiaTri() > c.getGiaTri() ? b : c);
    }

    public double TimCanBacN(int n) {
        return Math.pow(GiaTri, 1 * 1.0 / n);
    }
}
