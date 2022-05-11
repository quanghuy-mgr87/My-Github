package com.example.JPA_HocSinh.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.Size;
import java.util.List;

@Entity
@Table(name = "Lop")
public class Lop {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    @Column
    @Size(max = 10, message = "Ten lop khong duoc qua 10 ki tu")
    private String tenLop;
    @Column
    @Max(value = 7, message = "Si so toi da, khong the them hoc sinh")
    private int siSo;
    @OneToMany(mappedBy = "lop", cascade = CascadeType.ALL, fetch = FetchType.EAGER)
    @JsonIgnore //ko bi lap vo han
    private List<HocSinh> hocSinhList;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTenLop() {
        return tenLop;
    }

    public void setTenLop(String tenLop) {
        this.tenLop = tenLop;
    }

    public int getSiSo() {
        return siSo;
    }

    public void setSiSo(int siSo) {
        this.siSo = siSo;
    }

    public List<HocSinh> getHocSinhList() {
        return hocSinhList;
    }

    public void setHocSinhList(List<HocSinh> hocSinhList) {
        this.hocSinhList = hocSinhList;
    }
}
