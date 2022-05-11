package com.example.demoPhieuThu.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.*;
import java.util.List;

@Entity
@Table(name = "NguyenLieu")
public class NguyenLieu {
    @Id
    private int nguyenLieuId;

    @Column(name = "TenNguyenLieu")
    private String tenNguyenLieu;

    @Column(name = "GiaBan")
    private double giaBan;

    @Column(name = "DonViTinh")
    private String donViTinh;

    @Column(name = "SoLuongKho")
    private int soLuongKho;

    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "loaiNguyenLieuId")
    private LoaiNguyenLieu loaiNguyenLieu;

    public int getNguyenLieuId() {
        return nguyenLieuId;
    }

    public void setNguyenLieuId(int nguyenLieuId) {
        this.nguyenLieuId = nguyenLieuId;
    }

    public String getTenNguyenLieu() {
        return tenNguyenLieu;
    }

    public void setTenNguyenLieu(String tenNguyenLieu) {
        this.tenNguyenLieu = tenNguyenLieu;
    }

    public double getGiaBan() {
        return giaBan;
    }

    public void setGiaBan(double giaBan) {
        this.giaBan = giaBan;
    }

    public String getDonViTinh() {
        return donViTinh;
    }

    public void setDonViTinh(String donViTinh) {
        this.donViTinh = donViTinh;
    }

    public int getSoLuongKho() {
        return soLuongKho;
    }

    public void setSoLuongKho(int soLuongKho) {
        this.soLuongKho = soLuongKho;
    }

    public LoaiNguyenLieu getLoaiNguyenLieu() {
        return loaiNguyenLieu;
    }

    public void setLoaiNguyenLieu(LoaiNguyenLieu loaiNguyenLieu) {
        this.loaiNguyenLieu = loaiNguyenLieu;
    }

}
