package com.example.demoCauThuJPA.Model;

import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import javax.validation.constraints.NotNull;

@Entity
@Table(name = "CauThu")
public class CauThu {
    @Id
    private int Id;
    @Column
    @NotNull
    private String name;
    @Column
    @Min(value = 1)
    @Max(value = 99)
    private int SoAo;
    @Column
    private String viTri;
    @Column
    private int namSinh;
    @Column
    @Min(value = 0)
    private double chieuCao;
    @ManyToOne(fetch = FetchType.EAGER)
    @JoinColumn(name = "doiBongId")
    private DoiBong doiBong;

    public CauThu() {
    }

    public int getId() {
        return Id;
    }

    public void setId(int id) {
        Id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getSoAo() {
        return SoAo;
    }

    public void setSoAo(int soAo) {
        SoAo = soAo;
    }

    public String getViTri() {
        return viTri;
    }

    public void setViTri(String viTri) {
        this.viTri = viTri;
    }

    public int getNamSinh() {
        return namSinh;
    }

    public void setNamSinh(int namSinh) {
        this.namSinh = namSinh;
    }

    public double getChieuCao() {
        return chieuCao;
    }

    public void setChieuCao(double chieuCao) {
        this.chieuCao = chieuCao;
    }
}
