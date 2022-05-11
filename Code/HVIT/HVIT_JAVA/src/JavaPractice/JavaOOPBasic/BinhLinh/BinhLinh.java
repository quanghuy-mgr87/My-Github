package JavaPractice.JavaOOPBasic.BinhLinh;

public class BinhLinh {
    protected String Ten;
    protected double SucManh = 50;
    protected boolean TrangBi = false;

    public String getTen() {
        return Ten;
    }

    public void setTen(String ten) {
        Ten = ten;
    }

    public double getSucManh() {
        return SucManh;
    }

    public void setSucManh(int sucManh) {
        SucManh = sucManh;
    }

    public boolean isTrangBi() {
        return TrangBi;
    }

    public void setTrangBi(boolean trangBi) {
        TrangBi = trangBi;
        TinhSucManh();
    }

    protected void TinhSucManh() {
        if (this.TrangBi) {
            this.SucManh = this.SucManh * 1.1;
        }
    }

    public void InThongTin() {
        System.out.println(Ten + " co chi so suc manh la " + SucManh);
    }

    public int ChienDau(BinhLinh linh) {
        return SucManh > linh.getSucManh() ? 1 : SucManh == linh.getSucManh() ? 0 : -1;
    }
}
