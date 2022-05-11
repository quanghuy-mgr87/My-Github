package com.example.demo.Model;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.Min;

@Entity
public class CauThu {
    @Id
    private int maCauThu;

    private String tenCauThu;

    @Min(value = 10)
    @Max(value = 99)
    private int soAo;

    private String viTri;

    @ManyToOne(fetch = FetchType.EAGER)
    @JsonIgnoreProperties(value = "setCauThu")
    DoiBong doiBong;

    public int getMaCauThu() {
        return maCauThu;
    }

    public void setMaCauThu(int maCauThu) {
        this.maCauThu = maCauThu;
    }

    public String getTenCauThu() {
        return tenCauThu;
    }

    public void setTenCauThu(String tenCauThu) {
        this.tenCauThu = tenCauThu;
    }

    public int getSoAo() {
        return soAo;
    }

    public void setSoAo(int soAo) {
        this.soAo = soAo;
    }

    public String getViTri() {
        return viTri;
    }

    public void setViTri(String viTri) {
        this.viTri = viTri;
    }

    public DoiBong getDoiBong() {
        return doiBong;
    }

    public void setDoiBong(DoiBong doiBong) {
        this.doiBong = doiBong;
    }
}
