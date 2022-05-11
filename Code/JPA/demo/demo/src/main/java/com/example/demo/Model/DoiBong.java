package com.example.demo.Model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import java.util.Set;

@Entity
public class DoiBong {
    @Id
    private int id;

    private String tenDoiBong;

    @OneToMany(mappedBy = "doiBong", fetch = FetchType.EAGER)
    Set<CauThu> setCauThu;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getTenDoiBong() {
        return tenDoiBong;
    }

    public void setTenDoiBong(String tenDoiBong) {
        this.tenDoiBong = tenDoiBong;
    }

    public Set<CauThu> getSetCauThu() {
        return setCauThu;
    }

    public void setSetCauThu(Set<CauThu> setCauThu) {
        this.setCauThu = setCauThu;
    }
}
