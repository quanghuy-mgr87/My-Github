package com.example.testJPA.Model;

import org.springframework.web.bind.annotation.Mapping;

import javax.persistence.*;
import java.time.LocalDate;
@Entity
@Table(name = "HocSinh")
public class HocSinh {
    @Id
    @GeneratedValue
    private int id;
    @Column
    private String hoTen;
    @Column
    private LocalDate ngaySinh;
    @Column
    private String queQuan;

    @ManyToOne
    @JoinColumn(name="lopId")   //ket noi thong qua khoa ngoai lopId
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

    public LocalDate getNgaySinh() {
        return ngaySinh;
    }

    public void setNgaySinh(LocalDate ngaySinh) {
        this.ngaySinh = ngaySinh;
    }

    public String getQueQuan() {
        return queQuan;
    }

    public void setQueQuan(String queQuan) {
        this.queQuan = queQuan;
    }
}
