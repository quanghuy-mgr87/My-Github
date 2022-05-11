package com.example.demoPhieuThu.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.*;
import java.util.List;

@Entity
@Table(name = "LoaiNguyenLieu")
public class LoaiNguyenLieu {
    @Id
    private int loaiNguyenLieuId;

    @Column(name = "TenLoai")
    private String tenLoai;

    @Column(name = "MoTa")
    private String moTa;

    @OneToMany(mappedBy = "loaiNguyenLieu")
    @JsonIgnoreProperties(value = "loaiNguyenLieu")
    List<NguyenLieu> nguyenLieuList;

    public List<NguyenLieu> getNguyenLieuList() {
        return nguyenLieuList;
    }

    public void setNguyenLieuList(List<NguyenLieu> nguyenLieuList) {
        this.nguyenLieuList = nguyenLieuList;
    }

    public int getLoaiNguyenLieuId() {
        return loaiNguyenLieuId;
    }

    public void setLoaiNguyenLieuId(int loaiNguyenLieuId) {
        this.loaiNguyenLieuId = loaiNguyenLieuId;
    }

    public String getTenLoai() {
        return tenLoai;
    }

    public void setTenLoai(String tenLoai) {
        this.tenLoai = tenLoai;
    }

    public String getMoTa() {
        return moTa;
    }

    public void setMoTa(String moTa) {
        this.moTa = moTa;
    }
}
