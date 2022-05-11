package com.example.JPA_HocSinh.Model;

import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import javax.validation.constraints.Size;

@Entity
@Table(name = "HocSinh")
public class HocSinh {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @Column
    @Size(max = 20, message = "Ho ten khong duoc qua 20 ki tu")
    private String hoTen;
    @Column
    @Min(value = 2002, message = "Nam sinh phai lon hon 2002")
    @Max(value = 2014, message = "Nam sinh phai nho hon 2014")
    private int namSinh;
    @Column
    private String queQuan;
    @ManyToOne
    @JoinColumn(name = "LopId")
    private Lop lop;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getHoTen() {
        return hoTen;
    }

    public void setHoTen(String hoTen) {
        this.hoTen = hoTen;
    }

    public int getNamSinh() {
        return namSinh;
    }

    public void setNamSinh(int namSinh) {
        this.namSinh = namSinh;
    }

    public String getQueQuan() {
        return queQuan;
    }

    public void setQueQuan(String queQuan) {
        this.queQuan = queQuan;
    }

    public Lop getLop() {
        return lop;
    }

    public void setLop(Lop lop) {
        this.lop = lop;
    }
}
