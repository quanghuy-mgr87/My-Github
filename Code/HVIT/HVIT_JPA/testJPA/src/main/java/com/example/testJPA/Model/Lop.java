package com.example.testJPA.Model;

import javax.persistence.*;
import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import java.util.List;

@Entity
@Table(name = "Lop")
public class Lop {
    @Id
    @GeneratedValue
    private int id;
    @Column
    private String tenLop;
    @Column
    @Min(value = 0)
    @Max(value = 50)
    private int siSo;

    @OneToMany(mappedBy = "lop", cascade = CascadeType.ALL)
    //mappedBy: tro den ten bien Lop trong HocSinh
    private List<HocSinh> hocSinhs;

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
}
