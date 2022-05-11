package JavaPractice.JavaOOPBasic.SanPham;

import java.util.Scanner;

public class SanPham {
    private int MaSanPham;
    private String TenSanPham;
    private String LoaiSanPham;
    private Boolean LaSanPhamMoi;

    public int getMaSanPham() {
        return MaSanPham;
    }

    public void setMaSanPham(int maSanPham) {
        MaSanPham = maSanPham;
    }

    public String getTenSanPham() {
        return TenSanPham;
    }

    public void setTenSanPham(String tenSanPham) {
        TenSanPham = tenSanPham;
    }

    public String getLoaiSanPham() {
        return LoaiSanPham;
    }

    public void setLoaiSanPham(String loaiSanPham) {
        LoaiSanPham = loaiSanPham;
    }

    public Boolean getLaSanPhamMoi() {
        return LaSanPhamMoi;
    }

    public void setLaSanPhamMoi(Boolean laSanPhamMoi) {
        LaSanPhamMoi = laSanPhamMoi;
    }

    public SanPham(int maSP, String tenSP, String loaiSP, boolean laSanPhamMoi) {
        setMaSanPham(maSP);
        setTenSanPham(tenSP);
        setLoaiSanPham(loaiSP);
        setLaSanPhamMoi(laSanPhamMoi);
    }

    public void InThongTin() {
        System.out.println("San pham " + getTenSanPham() + " co ma la " + getMaSanPham() + " thuoc loai san pham " + getLoaiSanPham() + " la san pham moi " + getLaSanPhamMoi());
    }
}
